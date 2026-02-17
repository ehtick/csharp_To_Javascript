using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests
{
    [TestClass]
    public class SpecialAttributesTests : IntegrationTestBase
    {
        [TestMethod]
        public async Task TestObjectLiteral_Default()
        {
            var code = @"
using H5;
using System;

[ObjectLiteral]
public class MyConfig
{
    public string Name { get; set; }
    public int Value { get; set; }
}

public class Program
{
    public static void Main()
    {
        var c = new MyConfig { Name = ""Test"", Value = 123 };

        // Check if it's a plain object
        bool isPlain = Script.Write<bool>(""Object.getPrototypeOf({0}) === Object.prototype"", c);
        Console.WriteLine(""IsPlain: "" + isPlain);
        Console.WriteLine(""Name: "" + c.Name);
        Console.WriteLine(""Value: "" + c.Value);

        // Verify key presence
        bool hasName = Script.Write<bool>(""'name' in {0}"", c);
        bool hasNamePascal = Script.Write<bool>(""'Name' in {0}"", c);
        bool hasValue = Script.Write<bool>(""'value' in {0}"", c);
        bool hasValuePascal = Script.Write<bool>(""'Value' in {0}"", c);
        Console.WriteLine(""Has 'name': "" + hasName);
        Console.WriteLine(""Has 'Name': "" + hasNamePascal);
        Console.WriteLine(""Has 'value': "" + hasValue);
        Console.WriteLine(""Has 'Value': "" + hasValuePascal);

        if (!isPlain) throw new Exception(""Expected plain object"");
        if (hasName) throw new Exception(""Property 'name' should not exist"");
        if (!hasNamePascal) throw new Exception(""Property 'Name' should exist"");
        if (hasValue) throw new Exception(""Property 'value' should not exist"");
        if (!hasValuePascal) throw new Exception(""Property 'Value' should exist"");
    }
}";
            var output = await RunTest(code, skipRoslyn: true);
            Console.WriteLine(output);
        }

        [TestMethod]
        public async Task TestObjectLiteral_InitializerMode()
        {
             // Test ObjectInitializationMode.Initializer
             // Based on previous run, it seems Initializer mode INCLUDES property initializers,
             // and ObjectLiteral defaults to PascalCase (Preserve casing).
             var code = @"
using H5;
using System;

[ObjectLiteral(ObjectInitializationMode.Initializer)]
public class MyOptions
{
    public int A { get; set; } = 10;
    public int B { get; set; } = 20;
}

public class Program
{
    public static void Main()
    {
        var o = new MyOptions { A = 99 };

        Console.WriteLine(""A: "" + o.A);

        // Check if 'B' is present in the underlying JS object
        bool hasB = Script.Write<bool>(""'B' in {0}"", o);
        Console.WriteLine(""Has 'B': "" + hasB);

        // If 'B' is present, it should have the initialized value 20.
        Console.WriteLine(""B value: "" + o.B);

        if (!hasB) throw new Exception(""Property 'B' should exist in Initializer mode because it has a property initializer"");
        if (o.B != 20) throw new Exception(""Property 'B' should have value 20"");
    }
}";
            var output = await RunTest(code, skipRoslyn: true);
            Console.WriteLine(output);
        }

        [TestMethod]
        public async Task TestObjectLiteral_IgnoreMode()
        {
             // Test ObjectInitializationMode.Ignore
             // Based on previous run, Ignore mode EXCLUDES property initializers (unless in object init).
             var code = @"
using H5;
using System;

[ObjectLiteral(ObjectInitializationMode.Ignore)]
public class MyIgnore
{
    public int X { get; set; } = 5;
    public int Y { get; set; }
}

public class Program
{
    public static void Main()
    {
        var o = new MyIgnore { Y = 10 };

        Console.WriteLine(""Y: "" + o.Y);

        // X has initializer but not set in object init.
        // In Ignore mode, X should be missing.
        bool hasX = Script.Write<bool>(""'X' in {0}"", o);
        Console.WriteLine(""Has 'X': "" + hasX);
        Console.WriteLine(""X value: "" + o.X);

        if (hasX) throw new Exception(""Property 'X' should NOT exist in Ignore mode"");
    }
}";
            var output = await RunTest(code, skipRoslyn: true);
            Console.WriteLine(output);
        }

        [TestMethod]
        public async Task TestNameAttribute()
        {
            var code = @"
using H5;
using System;

namespace TestNamespace
{
    public class Program
    {
        [Name(""customMethodName"")]
        public static void OriginalName()
        {
            Console.WriteLine(""Called customMethodName"");
        }

        public static void Main()
        {
            OriginalName();

            // Check if the function exists with the custom name on the class
            // Program is compiled to TestNamespace.Program
            bool exists = Script.Write<bool>(""typeof TestNamespace.Program.customMethodName === 'function'"");
            Console.WriteLine(""Custom Name Exists: "" + exists);

            // Verify original name does not exist
            bool originalExists = Script.Write<bool>(""typeof TestNamespace.Program.OriginalName === 'function'"");
            Console.WriteLine(""Original Name Exists: "" + originalExists);

            if (!exists) throw new Exception(""customMethodName should exist"");
            if (originalExists) throw new Exception(""OriginalName should not exist"");
        }
    }
}
";
            var output = await RunTest(code, skipRoslyn: true);
            Console.WriteLine(output);
        }

        [TestMethod]
        public async Task TestTemplateAttribute()
        {
            var code = @"
using H5;
using System;

public class Utils
{
    [Template(""console.log('Template: ' + {0})"")]
    public static extern void CustomLog(string message);
}

public class Program
{
    public static void Main()
    {
        Utils.CustomLog(""Hello World"");
    }
}";
            // Expect output to contain "Template: Hello World"
            // The console output is captured and returned.
            // We can check it manually in the test runner output or rely on standard behavior.
            // But since we are skipping Roslyn, we can't compare output against Roslyn.
            // However, RunTest returns the output, so we could assert on it if we wanted.
            // For now, printing to console is what was requested ("prints enough info to verify").
            // The CustomLog does exactly that.

            var output = await RunTest(code, skipRoslyn: true);
            Console.WriteLine(output);
        }
    }
}
