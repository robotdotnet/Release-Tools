using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BitPantry.AssemblyPatcher;
using LibGit2Sharp;
using NuGet;

namespace Documentation_Builder
{
    class Program
    {
        //This tool will be used to download all of the nuget packages we have public, and generate documentation for them using sandcastle. 
        //It will also generate redirection HTML files so we can go directly to an individual namespace.
        //This can be hardcoded since we will not be adding new repositories often.
        
        //This is being redone since we need to clone the repository

        static void Main(string[] args)
        {
            //First we need to clone our 2 repositories
            CloneOptions options = new CloneOptions();
            Repository.Clone("https://github.com/robotdotnet/robotdotnet-wpilib.git", "robotdotnet-wpilib", options);

            options = new CloneOptions();
            Repository.Clone("https://github.com/robotdotnet/NetworkTablesDotNet.git", "NetworkTablesDotNet", options);


            //Next we need to grab the latest version numbers
            List<string> packageIDs = new List<string>()
            {
                "FRC.NetworkTables",
                "FRC.WPILib",
            };
            IPackageRepository repo =
                PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");

            var packages = repo.FindPackages(packageIDs);
            packages = packages.Where(item => item.IsReleaseVersion() && item.IsLatestVersion).ToList();

            string WPILibVersion = "";
            string NTVersion = "";

            foreach (var package in packages)
            {
                if (package.Title == "FRC WPILib")
                {
                    WPILibVersion = package.Version.ToString();
                }
                if (package.Title == "FRC NetworkTables")
                {
                    NTVersion = package.Version.ToString();
                }
            }

            //Patch NetworkTables
            if (NTVersion == "")
                throw new InvalidOperationException("NT version not set");
            string name = "NetworkTablesDotNet";
            foreach (var s in Directory.EnumerateFiles(name, "*.csproj", SearchOption.AllDirectories))
            {
                VersionPatcher.Patch(name, s, NTVersion + ".0");
            }

            /*
            Process p = new Process();
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "nuget";
            p.StartInfo.Arguments = $"restore {name}\\{name}.sln";
            p.Start();
            p.WaitForExit();
            */

            //Patch WPILib
            if (WPILibVersion == "")
                throw new InvalidOperationException("WPILib version not set");

            name = "robotdotnet-wpilib";

            foreach (var s in Directory.EnumerateFiles(name, "*.csproj", SearchOption.AllDirectories))
            {
                VersionPatcher.Patch(name, s, WPILibVersion + ".0");
            }
        }

        
        
        static void Main2(string[] args)
        {
            //First we want to download all of our packages
            #region Download NuPkg

            //Clear any old package directory
            if (Directory.Exists("Packages"))
            {
                Directory.Delete("Packages", true);
            }
            if (Directory.Exists("LocalRepo"))
            {
                Directory.Delete("LocalRepo", true);
            }



            Directory.CreateDirectory("Packages");
            Directory.CreateDirectory("LocalRepo");

            List<string> packageIDs = new List<string>()
            {
                "FRC.NetworkTables",
                "FRC.WPILib",
                "FRC.WPILib.Extras",
            };
            IPackageRepository repo =
                PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            
            var packages = repo.FindPackages(packageIDs);
            packages = packages.Where(item => item.IsReleaseVersion() && item.IsLatestVersion).ToList();

            PackageManager manager = new PackageManager(new LocalPackageRepository("Packages"), "LocalRepo");

            //Download and extract all packages.
            foreach (var package in packages)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(((DataServicePackage)package).DownloadUrl.AbsoluteUri, $"Packages\\{package.Title}.{package.Version}.nupkg");
                    manager.InstallPackage(package, true, false);
                }
            }

            //Copy packages to sandcastle directory
            if (Directory.Exists("sources"))
            {
                foreach (var file in Directory.GetFiles("sources"))
                {
                    File.Delete(file);
                }
                Directory.Delete("sources");
            }

            Directory.CreateDirectory("sources");

            foreach (var file in Directory.GetDirectories("LocalRepo").SelectMany(s => Directory.GetFiles($"{s}\\lib\\net45")))
            {
                File.Copy(file, $"sources\\{Path.GetFileName(file)}");
            }

            #endregion

            //Now generate the documentation.
            //Build the documentation
            Process p = new Process();
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = @"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe";
            p.StartInfo.Arguments = "Sandcastle.shfbproj /p:Configuration=Release /flp:LogFile=Sandcastle.log;Verbosity=Normal";
            p.Start();
            p.WaitForExit();

        }
    }
}
