using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class ConvertTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestToHexString()
        {
            RunTest(
                @"
                byte[] bytes = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
                System.Console.WriteLine(Convert.ToHexString(bytes));
                System.Console.WriteLine(Convert.ToHexString(bytes, 1, 2));

                System.Console.WriteLine(Convert.ToHexString(new byte[0]));
                ",
                @"DEADBEEF
ADBE
");
        }

        [TestMethod]
        public void TestFromHexString()
        {
            RunTest(
                @"
                byte[] bytes = Convert.FromHexString(""DEADBEEF"");
                foreach (var b in bytes)
                {
                    System.Console.Write(b.ToString(""X2""));
                }
                System.Console.WriteLine();

                bytes = Convert.FromHexString(""adbe""); // Case insensitive check
                foreach (var b in bytes)
                {
                    System.Console.Write(b.ToString(""X2""));
                }
                ",
                @"DEADBEEF
ADBE");
        }
    }
}
