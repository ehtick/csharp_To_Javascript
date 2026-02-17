using H5.Compiler;
using H5.Compiler.Hosted;
using H5.Translator;
using NuGet.Versioning;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace H5.Fuzzer.Infrastructure
{
    public static class H5Runner
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Dictionary<string, NuGetVersion> _cachedLatestVersion = new Dictionary<string, NuGetVersion>();

        private static async Task<NuGetVersion> GetLatestVersionAsync(string package = "h5")
        {
            if (_cachedLatestVersion.TryGetValue(package, out var cachedVersion))
            {
                return cachedVersion;
            }

            try
            {
                if (package == "h5")
                {
                    // Assuming we are running from H5.Fuzzer/bin/Debug/net10.0/
                    // repoRoot should be ../../../../.. from the bin folder
                    var repoRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
                    var localPackagePath = Path.Combine(repoRoot, "H5/H5/bin/Debug/h5.0.0.42.nupkg");

                    if (File.Exists(localPackagePath))
                    {
                        var localVersion = new NuGetVersion("0.0.42");
                        _cachedLatestVersion[package] = localVersion;
                        await EnsurePackageRestored(localVersion, package, repoRoot);
                        return localVersion;
                    }
                }

                // Fallback to fetching from NuGet if local build not found
                var json = await _httpClient.GetStringAsync($"https://api.nuget.org/v3-flatcontainer/{package.ToLower()}/index.json");
                var versions = new List<NuGetVersion>();

                using (var doc = JsonDocument.Parse(json))
                {
                    if (doc.RootElement.TryGetProperty("versions", out var versionsProp) && versionsProp.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var v in versionsProp.EnumerateArray())
                        {
                            if (v.ValueKind == JsonValueKind.String)
                            {
                                var versionString = v.GetString();
                                if (!string.IsNullOrEmpty(versionString) && NuGetVersion.TryParse(versionString, out var candidateVersion))
                                {
                                    versions.Add(candidateVersion);
                                }
                            }
                        }
                    }
                }

                if (versions.Count == 0)
                {
                    throw new Exception($"No versions found for {package} package.");
                }

                var version = _cachedLatestVersion[package] = versions.Max();
                await EnsurePackageRestored(version, package);

                return version;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch or restore latest h5 version.", ex);
            }
        }

        private static async Task EnsurePackageRestored(NuGetVersion version, string package, string repoRoot = null)
        {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var packagePath = Path.Combine(userProfile, ".nuget", "packages", package, version.ToString());

            if (repoRoot != null && Directory.Exists(packagePath))
            {
                try { Directory.Delete(packagePath, true); } catch { }
            }
            else if (Directory.Exists(packagePath))
            {
                return;
            }

            var tempDir = Path.Combine(Path.GetTempPath(), "H5_Restore_" + Guid.NewGuid());
            Directory.CreateDirectory(tempDir);

            try
            {
                var csprojContent = $@"
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include=""{package}"" Version=""{version}"" />
  </ItemGroup>
</Project>";

                await File.WriteAllTextAsync(Path.Combine(tempDir, "Restore.csproj"), csprojContent);

                string restoreArgs = "restore";
                if (repoRoot != null)
                {
                    var localSource = Path.Combine(repoRoot, "H5/H5/bin/Debug");
                    var nugetConfig = $@"
<configuration>
  <packageSources>
    <add key=""LocalH5"" value=""{localSource}"" />
    <add key=""nuget.org"" value=""https://api.nuget.org/v3/index.json"" />
  </packageSources>
</configuration>";
                    await File.WriteAllTextAsync(Path.Combine(tempDir, "nuget.config"), nugetConfig);
                    restoreArgs += " --no-cache";
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = restoreArgs,
                    WorkingDirectory = tempDir,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    if (process == null) throw new Exception("Failed to start dotnet restore process.");
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"dotnet restore failed with exit code {process.ExitCode}.");
                    }
                }
            }
            finally
            {
                try { Directory.Delete(tempDir, true); } catch { }
            }
        }

        public static async Task<string> CompileToJs(string csharpCode)
        {
            var latestVersion = await GetLatestVersionAsync();

            var settings = new H5DotJson_AssemblySettings()
            {
                Reflection = new ReflectionConfig()
                {
                    Disabled = false,
                    Target = Contract.MetadataTarget.Inline, 
                },
                IgnoreDuplicateTypes = true
            };

            var request = new CompilationRequest("App", settings)
                            .NoHTML()
                            .WithLanguageVersion("Latest")
                            .WithPackageReference("h5", latestVersion)
                            .WithSourceFile("App.cs", csharpCode);

            var compiledJavascript = await CompilationProcessor.CompileAsync(request);

            if (compiledJavascript.Output == null || !compiledJavascript.Output.Any())
            {
                 throw new Exception("H5 compilation failed or produced no output.");
            }

            var jsFiles = compiledJavascript.Output
                .Where(f => f.Key.EndsWith(".js") && !f.Key.EndsWith(".min.js"))
                .ToList();

            if (!jsFiles.Any())
            {
                 jsFiles = compiledJavascript.Output
                    .Where(f => f.Key.EndsWith(".js"))
                    .ToList();
            }

            if (!jsFiles.Any())
            {
                throw new Exception("Could not find generated JavaScript file in output.");
            }

            var sortedFiles = jsFiles.OrderBy(f =>
            {
                var name = System.IO.Path.GetFileName(f.Key).ToLowerInvariant();
                if (name == "h5.js") return 0;
                if (name == "h5.core.js") return 1;
                if (name.StartsWith("h5.")) return 2;
                return 10;
            }).ToList();

            if (!sortedFiles.Any(f => f.Key.EndsWith("h5.js")) && latestVersion.ToString() == "0.0.42")
            {
                var repoRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../"));
                var h5JsPath = Path.Combine(repoRoot, "H5/H5/Resources/.generated/h5.js");
                if (File.Exists(h5JsPath))
                {
                    var content = File.ReadAllText(h5JsPath);
                    sortedFiles.Insert(0, new KeyValuePair<string, string>("h5.js", content));
                }
            }

            var sb = new System.Text.StringBuilder();
            foreach (var file in sortedFiles)
            {
                sb.AppendLine($"// File: {file.Key}");
                sb.AppendLine(file.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
