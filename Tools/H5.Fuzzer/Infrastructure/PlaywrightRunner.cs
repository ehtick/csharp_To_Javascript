using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace H5.Fuzzer.Infrastructure
{
    public class PlaywrightRunner : IDisposable, IAsyncDisposable
    {
        private IPlaywright _playwright;
        private IBrowser _browser;

        public async Task InitializeAsync()
        {
            if (_playwright == null)
            {
                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            }
        }

        public async Task<string> RunJsAsync(string jsCode, string waitForOutput = null)
        {
            if (_playwright == null)
            {
                await InitializeAsync();
            }

            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var consoleOutput = new StringBuilder();
            var outputComplete = new TaskCompletionSource<bool>();
            
            page.Console += (_, msg) =>
            {
                if (msg.Type == "log")
                {
                    consoleOutput.AppendLine(msg.Text);
                    if (waitForOutput != null && msg.Text.Contains(waitForOutput))
                    {
                        outputComplete.TrySetResult(true);
                    }
                }
            };

            page.PageError += (_, message) =>
            {
                consoleOutput.AppendLine($"PAGE_ERROR: {message}");
            };

            try
            {
                //// To safely execute the code and catch errors, we can wrap it or just rely on Playwright.
                //// Since H5 output can be large, we might want to use AddScriptTag instead?
                //// But EvaluateAsync is simpler for now.
                
                //// We need to append a bootstrap script to run Main.
                //// H5 apps usually don't auto-run Main unless configured.
                //var bootstrap = @"
                //    try {
                //         if (typeof H5 !== 'undefined' && H5.global.Program && H5.global.Program.Main) {
                //             var res = H5.global.Program.Main();
                //             if (res && typeof res.getAwaiter === 'function') {
                //                 // H5.toPromise is polyfilled in H5Runner
                //                 H5.toPromise(res); 
                //             }
                //         }
                //    } catch (e) {
                //        console.log('RUNTIME_ERROR: ' + e);
                //    }
                //";

                await page.EvaluateAsync(jsCode); // + "\n" + bootstrap

                if (waitForOutput != null)
                {
                    await Task.WhenAny(outputComplete.Task, Task.Delay(30000));
                }
            }
            catch (Exception e)
            {
                consoleOutput.AppendLine($"PLAYWRIGHT_EXECUTION_ERROR: {e.Message}");
            }
            finally
            {
                await context.CloseAsync();
            }

            return consoleOutput.ToString();
        }

        public void Dispose()
        {
            _browser?.DisposeAsync().GetAwaiter().GetResult();
            _playwright?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_browser != null) await _browser.DisposeAsync();
            _playwright?.Dispose();
        }
    }
}
