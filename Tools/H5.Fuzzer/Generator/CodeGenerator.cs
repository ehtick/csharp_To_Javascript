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
            _types.GenerateTypes(5); // Generate 5 random types

            var members = new List<MemberDeclarationSyntax>();

            // Emit types
            foreach (var typeDef in _types.AllTypes)
            {
                if (typeDef.ParentType == null)
                {
                    members.Add(GenerateTypeDeclaration(typeDef));
                }
            }

            // Generate Main Program
            var mainMethod = GenerateMainMethod();

            var depthField = FieldDeclaration(
                VariableDeclaration(PredefinedType(Token(SyntaxKind.IntKeyword)))
                .WithVariables(SingletonSeparatedList(
                    VariableDeclarator(Identifier("__depth"))
                    .WithInitializer(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)))))))
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)));

            var programClass = ClassDeclaration("Program")
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                .AddMembers(depthField, mainMethod);

            members.Add(programClass);

            var compilationUnit = CompilationUnit()
                .AddUsings(
                    UsingDirective(IdentifierName("System")),
                    UsingDirective(IdentifierName("System.Threading.Tasks")),
                    UsingDirective(IdentifierName("System.Collections.Generic")),
                    UsingDirective(IdentifierName("System.Linq"))
                )
                .AddMembers(members.ToArray())
                .NormalizeWhitespace();

            return compilationUnit.ToFullString();
        }

        private MemberDeclarationSyntax GenerateTypeDeclaration(TypeDefinition typeDef)
        {
            MemberDeclarationSyntax decl = null;

            if (typeDef.Kind == TypeKind.Class)
            {
                var classDecl = ClassDeclaration(typeDef.Name)
                    .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));

                if (typeDef.IsAbstract)
                {
                    classDecl = classDecl.AddModifiers(Token(SyntaxKind.AbstractKeyword));
                }

                if (typeDef.IsGeneric)
                {
                    classDecl = classDecl.WithTypeParameterList(TypeParameterList(SeparatedList(
                        typeDef.GenericParameters.Select(p => TypeParameter(p)))));
                }

                if (typeDef.BaseType != null)
                {
                    classDecl = classDecl.AddBaseListTypes(SimpleBaseType(_types.CreateTypeSyntax(typeDef.BaseType)));
                }

                foreach (var iface in typeDef.Interfaces)
                {
                    classDecl = classDecl.AddBaseListTypes(SimpleBaseType(_types.CreateTypeSyntax(iface)));
                }

                classDecl = classDecl.AddMembers(GenerateMembers(typeDef).ToArray());

                foreach (var nested in typeDef.NestedTypes)
                {
                    classDecl = classDecl.AddMembers(GenerateTypeDeclaration(nested));
                }

                decl = classDecl;
            }
            else if (typeDef.Kind == TypeKind.Interface)
            {
                var ifaceDecl = InterfaceDeclaration(typeDef.Name)
                    .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));

                if (typeDef.IsGeneric)
                {
                    ifaceDecl = ifaceDecl.WithTypeParameterList(TypeParameterList(SeparatedList(
                        typeDef.GenericParameters.Select(p => TypeParameter(p)))));
                }

                foreach (var iface in typeDef.Interfaces)
                {
                    ifaceDecl = ifaceDecl.AddBaseListTypes(SimpleBaseType(_types.CreateTypeSyntax(iface)));
                }

                ifaceDecl = ifaceDecl.AddMembers(GenerateMembers(typeDef).ToArray());
                decl = ifaceDecl;
            }
            else // Struct
            {
                var structDecl = StructDeclaration(typeDef.Name)
                    .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));

                if (typeDef.IsGeneric)
                {
                    structDecl = structDecl.WithTypeParameterList(TypeParameterList(SeparatedList(
                        typeDef.GenericParameters.Select(p => TypeParameter(p)))));
                }

                // Structs don't support inheritance but support interfaces
                foreach (var iface in typeDef.Interfaces)
                {
                    structDecl = structDecl.AddBaseListTypes(SimpleBaseType(_types.CreateTypeSyntax(iface)));
                }

                structDecl = structDecl.AddMembers(GenerateMembers(typeDef).ToArray());

                foreach (var nested in typeDef.NestedTypes)
                {
                    structDecl = structDecl.AddMembers(GenerateTypeDeclaration(nested));
                }

                decl = structDecl;
            }

            return decl;
        }

        private List<MemberDeclarationSyntax> GenerateMembers(TypeDefinition typeDef)
        {
            var members = new List<MemberDeclarationSyntax>();

            foreach (var prop in typeDef.Properties)
            {
                var propDecl = PropertyDeclaration(prop.Type, prop.Name);

                if (prop.ExplicitInterface != null)
                {
                    propDecl = propDecl.WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier((NameSyntax)prop.ExplicitInterface));
                    // No public modifier for explicit implementation
                }
                else if (typeDef.Kind != TypeKind.Interface)
                {
                    propDecl = propDecl.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));
                }

                if (prop.IsStatic) propDecl = propDecl.AddModifiers(Token(SyntaxKind.StaticKeyword));

                var accessors = new List<AccessorDeclarationSyntax>
                {
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
                };

                if (prop.HasSetter)
                {
                    accessors.Add(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                }

                propDecl = propDecl.WithAccessorList(AccessorList(List(accessors)));
                members.Add(propDecl);
            }

            foreach (var method in typeDef.Methods)
            {
                members.Add(_methods.GenerateMethod(method, typeDef));
            }

            return members;
        }

        private MethodDeclarationSyntax GenerateMainMethod()
        {
            var statements = new List<StatementSyntax>();
            statements.Add(ParseStatement("Console.WriteLine(\"Program Start\");"));
            
            // Generate random statements calling other methods or doing logic
            // We need a StatementGenerator here. The one in MethodGenerator is private.
            // But we can create one just for Main.
            var mainStatementGen = new StatementGenerator(_random, _types, new List<MethodDeclarationSyntax>());

            // Create a scope for main
            var mainScope = new Scope(null);

            statements.AddRange(mainStatementGen.GenerateStatements(10, 0, returnType: null, parentScope: mainScope, isAsync: true, currentMethodName: "Main"));

            statements.Add(ParseStatement("Console.WriteLine(\"Program End\");"));

            return MethodDeclaration(IdentifierName("Task"), "Main")
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword), Token(SyntaxKind.AsyncKeyword)))
                .WithBody(Block(statements));
        }
    }
}
