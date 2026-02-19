using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class MethodGenerator
    {
        private readonly Random _random;
        private readonly TypeManager _types;
        private readonly StatementGenerator _statements;

        public MethodGenerator(Random random, TypeManager types)
        {
            _random = random;
            _types = types;
            // We pass null for methods list initially, as we rely on TypeManager for available types/methods
            // However StatementGenerator still expects List<MethodDeclarationSyntax>.
            // We will fix StatementGenerator later. For now, passing empty list.
            _statements = new StatementGenerator(random, types, new List<MethodDeclarationSyntax>());
        }

        public MethodDeclarationSyntax GenerateMethod(MethodDefinition methodDef, TypeDefinition enclosingType)
        {
            var returnType = methodDef.ReturnType;

            // Build modifiers
            var modifiers = TokenList();
            if (methodDef.ExplicitInterface == null && enclosingType.Kind != TypeKind.Interface)
            {
                modifiers = modifiers.Add(Token(SyntaxKind.PublicKeyword));
            }

            if (methodDef.IsStatic) modifiers = modifiers.Add(Token(SyntaxKind.StaticKeyword));
            if (methodDef.IsAbstract && enclosingType.Kind != TypeKind.Interface) modifiers = modifiers.Add(Token(SyntaxKind.AbstractKeyword));
            if (methodDef.IsVirtual) modifiers = modifiers.Add(Token(SyntaxKind.VirtualKeyword));
            if (methodDef.IsOverride) modifiers = modifiers.Add(Token(SyntaxKind.OverrideKeyword));

            // Only add async if we are generating a body
            bool hasBody = !methodDef.IsAbstract && enclosingType.Kind != TypeKind.Interface;
            if (methodDef.IsAsync && hasBody) modifiers = modifiers.Add(Token(SyntaxKind.AsyncKeyword));

            // Parameters
            // Note: We need to ensure parameter types are valid. MethodDefinition already has them.

            // Body
            BlockSyntax body = null;
            if (!methodDef.IsAbstract && enclosingType.Kind != TypeKind.Interface)
            {
                // Create initial scope with parameters
                var parameterVars = new List<Variable>();
                foreach (var p in methodDef.Parameters)
                {
                    parameterVars.Add(new Variable { Name = p.Identifier.Text, Type = p.Type });
                }

                var initialScope = new Scope(null);
                foreach (var v in parameterVars) initialScope.AddVariable(v.Name, v.Type);

                // Add 'this' if instance method
                if (!methodDef.IsStatic)
                {
                    initialScope.AddVariable("this", _types.CreateTypeSyntax(enclosingType, useGenericParams: true));
                }

                var bodyReturnType = returnType;
                if (methodDef.IsAsync)
                {
                    bodyReturnType = _types.GetUnwrappedTaskType(returnType);
                }

                body = Block(_statements.GenerateStatements(5, 0, bodyReturnType, initialScope, methodDef.IsAsync, methodDef.Name));

                // Add depth protection
                var returnStatement = GenerateDefaultReturn(returnType, methodDef.IsAsync);

                var checkDepth = IfStatement(
                    BinaryExpression(
                        SyntaxKind.GreaterThanExpression,
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Program"), IdentifierName("__depth")),
                        LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(50))),
                    returnStatement);

                var increment = ExpressionStatement(
                    PostfixUnaryExpression(
                        SyntaxKind.PostIncrementExpression,
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Program"), IdentifierName("__depth"))));

                var decrement = ExpressionStatement(
                    PostfixUnaryExpression(
                        SyntaxKind.PostDecrementExpression,
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Program"), IdentifierName("__depth"))));

                var tryFinally = TryStatement(
                    body,
                    List<CatchClauseSyntax>(),
                    FinallyClause(Block(decrement)));

                body = Block(checkDepth, increment, tryFinally);
            }

            var methodDecl = MethodDeclaration(returnType, methodDef.Name)
                .WithModifiers(modifiers)
                .WithParameterList(methodDef.GetParameterList());

            if (methodDef.ExplicitInterface != null)
            {
                methodDecl = methodDecl.WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier((NameSyntax)methodDef.ExplicitInterface));
            }

            if (body != null)
            {
                methodDecl = methodDecl.WithBody(body);
            }
            else
            {
                methodDecl = methodDecl.WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
            }

            return methodDecl;
        }

        private StatementSyntax GenerateDefaultReturn(TypeSyntax returnType, bool isAsync)
        {
            if (isAsync)
            {
                // In async method, return logic:
                // If return type is Task (void-like), simply return;
                // If return type is Task<T>, return default(T);
                if (AreTypesEquivalent(returnType, ParseTypeName("System.Threading.Tasks.Task")) ||
                    AreTypesEquivalent(returnType, IdentifierName("Task")))
                {
                    return ReturnStatement();
                }

                // Try to extract T from Task<T>
                var innerType = _types.GetUnwrappedTaskType(returnType);
                if (AreTypesEquivalent(innerType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
                {
                    // If extraction failed or it's void task
                    return ReturnStatement();
                }

                return ReturnStatement(DefaultExpression(innerType));
            }
            else
            {
                if (AreTypesEquivalent(returnType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
                {
                    return ReturnStatement();
                }

                // If sync method returning Task, return Task.CompletedTask or FromResult
                if (_types.IsTask(returnType))
                {
                    var innerType = _types.GetUnwrappedTaskType(returnType);
                     if (AreTypesEquivalent(innerType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
                     {
                         return ReturnStatement(
                             MemberAccessExpression(
                                 SyntaxKind.SimpleMemberAccessExpression,
                                 ParseTypeName("System.Threading.Tasks.Task"),
                                 IdentifierName("CompletedTask")));
                     }
                     else
                     {
                         return ReturnStatement(
                             InvocationExpression(
                                 MemberAccessExpression(
                                     SyntaxKind.SimpleMemberAccessExpression,
                                     ParseTypeName("System.Threading.Tasks.Task"),
                                     IdentifierName("FromResult")))
                                 .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(DefaultExpression(innerType))))));
                     }
                }

                return ReturnStatement(DefaultExpression(returnType));
            }
        }

        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }

        // Keep this for backward compatibility or simple tests if needed, but updated to use new logic
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

            // Create a fake MethodDefinition
            var def = new MethodDefinition
            {
                Name = name,
                ReturnType = returnType,
                IsStatic = true,
                IsAsync = isAsync
            };

            // Generate random parameters
            int count = _random.Next(0, 3);
            for (int i = 0; i < count; i++)
            {
                def.Parameters.Add(Parameter(Identifier($"p{i}")).WithType(_types.GetRandomType()));
            }

            // Fake enclosing type for static method
            var enclosing = new TypeDefinition { Name = "Program", Kind = TypeKind.Class };

            return GenerateMethod(def, enclosing);
        }
    }
}
