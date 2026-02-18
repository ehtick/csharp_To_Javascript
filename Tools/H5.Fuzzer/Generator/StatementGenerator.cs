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
        private readonly ExpressionGenerator _expressions;
        private int _variableCounter = 0;

        public StatementGenerator(Random random, TypeManager types, List<MethodDeclarationSyntax> methodsIgnored)
        {
            _random = random;
            _types = types;
            _expressions = new ExpressionGenerator(random, types);
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
                // If returnType is Task<T> but we are in async method, we should return T.
                // The caller handles unwrapping. passed 'returnType' here is usually the T.
                // But wait, MethodGenerator passes unwrapped type.
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

            // Skip assigning to 'this'
            if (variable.Name == "this") return null;

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
                    // Only print primitives or strings to avoid clutter or complex ToString
                    if (_types.IsNumeric(variable.Type) || _types.IsString(variable.Type) || _types.IsBool(variable.Type))
                    {
                        expr = IdentifierName(variable.Name);
                    }
                    else
                    {
                        expr = LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("TraceObj"));
                    }
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
            var condition = _expressions.GenerateExpression(PredefinedType(Token(SyntaxKind.BoolKeyword)), parentScope, 0, true, isAsync);
            
            var ifBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType, parentScope, isAsync));
            
            ElseClauseSyntax elseClause = null;
            if (_random.NextDouble() < 0.5)
            {
                var elseBody = Block(GenerateStatements(_random.Next(1, 4), depth, returnType, parentScope, isAsync));
                elseClause = ElseClause(elseBody);
            }

            return IfStatement(condition, ifBody).WithElse(elseClause);
        }

        private StatementSyntax GenerateWhile(int depth, Scope scope, TypeSyntax returnType, bool isAsync)
        {
            var loopVar = $"i{_variableCounter++}";
            var limit = _random.Next(2, 5); // Reduce loop count to be safe
            
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

            var loopScope = new Scope(scope);
            loopScope.AddVariable(loopVar, PredefinedType(Token(SyntaxKind.IntKeyword)));

            var body = Block(GenerateStatements(_random.Next(1, 4), depth, returnType, loopScope, isAsync));

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
                switchType = PredefinedType(Token(SyntaxKind.IntKeyword));
                switchExpr = _expressions.GenerateExpression(switchType, scope, 0, false, isAsync);
            }

            var sections = new List<SwitchSectionSyntax>();
            int cases = _random.Next(2, 4);
            var usedLabels = new HashSet<object>();

            for (int i = 0; i < cases; i++)
            {
                ExpressionSyntax constantExpr;
                object value = null;
                int attempts = 0;

                do
                {
                    constantExpr = _expressions.GenerateConstant(switchType);
                    if (constantExpr is LiteralExpressionSyntax lit)
                    {
                        value = lit.Token.Value;
                    }
                    else
                    {
                        value = constantExpr.ToString();
                    }
                    attempts++;
                } while (usedLabels.Contains(value) && attempts < 10);

                if (usedLabels.Contains(value)) continue;
                usedLabels.Add(value);

                var label = CaseSwitchLabel(constantExpr);
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
             // Fix: Use Task.CompletedTask or Task.Run to avoid timing issues.
             // Task.Yield() causes issues in some environments.

                  var awaitCompleted = AwaitExpression(
                      MemberAccessExpression(
                             SyntaxKind.SimpleMemberAccessExpression,
                             ParseTypeName("System.Threading.Tasks.Task"),
                             IdentifierName("CompletedTask")));
                  return ExpressionStatement(awaitCompleted);
        }
        
        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }
    }
}
