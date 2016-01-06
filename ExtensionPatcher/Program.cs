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
        static void Main(string[] args)
        {

        }


        public void GetPackageVersions(ref string wpilib, ref string wpilibExtras, ref string simulator,
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

        public string GetVersionNumber(string file)
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
