using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class TypeManager
    {
        private readonly Random _random;

        public TypeManager(Random random)
        {
            _random = random;
        }

        public TypeSyntax GetRandomType()
        {
            int type = _random.Next(3);
            return type switch
            {
                0 => PredefinedType(Token(SyntaxKind.IntKeyword)),
                1 => PredefinedType(Token(SyntaxKind.StringKeyword)),
                2 => PredefinedType(Token(SyntaxKind.BoolKeyword)),
                _ => PredefinedType(Token(SyntaxKind.IntKeyword))
            };
        }
        
        // Helper to check if type is numeric
        public bool IsNumeric(TypeSyntax type)
        {
             return type.IsKind(SyntaxKind.PredefinedType) && ((PredefinedTypeSyntax)type).Keyword.IsKind(SyntaxKind.IntKeyword);
        }
        
        public bool IsString(TypeSyntax type)
        {
             return type.IsKind(SyntaxKind.PredefinedType) && ((PredefinedTypeSyntax)type).Keyword.IsKind(SyntaxKind.StringKeyword);
        }
        
        public bool IsBool(TypeSyntax type)
        {
             return type.IsKind(SyntaxKind.PredefinedType) && ((PredefinedTypeSyntax)type).Keyword.IsKind(SyntaxKind.BoolKeyword);
        }
    }
}
