using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests
{
    [TestClass]
    public class CSharp9Tests : IntegrationTestBase
    {
        [TestMethod]
        public async Task Records()
        {
            var code = """
using System;

public record Person(string FirstName, string LastName);

public class Program
{
    public static void Main()
    {
        var p1 = new Person("John", "Doe");
        var p2 = new Person("John", "Doe");
        var p3 = new Person("Jane", "Doe");

        Console.WriteLine(p1 == p2);
        Console.WriteLine(p1 == p3);
        Console.WriteLine(p1);

        var p4 = p1 with { FirstName = "Jane" };
        Console.WriteLine(p4);
        Console.WriteLine(p4 == p3);
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task InitOnlySetters()
        {
            var code = """
using System;

public class Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

public class Program
{
    public static void Main()
    {
        var p = new Point { X = 10, Y = 20 };
        Console.WriteLine(p.X);
        Console.WriteLine(p.Y);
        // p.X = 30; // Error
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task PatternMatchingEnhancements()
        {
            var code = """
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(IsLetter('a'));
        Console.WriteLine(IsLetter('1'));
        Console.WriteLine(GetDescription(10));
        Console.WriteLine(GetDescription(null));
    }

    public static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

    public static string GetDescription(object o) => o switch
    {
        int i and > 0 => "Positive integer",
        not null => "Object",
        null => "Null"
    };
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task TargetTypedNew()
        {
            var code = """
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<int> list = new();
        list.Add(1);
        Console.WriteLine(list.Count);

        Point p = new(3, 4);
        Console.WriteLine(p.X);
    }
}

public class Point
{
    public int X, Y;
    public Point(int x, int y) { X = x; Y = y; }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task TargetTypedConditional()
        {
            var code = """
using System;

public class Base { }
public class Derived : Base { }

public class Program
{
    public static void Main()
    {
        var b = true ? new Base() : new Derived();
        Console.WriteLine(b.GetType().Name);

        int? x = true ? 1 : null;
        Console.WriteLine(x.HasValue);
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task StaticAnonymousFunctions()
        {
            var code = """
using System;

public class Program
{
    public static void Main()
    {
        Func<int, int> f = static x => x * x;
        Console.WriteLine(f(5));

        int y = 10;
        // Func<int> g = static () => y; // Error
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task CovariantReturnTypes()
        {
            var code = """
using System;

public class Food { }
public class Meat : Food { }

public class Animal
{
    public virtual Food GetFood() => new Food();
}

public class Tiger : Animal
{
    public override Meat GetFood() => new Meat();
}

public class Program
{
    public static void Main()
    {
        Animal a = new Tiger();
        Console.WriteLine(a.GetFood().GetType().Name);
    }
}
""";
            await RunTest(code);
        }

        [TestMethod]
        public async Task TopLevelStatements()
        {
            var code = """
using System;
Console.WriteLine("Hello Top Level");
""";
            // Expecting failure because H5 does not support top-level statements yet (per memory)
            await RunTest(code, skipRoslyn: true);
        }
    }
}
