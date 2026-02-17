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
            var returnType = _types.GetRandomType(); // Random return type
            var parameters = GenerateParameters();

            var method = MethodDeclaration(returnType, name)
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)))
                .WithParameterList(ParameterList(SeparatedList(parameters)))
                .WithBody(Block(_statements.GenerateStatements(5, 0, returnType)));

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
