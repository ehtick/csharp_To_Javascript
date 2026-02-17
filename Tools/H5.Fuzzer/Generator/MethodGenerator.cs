using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class MethodGenerator
    {
        private readonly Random _random;
        private readonly TypeManager _types;
        private readonly StatementGenerator _statements;

        public MethodGenerator(Random random, TypeManager types, StatementGenerator statements = null)
        {
            _random = random;
            _types = types;
            _statements = statements ?? new StatementGenerator(random, types, new List<MethodDeclarationSyntax>());
        }

        public MethodDeclarationSyntax GenerateMethod(string name)
        {
            var isAsync = _random.NextDouble() < 0.4;
            TypeSyntax returnType;

            if (isAsync)
            {
                returnType = _types.GetRandomTaskType();
            }
            else
            {
                returnType = _types.GetRandomType();
            }

            var parameters = GenerateParameters();

            // Initial scope with parameters
            var parameterVars = new List<Variable>();
            foreach (var p in parameters)
            {
                parameterVars.Add(new Variable { Name = p.Identifier.Text, Type = p.Type });
            }
            var initialScope = new Scope(parameterVars);

            var modifiers = TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword));
            if (isAsync)
            {
                modifiers = modifiers.Add(Token(SyntaxKind.AsyncKeyword));
            }

            var bodyReturnType = returnType;
            if (isAsync)
            {
                bodyReturnType = _types.GetUnwrappedTaskType(returnType);
            }

            var method = MethodDeclaration(returnType, name)
                .WithModifiers(modifiers)
                .WithParameterList(ParameterList(SeparatedList(parameters)))
                .WithBody(Block(_statements.GenerateStatements(5, 0, bodyReturnType, initialScope, isAsync)));

            return method;
        }

        private List<ParameterSyntax> GenerateParameters()
        {
            var parameters = new List<ParameterSyntax>();
            int count = _random.Next(0, 3);
            for (int i = 0; i < count; i++)
            {
                parameters.Add(Parameter(Identifier($"p{i}"))
                    .WithType(_types.GetRandomType()));
            }
            return parameters;
        }
    }
}
