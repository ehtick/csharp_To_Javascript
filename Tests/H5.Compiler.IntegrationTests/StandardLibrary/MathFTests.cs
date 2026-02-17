using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class MathFTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestConstants()
        {
            RunTest(
                @"
                System.Console.WriteLine(System.Math.Abs(MathF.E - 2.71828183f) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.PI - 3.14159265f) < 1e-6f);
                ",
                @"True
True");
        }

        [TestMethod]
        public void TestBasicFunctions()
        {
            RunTest(
                @"
                System.Console.WriteLine(MathF.Abs(-10.5f).ToString(""F1""));
                System.Console.WriteLine(MathF.Ceiling(10.1f).ToString(""F1""));
                System.Console.WriteLine(MathF.Floor(10.9f).ToString(""F1""));
                System.Console.WriteLine(MathF.Round(10.5f).ToString(""F1"")); // Round half to even => 10
                System.Console.WriteLine(MathF.Round(11.5f).ToString(""F1"")); // Round half to even => 12

                System.Console.WriteLine(MathF.Min(5.0f, 10.0f).ToString(""F1""));
                System.Console.WriteLine(MathF.Max(5.0f, 10.0f).ToString(""F1""));

                System.Console.WriteLine(MathF.Sign(-10.0f));
                System.Console.WriteLine(MathF.Truncate(10.9f).ToString(""F1""));
                ",
                @"10.5
11.0
10.0
10.0
12.0
5.0
10.0
-1
10.0");
        }

        [TestMethod]
        public void TestTrigonometry()
        {
             RunTest(
                @"
                // Just check they execute and return somewhat correct values (JavaScript precision)
                System.Console.WriteLine(System.Math.Abs(MathF.Sin(0) - 0) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Cos(0) - 1) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Tan(0) - 0) < 1e-6f);
                ",
                @"True
True
True");
        }

        [TestMethod]
        public void TestExponential()
        {
            RunTest(
                @"
                System.Console.WriteLine(System.Math.Abs(MathF.Exp(0) - 1) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Log(MathF.E) - 1) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Log10(100) - 2) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Log2(8) - 3) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Pow(2, 3) - 8) < 1e-6f);
                System.Console.WriteLine(System.Math.Abs(MathF.Sqrt(4) - 2) < 1e-6f);
                ",
                @"True
True
True
True
True
True");
        }

        [TestMethod]
        public void TestHyperbolic()
        {
            RunTest(
                @"
                System.Console.WriteLine(MathF.Sinh(0).ToString(""F1""));
                System.Console.WriteLine(MathF.Cosh(0).ToString(""F1""));
                System.Console.WriteLine(MathF.Tanh(0).ToString(""F1""));
                ",
                @"0.0
1.0
0.0");
        }

        [TestMethod]
        public void TestAdvanced()
        {
            RunTest(
                @"
                System.Console.WriteLine(MathF.Clamp(10.5f, 0.0f, 20.0f).ToString(""F1""));
                System.Console.WriteLine(MathF.CopySign(1.0f, -1.0f).ToString(""F1""));
                System.Console.WriteLine(MathF.MaxMagnitude(-10.0f, 5.0f).ToString(""F1""));
                System.Console.WriteLine(MathF.FusedMultiplyAdd(2.0f, 3.0f, 4.0f).ToString(""F1""));
                ",
                @"10.5
-1.0
-10.0
10.0");
        }
    }
}
