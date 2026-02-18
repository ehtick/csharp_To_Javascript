using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public enum TypeKind
    {
        Class,
        Interface,
        Struct
    }

    public class TypeDefinition
    {
        public string Name { get; set; }
        public TypeKind Kind { get; set; }
        public TypeDefinition BaseType { get; set; }
        public TypeDefinition ParentType { get; set; }
        public List<TypeDefinition> Interfaces { get; set; } = new List<TypeDefinition>();
        public List<MethodDefinition> Methods { get; set; } = new List<MethodDefinition>();
        public List<PropertyDefinition> Properties { get; set; } = new List<PropertyDefinition>();
        public List<TypeDefinition> NestedTypes { get; set; } = new List<TypeDefinition>();

        public bool IsAbstract { get; set; }
        public bool IsGeneric { get; set; }
        public List<string> GenericParameters { get; set; } = new List<string>();

        public TypeSyntax ToTypeSyntax()
        {
            if (IsGeneric)
            {
                var args = new List<TypeSyntax>();
                // For simplicity in random generation, we might just use 'int' or 'string' as arguments
                // when referring to this type, but here we just need the name.
                // However, if we are referring to it, we need to provide arguments.
                // This method might need context or we assume Open Generic for definition
                // and Closed Generic for usage.

                // For usage, we need arguments.
                // Let's assume this method returns the definition name.
                // ToTypeSyntax is usually for Usage.

                return GenericName(Identifier(Name))
                    .WithTypeArgumentList(TypeArgumentList(SeparatedList<TypeSyntax>(
                        GenericParameters.ConvertAll(p => ParseTypeName("int")) // Placeholder
                    )));
            }
            return IdentifierName(Name);
        }

        public TypeSyntax ToTypeSyntax(List<TypeSyntax> typeArguments)
        {
            if (IsGeneric && typeArguments != null && typeArguments.Count > 0)
            {
                return GenericName(Identifier(Name))
                    .WithTypeArgumentList(TypeArgumentList(SeparatedList(typeArguments)));
            }
            return IdentifierName(Name);
        }
    }

    public class MethodDefinition
    {
        public string Name { get; set; }
        public TypeSyntax ReturnType { get; set; }
        public List<ParameterSyntax> Parameters { get; set; } = new List<ParameterSyntax>();
        public bool IsStatic { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsOverride { get; set; }
        public bool IsAsync { get; set; }

        // Helper to get ParameterList syntax
        public ParameterListSyntax GetParameterList()
        {
            return ParameterList(SeparatedList(Parameters));
        }
    }

    public class PropertyDefinition
    {
        public string Name { get; set; }
        public TypeSyntax Type { get; set; }
        public bool IsStatic { get; set; }
        public bool HasSetter { get; set; }
    }
}
