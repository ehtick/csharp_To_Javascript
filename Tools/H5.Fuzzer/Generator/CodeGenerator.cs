using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class CodeGenerator
    {
        private readonly Random _random;
        private readonly TypeManager _types;
        private readonly MethodGenerator _methods;

        public CodeGenerator(int seed)
        {
            _random = new Random(seed);
            _types = new TypeManager(_random);
            _methods = new MethodGenerator(_random, _types);
        }

        public string GenerateProgram()
        {
            var methods = new List<MethodDeclarationSyntax>();

            // Generate some helper methods
            int methodCount = _random.Next(1, 5);
            for (int i = 0; i < methodCount; i++)
            {
                methods.Add(_methods.GenerateMethod($"Method_{i}"));
            }

            // Generate Main
            var mainMethod = GenerateMainMethod(methods);

            var programClass = ClassDeclaration("Program")
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                .AddMembers(methods.ToArray())
                .AddMembers(mainMethod);

            var compilationUnit = CompilationUnit()
                .AddUsings(
                    UsingDirective(IdentifierName("System")),
                    UsingDirective(IdentifierName("System.Threading.Tasks")),
                    UsingDirective(IdentifierName("System.Collections.Generic")),
                    UsingDirective(IdentifierName("System.Linq"))
                )
                .AddMembers(programClass)
                .NormalizeWhitespace();

            return compilationUnit.ToFullString();
        }

        private MethodDeclarationSyntax GenerateMainMethod(List<MethodDeclarationSyntax> availableMethods)
        {
            var statements = new List<StatementSyntax>();
            statements.Add(ParseStatement("Console.WriteLine(\"Program Start\");"));
            
            // Generate random statements calling other methods or doing logic
            var bodyGenerator = new StatementGenerator(_random, _types, availableMethods);
            statements.AddRange(bodyGenerator.GenerateStatements(10, 0, returnType: null, parentScope: null, isAsync: true));

            statements.Add(ParseStatement("Console.WriteLine(\"Program End\");"));

            return MethodDeclaration(IdentifierName("Task"), "Main")
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword), Token(SyntaxKind.AsyncKeyword)))
                .WithBody(Block(statements));
        }
    }
}
