using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace H5.Fuzzer.Infrastructure
{
    public class Minimizer
    {
        private readonly PlaywrightRunner _playwright;

        public Minimizer(PlaywrightRunner playwright)
        {
            _playwright = playwright;
        }

        public async Task<string> MinimizeAsync(string originalCode)
        {
            string currentCode = originalCode;
            bool changed = true;
            int iteration = 0;

            Console.WriteLine("Starting minimization...");

            // Initial verification
            if (!await IsFailing(currentCode))
            {
                Console.WriteLine("Original code does not reproduce failure. Aborting minimization.");
                return originalCode;
            }

            while (changed && iteration < 50) // Limit iterations
            {
                changed = false;
                iteration++;
                Console.WriteLine($"Minimization Iteration {iteration}. Code size: {currentCode.Length}");

                // 1. Try removing whole Types (except Program)
                var newCode = await TryRemoveNodes<TypeDeclarationSyntax>(currentCode, t => t.Identifier.Text != "Program");
                if (newCode != currentCode)
                {
                    currentCode = newCode;
                    changed = true;
                    continue; // Restart loop to re-parse and re-evaluate
                }

                // 2. Try removing Members from Types (Methods, Properties)
                newCode = await TryRemoveNodes<MemberDeclarationSyntax>(currentCode, m =>
                    (m is MethodDeclarationSyntax md && md.Identifier.Text != "Main") ||
                    (m is PropertyDeclarationSyntax));

                if (newCode != currentCode)
                {
                    currentCode = newCode;
                    changed = true;
                    continue;
                }

                // 3. Try removing Statements
                newCode = await TryRemoveNodes<StatementSyntax>(currentCode, s =>
                    !(s is ReturnStatementSyntax) && // Don't remove return blindly
                    !(s is LocalDeclarationStatementSyntax) // Removing declarations breaks usage, usually fails compilation immediately, but worth trying if unused
                );

                if (newCode != currentCode)
                {
                    currentCode = newCode;
                    changed = true;
                }
            }

            return currentCode;
        }

        private async Task<string> TryRemoveNodes<T>(string code, Func<T, bool> predicate) where T : SyntaxNode
        {
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = await tree.GetRootAsync();

            // Find all candidates in the current tree
            var candidates = root.DescendantNodes().OfType<T>().Where(predicate).ToList();

            // We iterate backwards so removing later nodes doesn't affect earlier nodes indices?
            // Actually, syntax nodes are objects in the tree. Removing one creates a NEW tree.
            // So existing 'candidates' nodes belong to old tree.

            // We must re-parse or track nodes.
            // But we want to try removing EACH candidate individually to see if failure persists.
            // If we remove one and it still fails -> Good, keep removal.
            // Then proceed to remove next one from the NEW code.

            // So we need a loop that finds ONE candidate, removes it, checks failure.
            // If failure persists, update code and loop again.
            // If failure disappears, restore code and try next candidate.

            // This is O(N^2) effectively (N candidates * CompileTime).

            for (int i = 0; i < candidates.Count; i++)
            {
                // Re-parse current best code to get fresh tree
                var currentTree = CSharpSyntaxTree.ParseText(code);
                var currentRoot = await currentTree.GetRootAsync();

                // Find the i-th candidate in the fresh tree
                // This assumes order is deterministic and stable
                var currentCandidates = currentRoot.DescendantNodes().OfType<T>().Where(predicate).ToList();

                if (i >= currentCandidates.Count) break; // Should not happen if logic is correct

                var nodeToRemove = currentCandidates[i];
                var newRoot = currentRoot.RemoveNode(nodeToRemove, SyntaxRemoveOptions.KeepNoTrivia);
                var newCode = newRoot.ToFullString();

                // Check if still failing
                if (await IsFailing(newCode))
                {
                    code = newCode;
                    Console.Write(".");
                    // Since we removed a node, the list of candidates shifted.
                    // The node at index i is gone. The node at index i+1 is now at index i.
                    // So we must decrement i to process the *new* i-th node in next iteration.
                    i--;
                    // Also total candidates count decreases effectively, but we re-fetch candidates list size in next iteration check?
                    // No, we use 'candidates.Count' from original tree as upper bound loop?
                    // No, we should use while loop or adjust 'i'.
                }
                else
                {
                    // If removing it fixes the failure (or breaks compilation so comparison fails), we keep the node.
                    // So we proceed to next candidate (i++).
                }
            }
            Console.WriteLine();

            return code;
        }

        private async Task<bool> IsFailing(string code)
        {
            try
            {
                // 1. Compile and Run Roslyn
                var roslynOutput = await RoslynRunner.CompileAndRunAsync(code);
                roslynOutput = NormalizeOutput(roslynOutput);

                // 2. Compile and Run H5
                var h5Js = await H5Runner.CompileToJs(code);
                var h5Output = await _playwright.RunJsAsync(h5Js, "Program End"); // Assume "Program End" is printed
                h5Output = NormalizeOutput(h5Output);

                // Compare
                return roslynOutput != h5Output;
            }
            catch (Exception)
            {
                // Compilation error or runtime error
                // If the original code failed with an exception, maybe we should consider exception as "failure" too?
                // But usually we want to preserve the *behavior mismatch*.
                // If compilation fails, we can't run, so we can't reproduce mismatch.
                return false;
            }
        }

        private static string NormalizeOutput(string output)
        {
            if (string.IsNullOrEmpty(output)) return "";
            return string.Join("\n", output.Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(s => s.TrimEnd())
                .Where(s => !string.IsNullOrWhiteSpace(s)));
        }
    }
}
