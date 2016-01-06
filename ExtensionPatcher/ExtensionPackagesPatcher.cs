using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionPatcher
{
    class ExtensionPackagesPatcher
    {
        private string[] file;

        private int WPILibIndex = -1;
        private int WPILibExtrasIndex = -1;
        private int SimulatorIndex = -1;
        private int NTIndex = -1;

        private bool found = false;

        public string FilePath = "";

        public ExtensionPackagesPatcher(string fileName)
        {
            FilePath = fileName;
            file = File.ReadAllLines(fileName);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("<Content Include=\"packages\\FRC.WPILib.2"))
                {
                    WPILibIndex = i;
                }
                if (file[i].Contains("<Content Include=\"packages\\FRC.WPILib.Extras"))
                {
                    WPILibExtrasIndex = i;
                }
                if (file[i].Contains("<Content Include=\"packages\\FRC.NetworkTables"))
                {
                    NTIndex = i;
                }
                if (file[i].Contains("<Content Include=\"packages\\FRC.Simulators.MonoGameSimulator"))
                {
                    SimulatorIndex = i;
                }
            }
            if (WPILibIndex != -1 && WPILibExtrasIndex != -1 && NTIndex != -1 && SimulatorIndex != -1)
            {
                found = true;
            }
        }

        public void Patch(string wpilibVersion, string extrasVersion, string ntVersion, string simVersion)
        {
            if (found)
            {
                file[WPILibIndex] = $"    <Content Include=\"packages\\FRC.WPILib.{wpilibVersion}.nupkg\">";
                file[WPILibExtrasIndex] = $"    <Content Include=\"packages\\FRC.WPILib.Extras.{extrasVersion}.nupkg\">";
                file[NTIndex] = $"    <Content Include=\"packages\\FRC.NetworkTables.{ntVersion}.nupkg\">";
                file[SimulatorIndex] = $"    <Content Include=\"packages\\FRC.Simulators.MonoGameSimulator.{simVersion}.nupkg\">";
            }
        }

        public void WriteFile()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
            File.WriteAllLines(FilePath, file);
        }
    }
}
