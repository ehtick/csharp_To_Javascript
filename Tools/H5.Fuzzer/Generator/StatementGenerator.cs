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

        public List<StatementSyntax> GenerateStatements(int count, int depth, TypeSyntax returnType = null, Scope parentScope = null, bool isAsync = false)
        {
            var statements = new List<StatementSyntax>();
            var scope = new Scope(parentScope); // Tracks variables in current scope

            for (int i = 0; i < count; i++)
            {
                // Decide statement type
                int type = _random.Next(8);
                
                // Avoid deep nesting
                if (depth > 2 && (type >= 3)) type = 0;

                // Async specific
                if (type == 7 && !isAsync) type = 0;

                StatementSyntax stmt = null;
                switch (type)
                {
                    case 0: stmt = GenerateVariableDeclaration(scope, isAsync); break;
                    case 1: stmt = GenerateAssignment(scope, isAsync); break;
                    case 2: stmt = GenerateConsoleWriteLine(scope); break;
                    case 3: stmt = GenerateIf(depth + 1, scope, returnType, isAsync); break;
                    case 4: stmt = GenerateWhile(depth + 1, scope, returnType, isAsync); break;
                    case 5: stmt = GenerateTryCatch(depth + 1, scope, returnType, isAsync); break;
                    case 6: stmt = GenerateSwitch(depth + 1, scope, returnType, isAsync); break;
                    case 7: stmt = GenerateAwaitStatement(scope, isAsync); break;
                }

                if (stmt != null)
                {
                    statements.Add(stmt);
                }
            }

            if (returnType != null && !AreTypesEquivalent(returnType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
            {
                statements.Add(ReturnStatement(_expressions.GenerateExpression(returnType, scope, depth, false, isAsync)));
            }
            else if (returnType != null && AreTypesEquivalent(returnType, PredefinedType(Token(SyntaxKind.VoidKeyword))) && _random.NextDouble() < 0.2)
            {
                statements.Add(ReturnStatement());
            }

            return statements;
        }

        private StatementSyntax GenerateVariableDeclaration(Scope scope, bool isAsync)
        {
            var type = _types.GetRandomType();
            var name = $"v{_variableCounter++}";
            var expression = _expressions.GenerateExpression(type, scope, 0, false, isAsync);
            
            scope.AddVariable(name, type);

            return LocalDeclarationStatement(
                VariableDeclaration(type)
                .WithVariables(SingletonSeparatedList(
                    VariableDeclarator(Identifier(name))
                    .WithInitializer(EqualsValueClause(expression)))));
        }

        private StatementSyntax GenerateAssignment(Scope scope, bool isAsync)
        {
            var variable = scope.GetRandomVariable(_random);
            if (variable == null) return null; // No variables to assign

            var expression = _expressions.GenerateExpression(variable.Type, scope, 0, false, isAsync);
            
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

        private StatementSyntax GenerateIf(int depth, Scope parentScope, TypeSyntax returnType, bool isAsync)
        {
            var condition = _expressions.GenerateExpression(_types.GetRandomType(), parentScope, 0, true, isAsync);
            
            var ifBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null, parentScope: parentScope, isAsync: isAsync));
            
            ElseClauseSyntax elseClause = null;
            if (_random.NextDouble() < 0.5)
            {
                var elseBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null, parentScope: parentScope, isAsync: isAsync));
                elseClause = ElseClause(elseBody);
            }

            return IfStatement(condition, ifBody).WithElse(elseClause);
        }

        private StatementSyntax GenerateWhile(int depth, Scope scope, TypeSyntax returnType, bool isAsync)
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

            // For loop creates its own scope for loop variable, but body scope should be child of that
            // But here we just pass parent scope to body generator, which isn't strictly correct as 'loopVar' is in scope.
            // But Scope class handles this by being passed down.
            // Wait, GenerateStatements creates NEW scope from parent.
            // So if I want loopVar to be available, I should add it to 'scope' before calling GenerateStatements.
            // But 'scope' here is the PARENT scope of the loop.
            // So I should create a loopScope.

            var loopScope = new Scope(scope);
            loopScope.AddVariable(loopVar, PredefinedType(Token(SyntaxKind.IntKeyword)));

            var body = Block(GenerateStatements(_random.Next(1, 4), depth, returnType: null, parentScope: loopScope, isAsync: isAsync));

            return ForStatement(declaration, SeparatedList<ExpressionSyntax>(), condition, incrementors, body);
        }

        private StatementSyntax GenerateTryCatch(int depth, Scope scope, TypeSyntax returnType, bool isAsync)
        {
            var tryBlock = Block(GenerateStatements(_random.Next(1, 3), depth, returnType, scope, isAsync));

            var catchClauses = new List<CatchClauseSyntax>();
            var exceptionType = _types.GetRandomExceptionType();
            var varName = $"ex{_variableCounter++}";

            var catchDeclaration = CatchDeclaration(exceptionType).WithIdentifier(Identifier(varName));
            var catchBlock = Block(GenerateStatements(_random.Next(1, 2), depth, returnType, scope, isAsync));

            catchClauses.Add(CatchClause(catchDeclaration, null, catchBlock));

            FinallyClauseSyntax finallyClause = null;
            if (_random.NextDouble() < 0.3)
            {
                var finallyBlock = Block(GenerateStatements(1, depth, returnType: null, parentScope: scope, isAsync: isAsync));
                finallyClause = FinallyClause(finallyBlock);
            }

            return TryStatement(tryBlock, List(catchClauses), finallyClause);
        }

        private StatementSyntax GenerateSwitch(int depth, Scope scope, TypeSyntax returnType, bool isAsync)
        {
            // Switch on variable
            var variable = scope.GetRandomVariable(_random);
            ExpressionSyntax switchExpr;
            TypeSyntax switchType;

            if (variable != null && (_types.IsNumeric(variable.Type) || _types.IsString(variable.Type)))
            {
                switchExpr = IdentifierName(variable.Name);
                switchType = variable.Type;
            }
            else
            {
                switchType = _types.GetRandomType();
                if (!_types.IsNumeric(switchType) && !_types.IsString(switchType))
                    switchType = PredefinedType(Token(SyntaxKind.IntKeyword));

                switchExpr = _expressions.GenerateExpression(switchType, scope, 0, false, isAsync);
            }

            var sections = new List<SwitchSectionSyntax>();
            int cases = _random.Next(2, 5);

            for (int i = 0; i < cases; i++)
            {
                var label = CaseSwitchLabel(_expressions.GenerateConstant(switchType));
                var statements = GenerateStatements(_random.Next(1, 3), depth, returnType, scope, isAsync);
                statements.Add(BreakStatement());

                sections.Add(SwitchSection(List<SwitchLabelSyntax>(new []{ label }), List(statements)));
            }

            sections.Add(SwitchSection(
                List<SwitchLabelSyntax>(new []{ DefaultSwitchLabel() }),
                List(GenerateStatements(1, depth, returnType, scope, isAsync)).Add(BreakStatement())));

            return SwitchStatement(switchExpr, List(sections));
        }

        private StatementSyntax GenerateAwaitStatement(Scope scope, bool isAsync)
        {
             // Force generate await
             var targetType = _types.GetRandomType(); // Doesn't matter, we discard
             // Actually, usually await void methods or Tasks.

             // Expression generator can generate await expression.
             // We can just ask for it.
             // But we need to ensure it generates an await expression.
             // We'll create one manually to be safe.

             var delay = _random.Next(10, 100);
             var awaitExpr = AwaitExpression(
                 InvocationExpression(
                     MemberAccessExpression(
                         SyntaxKind.SimpleMemberAccessExpression,
                         IdentifierName("Task"),
                         IdentifierName("Delay")))
                 .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(
                     LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(delay)))))));

             return ExpressionStatement(awaitExpr);
        }
        
        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }
    }
}
