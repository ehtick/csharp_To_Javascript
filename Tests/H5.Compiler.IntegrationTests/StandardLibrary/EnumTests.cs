using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class EnumTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestGenericMethods()
        {
            RunTest(
                @"
                enum Colors { Red = 1, Green = 2, Blue = 4 };

                // Parse
                Colors c1 = Enum.Parse<Colors>(""Red"");
                System.Console.WriteLine(c1);

                Colors c2 = Enum.Parse<Colors>(""green"", true);
                System.Console.WriteLine(c2);

                try {
                    Enum.Parse<Colors>(""Yellow"");
                } catch (ArgumentException) {
                    System.Console.WriteLine(""Caught ArgumentException"");
                }

                // GetValues
                var values = Enum.GetValues<Colors>();
                foreach (var v in values)
                {
                    System.Console.WriteLine(v);
                }

                // GetNames
                var names = Enum.GetNames<Colors>();
                foreach (var n in names)
                {
                    System.Console.WriteLine(n);
                }

                // IsDefined
                System.Console.WriteLine(Enum.IsDefined<Colors>(Colors.Red));
                System.Console.WriteLine(Enum.IsDefined<Colors>((Colors)5)); // Not defined
                ",
                @"Red
Green
Caught ArgumentException
Red
Green
Blue
Red
Green
Blue
True
False");
        }
    }
}
