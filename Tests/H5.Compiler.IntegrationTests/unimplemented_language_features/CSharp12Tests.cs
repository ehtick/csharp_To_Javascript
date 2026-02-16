using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace H5.Compiler.IntegrationTests.UnimplementedLanguageFeatures
{
    [TestClass]
    public class CSharp12Tests : IntegrationTestBase
    {
        [TestMethod]
        public async Task PrimaryConstructors()
        {
            var code = """
using System;

public class Person(string name, int age)
{
    public string Name => name;
    public int Age => age;

    public void Print() => Console.WriteLine($"{name} is {age}");
}

public class Program
{
    public static void Main()
    {
        var p = new Person("Alice", 30);
        p.Print();
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task InlineArrays()
        {
            var code = """
using System;
using System.Runtime.CompilerServices;

[InlineArray(10)]
public struct Buffer10
{
    private int _element0;
}

public class Program
{
    public static void Main()
    {
        var buffer = new Buffer10();
        buffer[0] = 42;
        Console.WriteLine(buffer[0]);
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task ExperimentalAttribute()
        {
            var code = """
using System;
using System.Diagnostics.CodeAnalysis;

[Experimental("EXP001")]
public class ExperimentalFeature
{
    public void Run() => Console.WriteLine("Experimental");
}

public class Program
{
    // [SuppressMessage("Experimental", "EXP001")] // If suppression works
    public static void Main()
    {
        // This should generate a warning/error if not suppressed, but test checks if it compiles/runs if allowed.
        // Or if the compiler supports recognizing the attribute.
        Console.WriteLine("Experimental Attribute Test");
    }
}
""";
            await RunTest(code);
        }
    }
}
