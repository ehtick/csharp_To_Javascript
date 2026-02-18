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

        // We don't need _methods list anymore as methods are on types.

        public ExpressionGenerator(Random random, TypeManager types)
        {
            _random = random;
            _types = types;
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

            int type = _random.Next(6); // Increased options
            
            // Constraints
            if (type == 1 && scope.GetVariables().FirstOrDefault(v => AreTypesEquivalent(v.Type, targetType)) == null) type = 0; // Variable
            if (type == 3 && !CanCallMethod(targetType, scope)) type = 0; // Method call
            if (type == 4 && !isAsync) type = 0; // Await
            if (type == 5 && !CanInstantiate(targetType)) type = 0; // Object creation

            switch (type)
            {
                case 0: return GenerateLiteral(targetType);
                case 1: return GenerateVariable(targetType, scope);
                case 2: return GenerateBinary(targetType, scope, depth, isAsync);
                case 3: return GenerateMethodCall(targetType, scope, depth, isAsync);
                case 4: return GenerateAwaitExpression(targetType, scope, depth, isAsync);
                case 5: return GenerateObjectCreation(targetType, scope, depth, isAsync);
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
                 // Return completed task
                if (targetType is GenericNameSyntax gen)
                {
                    var inner = gen.TypeArgumentList.Arguments[0];
                    return InvocationExpression(
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ParseTypeName("System.Threading.Tasks.Task"), IdentifierName("FromResult")))
                        .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(GenerateLiteral(inner)))));
                }
                else
                {
                    return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ParseTypeName("System.Threading.Tasks.Task"), IdentifierName("CompletedTask"));
                }
            }

            // For custom types, try to instantiate or return default
            if (CanInstantiate(targetType))
            {
                 // Create a simple instance with no initializer to avoid recursion loops
                 return ObjectCreationExpression(targetType).WithArgumentList(ArgumentList());
            }

            return DefaultExpression(targetType);
        }

        private ExpressionSyntax GenerateVariable(TypeSyntax targetType, Scope scope)
        {
             var vars = scope.GetVariables().Where(v => AreTypesEquivalent(v.Type, targetType)).ToList();
             if (vars.Count > 0)
             {
                 // Also consider property access on available variables?
                 // Handled in GenerateMethodCall/MemberAccess logic usually but simple variable access is just name.
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
                     
                     var left = GenerateExpression(operandType, scope, depth + 1, false, isAsync);
                     var right = GenerateExpression(operandType, scope, depth + 1, false, isAsync);
                     
                     if (_types.IsNumeric(operandType)) {
                         return BinaryExpression(SyntaxKind.LessThanExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
                     } else if (!_types.IsStruct(operandType)) {
                         return BinaryExpression(SyntaxKind.EqualsExpression, ParenthesizedExpression(left), ParenthesizedExpression(right));
                     } else {
                         return LiteralExpression(SyntaxKind.TrueLiteralExpression); // Fallback for structs
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

        private bool CanCallMethod(TypeSyntax targetType, Scope scope)
        {
            // We need to find a method that returns targetType
            // It can be a static method on any type
            // Or an instance method on a variable in scope

            // Check static methods
            foreach(var t in _types.AllTypes)
            {
                 foreach(var m in t.Methods.Where(m => m.IsStatic && AreTypesEquivalent(m.ReturnType, targetType))) return true;
            }

            // Check instance methods
            foreach(var v in scope.GetVariables())
            {
                 var t = _types.GetTypeDefinition(v.Type);
                 if (t != null)
                 {
                      foreach(var m in t.Methods.Where(m => !m.IsStatic && AreTypesEquivalent(m.ReturnType, targetType))) return true;

                      // Also properties
                      foreach(var p in t.Properties.Where(p => !p.IsStatic && AreTypesEquivalent(p.Type, targetType))) return true;
                 }
            }

            return false;
        }

        private ExpressionSyntax GenerateMethodCall(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
            // Gather candidates
            var candidates = new List<(ExpressionSyntax Target, string Name, List<ParameterSyntax> Params)>();

            // Static methods
            foreach(var t in _types.AllTypes)
            {
                foreach(var m in t.Methods.Where(m => m.IsStatic && AreTypesEquivalent(m.ReturnType, targetType)))
                {
                    candidates.Add((_types.CreateTypeSyntax(t), m.Name, m.Parameters));
                }
                // Static properties
                foreach(var p in t.Properties.Where(p => p.IsStatic && AreTypesEquivalent(p.Type, targetType)))
                {
                    candidates.Add((_types.CreateTypeSyntax(t), p.Name, null)); // null params means property
                }
            }

            // Instance methods/props
            foreach(var v in scope.GetVariables())
            {
                var t = _types.GetTypeDefinition(v.Type);
                if (t != null)
                {
                     // Recursively get members including base types?
                     // Currently TypeDefinition doesn't flatten members.
                     // But we can check methods on t directly. Inheritance support would need traversal.
                     // For simplicity, just check direct members for now.

                     foreach(var m in t.Methods.Where(m => !m.IsStatic && m.ExplicitInterface == null && AreTypesEquivalent(m.ReturnType, targetType)))
                     {
                         candidates.Add((IdentifierName(v.Name), m.Name, m.Parameters));
                     }
                     foreach(var p in t.Properties.Where(p => !p.IsStatic && p.ExplicitInterface == null && AreTypesEquivalent(p.Type, targetType)))
                     {
                         candidates.Add((IdentifierName(v.Name), p.Name, null));
                     }
                }
            }

            if (candidates.Count == 0) return GenerateLiteral(targetType);

            var candidate = candidates[_random.Next(candidates.Count)];
            
            if (candidate.Params == null) // Property
            {
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, candidate.Target, IdentifierName(candidate.Name));
            }
            else // Method
            {
                var args = new List<ArgumentSyntax>();
                foreach (var param in candidate.Params)
                {
                    args.Add(Argument(GenerateExpression(param.Type, scope, depth + 1, false, isAsync)));
                }

                return InvocationExpression(
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, candidate.Target, IdentifierName(candidate.Name)))
                    .WithArgumentList(ArgumentList(SeparatedList(args)));
            }
        }

        private bool CanInstantiate(TypeSyntax type)
        {
            var t = _types.GetTypeDefinition(type);
            return t != null && t.Kind != TypeKind.Interface && !t.IsAbstract;
        }

        private ExpressionSyntax GenerateObjectCreation(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
            var t = _types.GetTypeDefinition(targetType);
            if (t == null) return GenerateLiteral(targetType);

            // Build substitution map if generic
            var typeMap = new Dictionary<string, TypeSyntax>();
            if (t.IsGeneric && targetType is GenericNameSyntax gen)
            {
                for (int i = 0; i < Math.Min(t.GenericParameters.Count, gen.TypeArgumentList.Arguments.Count); i++)
                {
                    typeMap[t.GenericParameters[i]] = gen.TypeArgumentList.Arguments[i];
                }
            }

            // Object initializer
            var initializers = new List<ExpressionSyntax>();

            // Pick some properties to initialize
            var writableProps = t.Properties.Where(p => !p.IsStatic && p.HasSetter).ToList();
            if (writableProps.Count > 0 && _random.NextDouble() < 0.5)
            {
                int count = _random.Next(1, Math.Min(3, writableProps.Count) + 1);
                // Shuffle
                writableProps = writableProps.OrderBy(x => _random.Next()).ToList();

                for(int i=0; i<count; i++)
                {
                    var p = writableProps[i];
                    var propType = _types.SubstituteType(p.Type, typeMap);

                    var val = GenerateExpression(propType, scope, depth + 1, false, isAsync);
                    initializers.Add(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            IdentifierName(p.Name),
                            val
                        ));
                }
            }

            var creation = ObjectCreationExpression(targetType).WithArgumentList(ArgumentList());

            if (initializers.Count > 0)
            {
                creation = creation.WithInitializer(InitializerExpression(
                    SyntaxKind.ObjectInitializerExpression,
                    SeparatedList(initializers)));
            }

            return creation;
        }

        private ExpressionSyntax GenerateAwaitExpression(TypeSyntax targetType, Scope scope, int depth, bool isAsync)
        {
            // We need a Task<targetType>
            var taskType = GenericName(Identifier("Task"))
                .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList(targetType)));

            var taskExpr = GenerateExpression(taskType, scope, depth + 1, false, isAsync);
            return AwaitExpression(taskExpr);
        }
        
        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }
    }
}
