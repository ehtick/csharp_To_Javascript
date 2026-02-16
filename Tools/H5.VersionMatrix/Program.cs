using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibGit2Sharp;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace H5.VersionMatrix
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var projectOption = new Option<FileInfo>(
                name: "--project",
                description: "The project file to build")
            { IsRequired = true };
            projectOption.AddAlias("-p");

            var outputOption = new Option<DirectoryInfo>(
                name: "--output",
                description: "The output folder")
            { IsRequired = true };
            outputOption.AddAlias("-o");

            var minVersionOption = new Option<string>(
                name: "--min-version",
                description: "Minimum version of the compiler");

            var maxVersionOption = new Option<string>(
                name: "--max-version",
                description: "Maximum version of the compiler");

            var versionsOption = new Option<string>(
                name: "--versions",
                description: "Semicolon-separated list of compiler versions to process");

            var rootCommand = new RootCommand("H5 Compiler Version Matrix Tool")
            {
                projectOption,
                outputOption,
                minVersionOption,
                maxVersionOption,
                versionsOption
            };

            rootCommand.SetHandler(async (project, output, minVersion, maxVersion, versions) =>
            {
                await RunAsync(project, output, minVersion, maxVersion, versions);
            }, projectOption, outputOption, minVersionOption, maxVersionOption, versionsOption);

            return await rootCommand.InvokeAsync(args);
        }

        static async Task RunAsync(FileInfo project, DirectoryInfo output, string minVersion, string maxVersion, string specificVersions)
        {
            if (!project.Exists)
            {
                Console.WriteLine($"Project file not found: {project.FullName}");
                return;
            }

            if (!output.Exists)
            {
                output.Create();
            }

            var cacheDir = new DirectoryInfo(Path.Combine(output.FullName, ".cache"));
            if (!cacheDir.Exists) cacheDir.Create();

            var flattenedDir = new DirectoryInfo(Path.Combine(output.FullName, "flattened"));
            if (flattenedDir.Exists)
            {
                // Ensure it's a git repo or init it
                if (!Directory.Exists(Path.Combine(flattenedDir.FullName, ".git")))
                {
                    LibGit2Sharp.Repository.Init(flattenedDir.FullName);
                }
            }
            else
            {
                flattenedDir.Create();
                LibGit2Sharp.Repository.Init(flattenedDir.FullName);
            }

            using var repo = new LibGit2Sharp.Repository(flattenedDir.FullName);

            List<NuGetVersion> versions;

            if (!string.IsNullOrWhiteSpace(specificVersions))
            {
                Console.WriteLine($"Using specified versions: {specificVersions}");
                versions = specificVersions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(v => NuGetVersion.Parse(v.Trim()))
                    .OrderBy(v => v)
                    .ToList();
            }
            else
            {
                Console.WriteLine("Fetching h5-compiler versions...");
                versions = await GetCompilerVersionsAsync(minVersion, maxVersion);
            }

            if (!versions.Any())
            {
                Console.WriteLine("No versions found.");
                return;
            }

            Console.WriteLine("Fetching h5 runtime versions...");
            var h5Versions = await GetPackageVersionsAsync("h5");

            Console.WriteLine($"Found {versions.Count} compiler versions.");

            foreach (var version in versions)
            {
                Console.WriteLine($"\nProcessing version {version}...");

                // Find best matching h5 version
                var h5Version = h5Versions.Where(v => v <= version).Max();
                if (h5Version == null)
                {
                    h5Version = h5Versions.OrderBy(v => v).FirstOrDefault();
                    if (h5Version == null)
                    {
                        Console.WriteLine("No h5 runtime versions found. Skipping.");
                        continue;
                    }
                    Console.WriteLine($"Warning: No h5 version <= {version}. Using oldest available: {h5Version}");
                }
                else
                {
                    Console.WriteLine($"Selected h5 runtime version {h5Version} for compiler {version}");
                }

                var versionStr = version.ToNormalizedString();
                var h5VersionStr = h5Version.ToNormalizedString();
                var toolPath = Path.Combine(cacheDir.FullName, "tools", versionStr);
                var versionOutputDir = Path.Combine(output.FullName, versionStr); // Keep compiled output here

                // 1. Install Tool
                var executableName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "h5.exe" : "h5";
                var h5Executable = Path.Combine(toolPath, executableName);

                if (!File.Exists(h5Executable))
                {
                    Console.WriteLine($"Installing h5-compiler {versionStr}...");
                    if (!await InstallToolAsync(versionStr, toolPath))
                    {
                        Console.WriteLine($"Failed to install tool version {versionStr}. Skipping.");
                        continue;
                    }
                }

                // 2. Prepare Project (Update reference)
                var workDir = Path.Combine(cacheDir.FullName, "work", versionStr);
                if (Directory.Exists(workDir)) Directory.Delete(workDir, true);
                Directory.CreateDirectory(workDir);

                // Copy project directory to work dir
                CopyDirectory(project.Directory, new DirectoryInfo(workDir), output.FullName);
                var workProjectFile = Path.Combine(workDir, project.Name);

                // Update h5 package reference
                UpdatePackageReference(workProjectFile, h5VersionStr);

                // Restore
                Console.WriteLine($"Restoring project for version {versionStr} (runtime {h5VersionStr})...");
                if (!await RunCommandAsync("dotnet", $"restore \"{workProjectFile}\"", workDir))
                {
                    Console.WriteLine($"Restore failed for version {versionStr}. Skipping.");
                    continue;
                }

                // 3. Compile
                Console.WriteLine($"Compiling with version {versionStr}...");
                // h5 args: <project> -o <output>
                // We need to use absolute paths.
                // Note: h5 tool might output to <output>/h5 or directly to <output>.
                // We'll inspect the output directory after compilation.

                if (!await RunCommandAsync(h5Executable, $"\"{workProjectFile}\" -o \"{versionOutputDir}\"", workDir))
                {
                    Console.WriteLine($"Compilation failed for version {versionStr}.");
                    // We continue to commit even if failed? No, if failed, we probably don't have output.
                    // But maybe partial output?
                }

                // 4. Update Git Repo
                Console.WriteLine($"Updating git repository for version {versionStr}...");
                UpdateGitRepo(repo, flattenedDir, versionOutputDir, versionStr);
            }
        }

        static async Task<List<NuGetVersion>> GetCompilerVersionsAsync(string minVersionStr, string maxVersionStr)
        {
            var versions = await GetPackageVersionsAsync("h5-compiler");
            var result = versions.ToList();

            if (!string.IsNullOrEmpty(minVersionStr) && NuGetVersion.TryParse(minVersionStr, out var minVersion))
            {
                result = result.Where(v => v >= minVersion).ToList();
            }

            if (!string.IsNullOrEmpty(maxVersionStr) && NuGetVersion.TryParse(maxVersionStr, out var maxVersion))
            {
                result = result.Where(v => v <= maxVersion).ToList();
            }

            return result.OrderBy(v => v).ToList();
        }

        static async Task<List<NuGetVersion>> GetPackageVersionsAsync(string packageId)
        {
            var logger = NullLogger.Instance;
            var cache = new SourceCacheContext();
            var repository = NuGet.Protocol.Core.Types.Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
            var resource = await repository.GetResourceAsync<FindPackageByIdResource>();

            var versions = await resource.GetAllVersionsAsync(
                packageId,
                cache,
                logger,
                CancellationToken.None);

            return versions.ToList();
        }

        static async Task<bool> InstallToolAsync(string version, string toolPath)
        {
            // dotnet tool install h5-compiler --version <ver> --tool-path <toolPath>
            return await RunCommandAsync("dotnet", $"tool install h5-compiler --version {version} --tool-path \"{toolPath}\"", Directory.GetCurrentDirectory());
        }

        static async Task<bool> RunCommandAsync(string command, string args, string workingDirectory)
        {
            var psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = psi };

            var output = new List<string>();
            var error = new List<string>();

            process.OutputDataReceived += (s, e) => { if (e.Data != null) output.Add(e.Data); };
            process.ErrorDataReceived += (s, e) => { if (e.Data != null) error.Add(e.Data); };

            try
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    // For dotnet restore, sometimes it writes to stderr even on success/warnings, but ExitCode 0 is success.
                    // If ExitCode != 0, it's a failure.
                    Console.WriteLine($"Command failed: {command} {args}");
                    Console.WriteLine("Output:");
                    output.ForEach(Console.WriteLine);
                    Console.WriteLine("Error:");
                    error.ForEach(Console.WriteLine);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running command: {ex.Message}");
                return false;
            }
        }

        static void CopyDirectory(DirectoryInfo source, DirectoryInfo target, string excludePath = null)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (var file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            foreach (var subDir in source.GetDirectories())
            {
                // Avoid infinite recursion if excludePath is inside subDir or matches subDir
                if (excludePath != null && (subDir.FullName.Equals(excludePath, StringComparison.OrdinalIgnoreCase) || excludePath.StartsWith(subDir.FullName + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                // Also avoid copying .git or bin/obj if possible?
                if (subDir.Name == "bin" || subDir.Name == "obj" || subDir.Name == ".git") continue;

                var nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyDirectory(subDir, nextTargetSubDir, excludePath);
            }
        }

        static void UpdatePackageReference(string projectFile, string version)
        {
            try
            {
                var doc = XDocument.Load(projectFile);

                // Find PackageReference Include="h5"
                var packageRefs = doc.Descendants("PackageReference")
                    .Where(x => (string)x.Attribute("Include") == "h5");

                bool found = false;
                foreach (var packageRef in packageRefs)
                {
                    packageRef.SetAttributeValue("Version", version);
                    found = true;
                }

                if (!found)
                {
                    // Check if there is an ItemGroup, if not create one
                    var itemGroup = doc.Descendants("ItemGroup").FirstOrDefault();
                    if (itemGroup == null)
                    {
                         itemGroup = new XElement("ItemGroup");
                         doc.Root.Add(itemGroup);
                    }
                    itemGroup.Add(new XElement("PackageReference", new XAttribute("Include", "h5"), new XAttribute("Version", version)));
                }

                doc.Save(projectFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating project file: {ex.Message}");
            }
        }

        static void UpdateGitRepo(LibGit2Sharp.Repository repo, DirectoryInfo flattenedDir, string sourceDir, string version)
        {
            // 1. Clean flattenedDir (except .git)
            foreach (var file in flattenedDir.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in flattenedDir.GetDirectories())
            {
                if (dir.Name != ".git")
                {
                    dir.Delete(true);
                }
            }

            // 2. Copy filtered files from sourceDir
            // Source is typically <sourceDir>/h5/ or <sourceDir> if h5 outputs directly.
            // Check <sourceDir>/h5 first.
            var potentialSource = Path.Combine(sourceDir, "h5");
            if (!Directory.Exists(potentialSource))
            {
                potentialSource = sourceDir;
            }

            if (Directory.Exists(potentialSource))
            {
                CopyFiltered(new DirectoryInfo(potentialSource), flattenedDir);
            }
            else
            {
                Console.WriteLine($"Warning: Output directory {potentialSource} not found. Committing empty state (or no changes).");
            }

            // 3. Stage and Commit
            var status = repo.RetrieveStatus();
            if (status.IsDirty)
            {
                foreach (var item in status)
                {
                    Commands.Stage(repo, item.FilePath);
                }

                var signature = new Signature("H5 Version Matrix", "h5@h5.rocks", DateTimeOffset.Now);
                repo.Commit($"Compiler version {version}", signature, signature);
                Console.WriteLine($"Committed version {version}.");
            }
            else
            {
                Console.WriteLine($"No changes for version {version}. Skipping commit.");
            }
        }

        static void CopyFiltered(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (var file in source.GetFiles())
            {
                var ext = file.Extension.ToLower();
                if (ext == ".js" || ext == ".html" || ext == ".css")
                {
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                }
            }

            foreach (var subDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyFiltered(subDir, nextTargetSubDir);

                // If directory is empty, delete it
                if (nextTargetSubDir.GetFileSystemInfos().Length == 0)
                {
                    nextTargetSubDir.Delete();
                }
            }
        }
    }
}
