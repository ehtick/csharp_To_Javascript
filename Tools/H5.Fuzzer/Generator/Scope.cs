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
        private List<Variable> _variables = new List<Variable>();

        public void AddVariable(string name, TypeSyntax type)
        {
            _variables.Add(new Variable { Name = name, Type = type });
        }

        public Variable GetRandomVariable(Random random)
        {
            if (_variables.Count == 0) return null;
            return _variables[random.Next(_variables.Count)];
        }
        
        public List<Variable> GetVariables() => _variables;
    }
}
