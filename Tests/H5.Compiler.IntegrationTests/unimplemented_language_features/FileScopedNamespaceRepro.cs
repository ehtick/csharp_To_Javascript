using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using H5.Compiler.IntegrationTests;

namespace H5.Compiler.IntegrationTests.UnimplementedLanguageFeatures
{
    [TestClass]
    public class FileScopedNamespaceRepro : IntegrationTestBase
    {
        [TestMethod]
        public async Task ReproduceCrash()
        {
            var code = """
using System;

namespace MyNamespace;

public class Program
{
    public static void Main()
    {
        System.Console.WriteLine(typeof(Program).Namespace);
    }
}
""";
             await RunTest(code, skipRoslyn: true);
        }
    }
}
