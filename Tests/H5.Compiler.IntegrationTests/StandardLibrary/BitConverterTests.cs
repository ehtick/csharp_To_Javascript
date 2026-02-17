using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class BitConverterTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestSingleToInt32Bits()
        {
            RunTest(
                @"
                // 1.0f -> 0x3f800000 (1065353216)
                System.Console.WriteLine(BitConverter.SingleToInt32Bits(1.0f));

                // -1.0f -> 0xbf800000 (-1082130432)
                System.Console.WriteLine(BitConverter.SingleToInt32Bits(-1.0f));

                // 0.0f -> 0
                System.Console.WriteLine(BitConverter.SingleToInt32Bits(0.0f));

                // -0.0f -> 0x80000000 (-2147483648)
                System.Console.WriteLine(BitConverter.SingleToInt32Bits(-0.0f));

                // Infinity -> 0x7f800000 (2139095040)
                System.Console.WriteLine(BitConverter.SingleToInt32Bits(float.PositiveInfinity));
                ",
                @"1065353216
-1082130432
0
-2147483648
2139095040");
        }

        [TestMethod]
        public void TestInt32BitsToSingle()
        {
            RunTest(
                @"
                // 0x3f800000 -> 1.0f
                System.Console.WriteLine(BitConverter.Int32BitsToSingle(1065353216).ToString(""F1""));

                // 0xbf800000 -> -1.0f
                System.Console.WriteLine(BitConverter.Int32BitsToSingle(-1082130432).ToString(""F1""));

                // 0 -> 0.0f
                System.Console.WriteLine(BitConverter.Int32BitsToSingle(0).ToString(""F1""));

                // Round trip
                float f = 123.456f;
                int bits = BitConverter.SingleToInt32Bits(f);
                float f2 = BitConverter.Int32BitsToSingle(bits);
                System.Console.WriteLine(f == f2);
                ",
                @"1.0
-1.0
0.0
True");
        }
    }
}
