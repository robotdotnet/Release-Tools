using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionPatcher
{
    class Program
    {
        private static List<VSTemplatePatcher> templateFiles = new List<VSTemplatePatcher>();
        private static List<SimulatorTemplatePatcher> simulatorTemplates = new List<SimulatorTemplatePatcher>();
        private static ExtensionPackagesPatcher patcher = null;

        static void Main(string[] args)
        {
            foreach (var s in Directory.EnumerateFiles("Templates\\CSharp\\Project-Templates", "*.vstemplate", SearchOption.AllDirectories))
            {
                if (s.Contains("WindowsMonoGameSimulator"))
                {
                    Console.WriteLine("Found Simulator Template File: " + s);
                    simulatorTemplates.Add(new SimulatorTemplatePatcher(s));

                }
                else
                {
                    Console.WriteLine("Found Template File: " + s);
                    templateFiles.Add(new VSTemplatePatcher(s));
                }

            }

            foreach (var s in Directory.EnumerateFiles("Templates\\VisualBasic\\Project-Templates", "*.vstemplate", SearchOption.AllDirectories))
            { 
                Console.WriteLine("Found Template File: " + s);
                templateFiles.Add(new VSTemplatePatcher(s));
            }

            if (File.Exists("FRC-Extension\\FRC-Extension.csproj"))
                patcher = new ExtensionPackagesPatcher("FRC-Extension\\FRC-Extension.csproj");

            string wpiLib = null;
            string wpiLibEtras = null;
            string simulator = null;
            string networkTables = null;

            GetPackageVersions(ref wpiLib, ref wpiLibEtras, ref simulator, ref networkTables);

            foreach(var p in templateFiles)
            {
                p.Patch(wpiLib, wpiLibEtras, networkTables);
                p.WriteFile();
            }

            foreach (var p in simulatorTemplates)
            {
                p.Patch(wpiLib, wpiLibEtras, networkTables, simulator);
                p.WriteFile();
            }

            patcher.Patch(wpiLib, wpiLibEtras, networkTables, simulator);
            patcher.WriteFile();
        }


        public static void GetPackageVersions(ref string wpilib, ref string wpilibExtras, ref string simulator,
            ref string networkTables)
        {
            var files = Directory.GetFiles("FRC-Extension\\packages");
            foreach (var file in files)
            {
                if (file.Contains("WPILib.Extras"))
                {
                    //Grab extras first.
                    wpilibExtras = GetVersionNumber(file);
                }
                else if (file.Contains("WPILib"))
                {
                    wpilib = GetVersionNumber(file);
                }
                else if (file.Contains("MonoGameSimulator"))
                {
                    simulator = GetVersionNumber(file);
                }
                else if (file.Contains("NetworkTables"))
                {
                    networkTables = GetVersionNumber(file);
                }
            }
        }

        public static string GetVersionNumber(string file)
        {
            string[] split = file.Split('.');
            StringBuilder builder = new StringBuilder();
            builder.Append(split[split.Length - 5]);
            builder.Append(".");
            builder.Append(split[split.Length - 4]);
            builder.Append(".");
            builder.Append(split[split.Length - 3]);
            builder.Append(".");
            builder.Append(split[split.Length - 2]);

            return builder.ToString();
        }
    }
}
