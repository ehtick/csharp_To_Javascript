using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H5.Compiler.IntegrationTests.StandardLibrary
{
    [TestClass]
    public class RandomTests : IntegrationTestBase
    {
        [TestMethod]
        public void TestNextInt64()
        {
            RunTest(
                @"
                var r = new Random(42);

                // Unbounded
                long l1 = r.NextInt64();
                System.Console.WriteLine(l1 >= 0);

                // Max value
                long l2 = r.NextInt64(100);
                System.Console.WriteLine(l2 >= 0 && l2 < 100);

                // Range
                long l3 = r.NextInt64(50, 60);
                System.Console.WriteLine(l3 >= 50 && l3 < 60);

                // Large Range
                long l4 = r.NextInt64(long.MaxValue - 100, long.MaxValue);
                System.Console.WriteLine(l4 >= (long.MaxValue - 100) && l4 < long.MaxValue);
                ",
                @"True
True
True
True");
        }

        [TestMethod]
        public void TestNextSingle()
        {
            RunTest(
                @"
                var r = new Random(42);
                float f = r.NextSingle();
                System.Console.WriteLine(f >= 0.0f && f < 1.0f);
                ",
                @"True");
        }

        [TestMethod]
        public void TestShared()
        {
            RunTest(
                @"
                // Just check it exists and works
                var r = Random.Shared;
                System.Console.WriteLine(r != null);
                System.Console.WriteLine(r.Next() >= 0);
                ",
                @"True
True");
        }
    }
}
