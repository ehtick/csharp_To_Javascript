using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace H5.Fuzzer.Generator
{
    public class TypeManager
    {
        private readonly Random _random;
        public List<TypeDefinition> AllTypes { get; } = new List<TypeDefinition>();
        private int _typeCounter = 0;

        public TypeManager(Random random)
        {
            _random = random;
        }

        public void GenerateTypes(int count)
        {
            // Pass 1: Create stubs
            for (int i = 0; i < count; i++)
            {
                var typeDef = new TypeDefinition
                {
                    Name = $"Type_{_typeCounter++}",
                    Kind = (TypeKind)_random.Next(3) // 0=Class, 1=Interface, 2=Struct
                };

                // Generics
                if (_random.NextDouble() < 0.3)
                {
                    typeDef.IsGeneric = true;
                    int paramCount = _random.Next(1, 3);
                    for (int j = 0; j < paramCount; j++)
                    {
                        typeDef.GenericParameters.Add($"T{j}");
                    }
                }

                AllTypes.Add(typeDef);
            }

            // Pass 2: Populate details
            for (int i = 0; i < AllTypes.Count; i++)
            {
                PopulateType(AllTypes[i], i);
            }

            // Pass 3: Nesting
            int nestCount = AllTypes.Count / 5;
            for (int i = 0; i < nestCount; i++)
            {
                var child = AllTypes[_random.Next(AllTypes.Count)];
                if (child.ParentType != null) continue; // Already nested

                // Find a parent
                var parent = AllTypes[_random.Next(AllTypes.Count)];
                if (parent == child) continue;
                if (parent.Kind == TypeKind.Interface) continue; // Interfaces can't have nested types in C# < 8? Actually they can in recent C# but maybe H5 limits it?
                // Let's avoid nesting in interfaces for now.

                // Avoid cycles: parent should not be child
                // Avoid deep nesting: parent should not be nested (depth 1)
                if (parent.ParentType != null) continue;

                // Also check inheritance cycles?
                // If Parent inherits from Child, we can't nest Child in Parent?
                // Actually C# allows: class P : C { class C {} } -> Error: 'P' introduces 'C' which is already defined... wait.
                // class P : C {} class C { class Nested {} } -> Fine.
                // class P { class C : P {} } -> Fine.

                child.ParentType = parent;
                parent.NestedTypes.Add(child);
            }
        }

        private void PopulateType(TypeDefinition typeDef, int index)
        {
            // Inheritance
            if (typeDef.Kind == TypeKind.Class)
            {
                if (_random.NextDouble() < 0.3) typeDef.IsAbstract = true;

                // Pick a base class
                var possibleBases = AllTypes.Take(index)
                    .Where(t => t.Kind == TypeKind.Class && !t.IsGeneric && !t.Name.Contains("Struct") && !t.IsAbstract)
                    .ToList();

                if (possibleBases.Count > 0 && _random.NextDouble() < 0.5)
                {
                     typeDef.BaseType = possibleBases[_random.Next(possibleBases.Count)];
                }

                // Interfaces
                var possibleInterfaces = AllTypes.Where(t => t.Kind == TypeKind.Interface && !t.IsGeneric).ToList();
                int ifaceCount = _random.Next(0, 3);
                for (int k = 0; k < ifaceCount; k++)
                {
                    if (possibleInterfaces.Count == 0) break;
                    var iface = possibleInterfaces[_random.Next(possibleInterfaces.Count)];
                    if (!typeDef.Interfaces.Contains(iface))
                    {
                        typeDef.Interfaces.Add(iface);
                    }
                }
            }
            else if (typeDef.Kind == TypeKind.Interface)
            {
                 // Interface inheritance
                var possibleInterfaces = AllTypes.Take(index)
                    .Where(t => t.Kind == TypeKind.Interface && !t.IsGeneric).ToList();

                if (possibleInterfaces.Count > 0 && _random.NextDouble() < 0.3)
                {
                     var baseIface = possibleInterfaces[_random.Next(possibleInterfaces.Count)];
                     typeDef.Interfaces.Add(baseIface);
                }
            }
            else // Struct
            {
                // Structs implement interfaces
                // Filter interfaces that would cause cycles (i.e. interface has property of this struct type or later struct type)
                var possibleInterfaces = AllTypes.Where(t => t.Kind == TypeKind.Interface && !t.IsGeneric).ToList();

                possibleInterfaces = possibleInterfaces.Where(iface => {
                    return !iface.Properties.Any(p => {
                        var pDef = GetTypeDefinition(p.Type);
                        if (pDef != null && pDef.Kind == TypeKind.Struct)
                        {
                            // If property is struct, it must be defined BEFORE current struct
                            return AllTypes.IndexOf(pDef) >= index;
                        }
                        return false;
                    });
                }).ToList();

                 if (possibleInterfaces.Count > 0 && _random.NextDouble() < 0.3)
                {
                     var iface = possibleInterfaces[_random.Next(possibleInterfaces.Count)];
                     typeDef.Interfaces.Add(iface);
                }
            }

            // Members
            GenerateMembers(typeDef, index);
        }

        private void GenerateMembers(TypeDefinition typeDef, int index)
        {
            var usedNames = new HashSet<string>();

            // First, implement interface members
            foreach (var iface in typeDef.Interfaces)
            {
                foreach (var method in iface.Methods)
                {
                    // Copy method signature
                    var impl = new MethodDefinition
                    {
                        Name = method.Name,
                        ReturnType = CloneType(method.ReturnType),
                        Parameters = method.Parameters.Select(CloneParameter).ToList(),
                        IsStatic = false,
                        IsAbstract = false,
                        IsVirtual = false,
                        IsOverride = false,
                        IsAsync = method.IsAsync // Should match? Interface methods usually sync in this generator
                    };
                    typeDef.Methods.Add(impl);
                    usedNames.Add(impl.Name);
                }

                foreach (var prop in iface.Properties)
                {
                    var impl = new PropertyDefinition
                    {
                        Name = prop.Name,
                        Type = CloneType(prop.Type),
                        IsStatic = false,
                        HasSetter = prop.HasSetter
                    };
                    typeDef.Properties.Add(impl);
                    usedNames.Add(impl.Name);
                }
            }

            int memberCount = _random.Next(1, 5);
            for (int i = 0; i < memberCount; i++)
            {
                string name;
                bool isProp = _random.NextDouble() < 0.5;
                int suffix = i;
                do
                {
                    name = (isProp ? "Prop_" : "Method_") + suffix;
                    suffix++;
                } while (usedNames.Contains(name));
                usedNames.Add(name);

                // Property
                if (isProp)
                {
                    var type = GetRandomType();
                    // Ensure acyclic structs
                    if (typeDef.Kind == TypeKind.Struct)
                    {
                        var pDef = GetTypeDefinition(type);
                        if (pDef != null && pDef.Kind == TypeKind.Struct && AllTypes.IndexOf(pDef) >= index)
                        {
                            // Cycle risk, pick safe type (primitive)
                            type = PredefinedType(Token(SyntaxKind.IntKeyword));
                        }
                    }

                    var prop = new PropertyDefinition
                    {
                        Name = name,
                        Type = type,
                        IsStatic = typeDef.Kind != TypeKind.Interface && _random.NextDouble() < 0.2,
                        HasSetter = _random.NextDouble() < 0.8
                    };
                    typeDef.Properties.Add(prop);
                }
                else // Method
                {
                    var method = new MethodDefinition
                    {
                        Name = name,
                        ReturnType = GetRandomType(allowVoid: true),
                        IsStatic = typeDef.Kind != TypeKind.Interface && _random.NextDouble() < 0.2,
                        IsAsync = _random.NextDouble() < 0.2
                    };

                    if (method.IsAsync)
                    {
                         if (AreTypesEquivalent(method.ReturnType, PredefinedType(Token(SyntaxKind.VoidKeyword))))
                         {
                             method.ReturnType = IdentifierName("Task");
                         }
                         else if (!IsTask(method.ReturnType))
                         {
                             method.ReturnType = GenericName(Identifier("Task"))
                                 .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList(method.ReturnType)));
                         }
                    }

                    int paramCount = _random.Next(0, 4);
                    for(int p=0; p<paramCount; p++)
                    {
                        method.Parameters.Add(Parameter(Identifier($"p{p}")).WithType(GetRandomType()));
                    }

                    if (typeDef.Kind == TypeKind.Interface)
                    {
                        method.IsAbstract = true;
                        method.IsStatic = false;
                        method.IsAsync = false;
                    }
                    else if (typeDef.Kind == TypeKind.Class && !method.IsStatic)
                    {
                         if (typeDef.IsAbstract && _random.NextDouble() < 0.3)
                         {
                             method.IsAbstract = true;
                         }
                         else if (_random.NextDouble() < 0.3)
                         {
                             method.IsVirtual = true;
                         }
                    }

                    typeDef.Methods.Add(method);
                }
            }
        }

        public TypeSyntax GetRandomType(bool allowVoid = false)
        {
            if (allowVoid && _random.NextDouble() < 0.1) return PredefinedType(Token(SyntaxKind.VoidKeyword));

            // 50% chance to return a primitive, 50% chance to return a generated type (if any)
            if (AllTypes.Count > 0 && _random.NextDouble() < 0.5)
            {
                var typeDef = AllTypes[_random.Next(AllTypes.Count)];
                return CreateTypeSyntax(typeDef);
            }

            return GetRandomPrimitive();
        }

        public TypeSyntax CreateTypeSyntax(TypeDefinition typeDef)
        {
             // 1. Generate local type syntax (Identifier or Generic)
             SimpleNameSyntax local;
             if (typeDef.IsGeneric)
             {
                 var args = new List<TypeSyntax>();
                 foreach(var p in typeDef.GenericParameters) args.Add(GetRandomPrimitive());
                 local = GenericName(Identifier(typeDef.Name)).WithTypeArgumentList(TypeArgumentList(SeparatedList(args)));
             }
             else
             {
                 local = IdentifierName(typeDef.Name);
             }

             // 2. Qualify if nested
             if (typeDef.ParentType != null)
             {
                 var parentSyntax = CreateTypeSyntax(typeDef.ParentType);
                 // parentSyntax might be IdentifierName or GenericName or QualifiedName (if deeply nested)
                 // We need to append local.
                 return QualifiedName((NameSyntax)parentSyntax, local);
             }

             return local;
        }

        private TypeSyntax GetRandomPrimitive()
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

        public TypeSyntax GetRandomTaskType()
        {
            // Either Task or Task<T>
            if (_random.NextDouble() < 0.3) return ParseTypeName("System.Threading.Tasks.Task");
            return GenericName(Identifier("System.Threading.Tasks.Task")).WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList(GetRandomType())));
        }

        public TypeSyntax GetRandomExceptionType()
        {
             var exceptions = new[] { "Exception", "InvalidOperationException", "ArgumentException", "NullReferenceException" };
            return IdentifierName(exceptions[_random.Next(exceptions.Length)]);
        }

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

        public bool IsStruct(TypeSyntax type)
        {
            var def = GetTypeDefinition(type);
            return def != null && def.Kind == TypeKind.Struct;
        }

        public bool IsTask(TypeSyntax type)
        {
            if (type is IdentifierNameSyntax id && id.Identifier.Text == "Task") return true;
            if (type is GenericNameSyntax gen && gen.Identifier.Text == "Task") return true;
            return false;
        }

        public TypeSyntax GetUnwrappedTaskType(TypeSyntax type)
        {
             if (type is GenericNameSyntax gen && gen.Identifier.Text == "Task")
            {
                return gen.TypeArgumentList.Arguments[0];
            }
            if (type is IdentifierNameSyntax id && id.Identifier.Text == "Task")
            {
                return PredefinedType(Token(SyntaxKind.VoidKeyword));
            }
            return type;
        }

        public TypeDefinition GetTypeDefinition(TypeSyntax type)
        {
            string name = null;
            if (type is IdentifierNameSyntax id) name = id.Identifier.Text;
            else if (type is GenericNameSyntax gen) name = gen.Identifier.Text;

            if (name == null) return null;
            return AllTypes.FirstOrDefault(t => t.Name == name);
        }

        private bool AreTypesEquivalent(TypeSyntax t1, TypeSyntax t2)
        {
             return SyntaxFactory.AreEquivalent(t1, t2);
        }

        private TypeSyntax CloneType(TypeSyntax type)
        {
            // Simple clone via parsing text - robust enough for this purpose
            if (type == null) return null;
            // Or manual reconstruction
            if (type is IdentifierNameSyntax id) return IdentifierName(id.Identifier);
            if (type is PredefinedTypeSyntax pre) return PredefinedType(pre.Keyword);
            if (type is GenericNameSyntax gen)
            {
                var newArgs = gen.TypeArgumentList.Arguments.Select(CloneType).ToList();
                return GenericName(gen.Identifier).WithTypeArgumentList(TypeArgumentList(SeparatedList(newArgs)));
            }
            if (type is QualifiedNameSyntax q)
            {
                return QualifiedName((NameSyntax)CloneType(q.Left), (SimpleNameSyntax)CloneType(q.Right));
            }
            // Fallback
            return ParseTypeName(type.ToString());
        }

        private ParameterSyntax CloneParameter(ParameterSyntax p)
        {
            return Parameter(p.Identifier).WithType(CloneType(p.Type));
        }
    }
}
