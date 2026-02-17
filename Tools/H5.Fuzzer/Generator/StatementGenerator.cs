using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class StatementGenerator
    {
        private readonly Random _random;
        private readonly TypeManager _types;
        private readonly List<MethodDeclarationSyntax> _methods;
        private readonly ExpressionGenerator _expressions;
        private int _variableCounter = 0;

        public StatementGenerator(Random random, TypeManager types, List<MethodDeclarationSyntax> methods)
        {
            _random = random;
            _types = types;
            _methods = methods;
            _expressions = new ExpressionGenerator(random, types, methods);
        }

        public List<StatementSyntax> GenerateStatements(int count, int depth, TypeSyntax returnType = null)
        {
            var statements = new List<StatementSyntax>();
            var scope = new Scope(); // Tracks variables in current scope

            for (int i = 0; i < count; i++)
            {
                // Decide statement type
                int type = _random.Next(6);
                
                // Avoid deep nesting
                if (depth > 2 && (type == 3 || type == 4)) type = 0;

                StatementSyntax stmt = null;
                switch (type)
                {
                    case 0: // Variable Declaration
                        stmt = GenerateVariableDeclaration(scope);
                        break;
                    case 1: // Assignment
                        stmt = GenerateAssignment(scope);
                        break;
                    case 2: // Console.WriteLine
                        stmt = GenerateConsoleWriteLine(scope);
                        break;
                    case 3: // If
                        stmt = GenerateIf(depth + 1, scope, returnType);
                        break;
                    case 4: // While (Bounded)
                        stmt = GenerateWhile(depth + 1, scope, returnType);
                        break;
                }

                if (stmt != null)
                {
                    statements.Add(stmt);
                }
            }

            if (returnType != null && !AreTypesEquivalent(returnType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
            {
                statements.Add(ReturnStatement(_expressions.GenerateExpression(returnType, scope)));
            }
            else if (returnType != null && AreTypesEquivalent(returnType, PredefinedType(Token(SyntaxKind.VoidKeyword))) && _random.NextDouble() < 0.2)
            {
                statements.Add(ReturnStatement());
            }

            return statements;
        }

        private StatementSyntax GenerateVariableDeclaration(Scope scope)
        {
            var type = _types.GetRandomType();
            var name = $"v{_variableCounter++}";
            var expression = _expressions.GenerateExpression(type, scope);
            
            scope.AddVariable(name, type);

            return LocalDeclarationStatement(
                VariableDeclaration(type)
                .WithVariables(SingletonSeparatedList(
                    VariableDeclarator(Identifier(name))
                    .WithInitializer(EqualsValueClause(expression)))));
        }

        private StatementSyntax GenerateAssignment(Scope scope)
        {
            var variable = scope.GetRandomVariable(_random);
            if (variable == null) return null; // No variables to assign

            var expression = _expressions.GenerateExpression(variable.Type, scope);
            
            return ExpressionStatement(
                AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    IdentifierName(variable.Name),
                    expression));
        }

        private StatementSyntax GenerateConsoleWriteLine(Scope scope)
        {
            // Print a literal or a variable
            ExpressionSyntax expr;
            if (_random.NextDouble() < 0.5)
            {
                expr = LiteralExpression(SyntaxKind.StringLiteralExpression, Literal($"Trace {_variableCounter}"));
            }
            else
            {
                var variable = scope.GetRandomVariable(_random);
                if (variable != null)
                {
                    expr = IdentifierName(variable.Name);
                }
                else
                {
                    expr = LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("Trace"));
                }
            }

            return ExpressionStatement(
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("Console"),
                        IdentifierName("WriteLine")))
                .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(expr)))));
        }

        private StatementSyntax GenerateIf(int depth, Scope parentScope, TypeSyntax returnType)
        {
            var condition = _expressions.GenerateExpression(_types.GetRandomType(), parentScope, forceBool: true);
            
            var ifBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null)); 
            
            ElseClauseSyntax elseClause = null;
            if (_random.NextDouble() < 0.5)
            {
                var elseBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null));
                elseClause = ElseClause(elseBody);
            }

            return IfStatement(condition, ifBody).WithElse(elseClause);
        }

        private StatementSyntax GenerateWhile(int depth, Scope scope, TypeSyntax returnType)
        {
            var loopVar = $"i{_variableCounter++}";
            var limit = _random.Next(2, 10);
            
            var declaration = VariableDeclaration(PredefinedType(Token(SyntaxKind.IntKeyword)))
                .WithVariables(SingletonSeparatedList(
                    VariableDeclarator(Identifier(loopVar))
                    .WithInitializer(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0))))));

            var condition = BinaryExpression(
                SyntaxKind.LessThanExpression,
                IdentifierName(loopVar),
                LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(limit)));

            var incrementors = SingletonSeparatedList<ExpressionSyntax>(
                PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, IdentifierName(loopVar)));

            var body = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null));

            return ForStatement(declaration, SeparatedList<ExpressionSyntax>(), condition, incrementors, body);
        }
        
        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }
    }
}
