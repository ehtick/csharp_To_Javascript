using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.CodeAnalysis;

namespace H5.Fuzzer.Generator
{
    public class Variable
    {
        public string Name { get; set; }
        public TypeSyntax Type { get; set; }
    }

    public class Scope
    {
        private readonly List<Variable> _variables = new List<Variable>();
        private readonly Scope _parent;

        public Scope(Scope parent = null)
        {
            _parent = parent;
        }

        public Scope(IEnumerable<Variable> variables, Scope parent = null) : this(parent)
        {
            if (variables != null)
                _variables.AddRange(variables);
        }

        public void AddVariable(string name, TypeSyntax type)
        {
            _variables.Add(new Variable { Name = name, Type = type });
        }

        public Variable GetRandomVariable(Random random)
        {
            var all = GetVariables();
            if (all.Count == 0) return null;
            return all[random.Next(all.Count)];
        }
        
        public List<Variable> GetVariables()
        {
            var list = new List<Variable>(_variables);
            if (_parent != null)
            {
                list.AddRange(_parent.GetVariables());
            }
            return list;
        }
    }
}
