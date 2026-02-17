using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class ExpressionGenerator
    {
        private readonly Random _random;
        private readonly TypeManager _types;
        private readonly List<MethodDeclarationSyntax> _methods;

        public ExpressionGenerator(Random random, TypeManager types, List<MethodDeclarationSyntax> methods)
        {
            _random = random;
            _types = types;
            _methods = methods;
        }

        public ExpressionSyntax GenerateConstant(TypeSyntax targetType)
        {
            return GenerateLiteral(targetType);
        }

        public ExpressionSyntax GenerateExpression(TypeSyntax targetType, Scope scope, int depth = 0, bool forceBool = false, bool isAsync = false)
        {
            if (forceBool) targetType = PredefinedType(Token(SyntaxKind.BoolKeyword));

            if (depth > 3)
            {
                return GenerateSimple(targetType, scope);
            }

            int type = _random.Next(5);
            
            if (type == 1 && scope.GetVariables().FirstOrDefault(v => AreTypesEquivalent(v.Type, targetType)) == null) type = 0;
            if (type == 3 && !_methods.Any(m => AreTypesEquivalent(m.ReturnType, targetType))) type = 0;
            if (type == 4 && !isAsync) type = 0;

            switch (type)
            {
                case 0: return GenerateLiteral(targetType);
                case 1: return GenerateVariable(targetType, scope);
                case 2: return GenerateBinary(targetType, scope, depth, isAsync);
                case 3: return GenerateMethodCall(targetType, scope, depth, isAsync);
                case 4: return GenerateAwaitExpression(targetType, scope, depth, isAsync);
                default: return GenerateLiteral(targetType);
            }
        }

        private ExpressionSyntax GenerateSimple(TypeSyntax targetType, Scope scope)
        {
            if (_random.NextDouble() < 0.5) return GenerateLiteral(targetType);
            var variable = scope.GetVariables().FirstOrDefault(v => AreTypesEquivalent(v.Type, targetType));
            if (variable != null)
            {
                return IdentifierName(variable.Name);
            }
            return GenerateLiteral(targetType);
        }

        private ExpressionSyntax GenerateLiteral(TypeSyntax targetType)
        {
            if (_types.IsNumeric(targetType))
            {
                return LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(_random.Next(0, 100)));
            }
            if (_types.IsString(targetType))
            {
                return LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(Guid.NewGuid().ToString().Substring(0, 8)));
            }
            if (_types.IsBool(targetType))
            {
                return LiteralExpression(_random.Next(2) == 0 ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression);
            }
            if (_types.IsTask(targetType))
            {
                if (targetType is GenericNameSyntax gen)
                {
                    var inner = gen.TypeArgumentList.Arguments[0];
                    return InvocationExpression(
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Task"), IdentifierName("FromResult")))
                        .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(GenerateLiteral(inner)))));
                }
                else
                {
                    return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Task"), IdentifierName("CompletedTask"));
                }
            }
            return LiteralExpression(SyntaxKind.DefaultLiteralExpression);
        }

        private ExpressionSyntax GenerateVariable(TypeSyntax targetType, Scope scope)
        {
             var vars = scope.GetVariables().Where(v => AreTypesEquivalent(v.Type, targetType)).ToList();
             if (vars.Count > 0)
             {
                 return IdentifierName(vars[_random.Next(vars.Count)].Name);
             }
             return GenerateLiteral(targetType);
        }

        private ExpressionSyntax GenerateBinary(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
             if (_types.IsNumeric(targetType))
             {
                 var left = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                 var right = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                 var op = _random.Next(3); // +, -, *
                 var kind = op switch
                 {
                     0 => SyntaxKind.AddExpression,
                     1 => SyntaxKind.SubtractExpression,
                     2 => SyntaxKind.MultiplyExpression,
                     _ => SyntaxKind.AddExpression
                 };
                 return BinaryExpression(kind, ParenthesizedExpression(left), ParenthesizedExpression(right));
             }
             else if (_types.IsBool(targetType))
             {
                 if (_random.NextDouble() < 0.5)
                 {
                     var operandType = _types.GetRandomType(); 
                     // Ensure numeric comparison if types are numeric, otherwise equality
                     // But we need to ensure left and right match types.
                     
                     var left = GenerateExpression(operandType, scope, depth + 1, false, isAsync);
                     var right = GenerateExpression(operandType, scope, depth + 1, false, isAsync);
                     
                     if (_types.IsNumeric(operandType)) {
                         return BinaryExpression(SyntaxKind.LessThanExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
                     } else {
                         return BinaryExpression(SyntaxKind.EqualsExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
                     }
                 }
                 else
                 {
                     var left = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                     var right = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                     return BinaryExpression(SyntaxKind.LogicalAndExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
                 }
             }
             else if (_types.IsString(targetType))
             {
                 var left = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                 var right = GenerateExpression(targetType, scope, depth + 1, false, isAsync);
                 return BinaryExpression(SyntaxKind.AddExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
             }
             return GenerateLiteral(targetType);
        }

        private ExpressionSyntax GenerateMethodCall(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
            var candidates = _methods.Where(m => AreTypesEquivalent(m.ReturnType, targetType)).ToList();
            if (candidates.Count == 0) return GenerateLiteral(targetType);

            var method = candidates[_random.Next(candidates.Count)];
            var args = new List<ArgumentSyntax>();
            
            foreach (var param in method.ParameterList.Parameters)
            {
                args.Add(Argument(GenerateExpression(param.Type, scope, depth + 1, false, isAsync)));
            }

            return InvocationExpression(IdentifierName(method.Identifier))
                .WithArgumentList(ArgumentList(SeparatedList(args)));
        }

        private ExpressionSyntax GenerateAwaitExpression(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
            // We need an expression of type Task<targetType> or Task if targetType is void (but here targetType is usually variable type)
            // If targetType is valid type T, we need Task<T>.

            var taskType = GenericName(Identifier("Task"))
                .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList(targetType)));

            // Recursively generate an expression of that task type
            var taskExpr = GenerateExpression(taskType, scope, depth + 1, false, isAsync);

            return AwaitExpression(taskExpr);
        }
        
        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }
    }
}
