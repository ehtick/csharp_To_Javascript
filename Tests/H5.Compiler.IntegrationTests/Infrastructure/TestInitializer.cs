using Microsoft.Build.Locator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.Globalization;

namespace H5.Compiler.IntegrationTests
{
    [TestClass]
    public static class TestInitializer
    {
        public static TimeZoneInfo LocalTimeZone;
        public static CultureInfo LocalCulture;
        public static bool ConsoleAvailable;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ForceInvariantCultureAndUTF8Output();

            // Initialize MSBuild
            try
            {
                var instances = MSBuildLocator.QueryVisualStudioInstances().ToArray();
                if (instances.Length > 0)
                {
                    var instance = instances.OrderByDescending(x => x.Version).First();
                    MSBuildLocator.RegisterInstance(instance);
                    Console.WriteLine($"Registered MSBuild instance: {instance.Name} {instance.Version} at {instance.MSBuildPath}");
                }
                else
                {
                    MSBuildLocator.RegisterDefaults();
                    Console.WriteLine("Registered default MSBuild instance.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MSBuildLocator initialization warning: {ex.Message}");
            }

            try
            {
                // Install Chromium binary
                var ret = Microsoft.Playwright.Program.Main(new[] { "install", "chromium" });
                if (ret != 0)
                {
                    Console.WriteLine($"Playwright install chromium failed with code {ret}");
                }
                else
                {
                    Console.WriteLine("Playwright chromium installed successfully.");
                }

                // Install dependencies (might fail if not root/sudo, so logging but not throwing)
                ret = Microsoft.Playwright.Program.Main(new[] { "install-deps", "chromium" });
                if (ret != 0)
                {
                   Console.WriteLine($"Playwright install-deps chromium failed with code {ret}");
                }
                else
                {
                   Console.WriteLine("Playwright dependencies installed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error installing Playwright: {ex}");
            }
        }

        public static void ForceInvariantCultureAndUTF8Output()
        {
            LocalTimeZone = TimeZoneInfo.Local;
            LocalCulture = Thread.CurrentThread.CurrentUICulture;

            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                ConsoleAvailable = true;
            }
            catch
            {
                //This might throw if not running on a console, ignore as we don't care in that case
                ConsoleAvailable = false;
            }

            if (ConsoleAvailable)
            {
                try
                {
                    Console.InputEncoding = Encoding.UTF8;
                }
                catch
                {
                    //This might throw if not running on a console that reads input, ignore as we don't care in that case
                }
            }


            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }
    }
}
