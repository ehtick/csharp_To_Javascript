using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class MathTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestClamp()
        {
            RunTest(
                @"
                // Byte
                System.Console.WriteLine(Math.Clamp((byte)10, (byte)0, (byte)20));
                System.Console.WriteLine(Math.Clamp((byte)25, (byte)0, (byte)20));
                System.Console.WriteLine(Math.Clamp((byte)0, (byte)5, (byte)20));

                // Int32
                System.Console.WriteLine(Math.Clamp(10, 0, 20));
                System.Console.WriteLine(Math.Clamp(25, 0, 20));
                System.Console.WriteLine(Math.Clamp(-5, 0, 20));

                // Double
                System.Console.WriteLine(Math.Clamp(10.5, 0.0, 20.0).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(25.5, 0.0, 20.0).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(-5.5, 0.0, 20.0).ToString(""F1""));

                // Float
                System.Console.WriteLine(Math.Clamp(10.5f, 0.0f, 20.0f).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(25.5f, 0.0f, 20.0f).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(-5.5f, 0.0f, 20.0f).ToString(""F1""));

                // Decimal
                System.Console.WriteLine(Math.Clamp(10.5m, 0.0m, 20.0m).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(25.5m, 0.0m, 20.0m).ToString(""F1""));
                System.Console.WriteLine(Math.Clamp(-5.5m, 0.0m, 20.0m).ToString(""F1""));
                ",
                @"10
20
5
10
20
0
10.5
20.0
0.0
10.5
20.0
0.0
10.5
20.0
0.0");
        }

        [TestMethod]
        public void TestCopySign()
        {
            RunTest(
                @"
                System.Console.WriteLine(Math.CopySign(1.0, -1.0).ToString(""F1""));
                System.Console.WriteLine(Math.CopySign(-1.0, 1.0).ToString(""F1""));
                System.Console.WriteLine(Math.CopySign(1.0, 1.0).ToString(""F1""));
                System.Console.WriteLine(Math.CopySign(-1.0, -1.0).ToString(""F1""));

                // Test signed zero logic if possible (JS behavior)
                // H5 implementation uses ((1.0 / {y}) < 0 ? -1.0 : 1.0) * System.Math.abs({x})
                // Let's verify standard behavior first
                System.Console.WriteLine(Math.CopySign(5.0, -2.0).ToString(""F1""));
                ",
                @"-1.0
1.0
1.0
-1.0
-5.0");
        }

        [TestMethod]
        public void TestMinMaxMagnitude()
        {
            RunTest(
                @"
                System.Console.WriteLine(Math.MaxMagnitude(2.0, -3.0).ToString(""F1""));
                System.Console.WriteLine(Math.MaxMagnitude(-2.0, 3.0).ToString(""F1""));
                System.Console.WriteLine(Math.MaxMagnitude(2.0, 1.0).ToString(""F1""));

                System.Console.WriteLine(Math.MinMagnitude(2.0, -3.0).ToString(""F1""));
                System.Console.WriteLine(Math.MinMagnitude(-2.0, 3.0).ToString(""F1""));
                System.Console.WriteLine(Math.MinMagnitude(2.0, 1.0).ToString(""F1""));
                ",
                @"-3.0
3.0
2.0
2.0
-2.0
1.0");
        }

        [TestMethod]
        public void TestLog2()
        {
            RunTest(
                @"
                System.Console.WriteLine(Math.Log2(8.0).ToString(""F1""));
                System.Console.WriteLine(Math.Log2(1024.0).ToString(""F1""));
                System.Console.WriteLine(Math.Log2(1.0).ToString(""F1""));
                ",
                @"3.0
10.0
0.0");
        }

        [TestMethod]
        public void TestFusedMultiplyAdd()
        {
             RunTest(
                @"
                // Note: JS implementation is likely (x * y) + z approximation, so double rounding might occur.
                // We test basic correctness here.
                System.Console.WriteLine(Math.FusedMultiplyAdd(2.0, 3.0, 4.0).ToString(""F1""));
                System.Console.WriteLine(Math.FusedMultiplyAdd(2.0, -3.0, 4.0).ToString(""F1""));
                ",
                @"10.0
-2.0");
        }

        [TestMethod]
        public void TestBitIncrementDecrement()
        {
            RunTest(
                @"
                double d = 1.0;
                double next = Math.BitIncrement(d);
                System.Console.WriteLine(next > d);
                System.Console.WriteLine((next - d) < 1e-10); // Very small difference

                double prev = Math.BitDecrement(d);
                System.Console.WriteLine(prev < d);
                System.Console.WriteLine((d - prev) < 1e-10);

                System.Console.WriteLine(Math.BitIncrement(double.PositiveInfinity) == double.PositiveInfinity);
                System.Console.WriteLine(Math.BitDecrement(double.NegativeInfinity) == double.NegativeInfinity);
                ",
                @"True
True
True
True
True
True");
        }
    }
}
