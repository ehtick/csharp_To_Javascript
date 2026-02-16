using System;
using System.Threading.Tasks;
using H5.Compiler.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.unimplemented_language_features
{
    [TestClass]
    public class PatternMatchingStressTests : IntegrationTestBase
    {
        [TestMethod]
        public async Task DeepTupleNestingSwitch()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Test((1, (2, 3))));
        Console.WriteLine(Test((10, (20, 30))));
    }

    static string Test((int, (int, int)) input)
    {
        return input switch
        {
            (1, (var a, var b)) => $""Matched 1: {a}, {b}"",
            (var x, (var y, var z)) => $""Matched Other: {x}, {y}, {z}"",
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task VariableReuseInSwitchArms()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Test((1, 100)));
        Console.WriteLine(Test((2, 200)));
        Console.WriteLine(Test((3, 300)));
    }

    static int Test((int code, int val) input)
    {
        return input switch
        {
            (1, var x) => x,
            (2, var x) => x * 2,
            (_, var x) => 0
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        [Ignore("Fails with 'Unexpected symbol ?' likely due to issue generating type syntax for slice var")]
        public async Task ListPatternWithSliceAndVar()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Test(new[] { 1, 2, 3, 4, 5 }));
        Console.WriteLine(Test(new[] { 1, 9, 5 }));
        Console.WriteLine(Test(new[] { 0 }));
    }

    static string Test(int[] input)
    {
        return input switch
        {
            [1, .. var middle, 5] => $""Starts 1, Ends 5, Middle Length: {middle.Length}"",
            [var first, .. var rest] => $""First: {first}, Rest Length: {rest.Length}"",
            [] => ""Empty""
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task RecursivePropertyPatternWithVar()
        {
            var csharpCode = @"
using System;

public class Program
{
    public class Inner { public int Val { get; set; } }
    public class Outer { public Inner In { get; set; } }

    public static void Main()
    {
        Console.WriteLine(Test(new Outer { In = new Inner { Val = 42 } }));
        Console.WriteLine(Test(new Outer { In = null }));
        Console.WriteLine(Test(null));
    }

    static string Test(Outer o)
    {
        return o switch
        {
            { In: { Val: var v } } => $""Value: {v}"",
            { In: null } => ""Inner is null"",
            null => ""Outer is null""
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task MixedPositionalAndProperty()
        {
            var csharpCode = @"
using System;
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

public class Program
{
    public record Point(int X, int Y);

    public static void Main()
    {
        Console.WriteLine(Test(new Point(1, 2)));
        Console.WriteLine(Test(new Point(10, 20)));
    }

    static string Test(Point p)
    {
        return p switch
        {
            (1, var y) => $""X is 1, Y is {y}"",
            { X: var x, Y: var y } => $""Generic Point: {x}, {y}""
        };
    }
}";
            await RunTest(csharpCode, skipRoslyn: true);
        }

        [TestMethod]
        public async Task LogicalPatternsWithDeclarations()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        object o1 = 5;
        object o2 = ""hello"";
        object o3 = 15;

        Console.WriteLine(Test(o1));
        Console.WriteLine(Test(o2));
        Console.WriteLine(Test(o3));
    }

    static string Test(object o)
    {
        if (o is int i and < 10)
        {
            return $""Small Int: {i}"";
        }
        else if (o is int i2 and >= 10)
        {
            return $""Large Int: {i2}"";
        }
        else
        {
            return ""Not an Int"";
        }
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task NullableValueTypePattern()
        {
             var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        int? x = 5;
        int? y = null;

        Console.WriteLine(Test(x));
        Console.WriteLine(Test(y));
    }

    static string Test(int? input)
    {
        return input switch
        {
            int val => $""Value: {val}"",
            null => ""Null""
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task RelationalAndVarPattern()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Test(5));
        Console.WriteLine(Test(15));
    }

    static string Test(int input)
    {
        return input switch
        {
            < 10 and var x => $""Less than 10: {x}"",
            >= 10 and var x => $""Greater or equal 10: {x}""
        };
    }
}";
            await RunTest(csharpCode);
        }

        [TestMethod]
        public async Task PropertyPatternOnNullInput()
        {
            var csharpCode = @"
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Test(null));
        Console.WriteLine(Test(""hello""));
    }

    static int Test(string s)
    {
        return s switch
        {
            { Length: var l } => l,
            null => -1
        };
    }
}";
            await RunTest(csharpCode);
        }
    }
}
