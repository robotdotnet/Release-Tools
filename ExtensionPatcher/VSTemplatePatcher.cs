﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionPatcher
{
    class VSTemplatePatcher
    {
        private string[] file;

        private int WPILibIndex = -1;
        private int WPILibExtrasIndex = -1;
        private int NTIndex = -1;

        private bool found = false;

        public string FilePath = "";

        public VSTemplatePatcher(string fileName)
        {
            FilePath = fileName;
            file = File.ReadAllLines(fileName);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("<package id=\"FRC.WPILib\""))
                {
                    WPILibIndex = i;
                }
                if (file[i].Contains("<package id=\"FRC.WPILib.Extras\""))
                {
                    WPILibExtrasIndex = i;
                }
                if (file[i].Contains("<package id=\"FRC.NetworkTables\""))
                {
                    NTIndex = i;
                }
            }
            if (WPILibIndex != -1 && WPILibExtrasIndex != -1 && NTIndex != -1)
            {
                found = true;
            }
        }

        public void Patch(string wpilibVersion, string extrasVersion, string ntVersion)
        {
            if (found)
            {
                file[WPILibIndex] = $"      <package id=\"FRC.WPILib\" version=\"{wpilibVersion}\"/>";
                file[WPILibExtrasIndex] = $"      <package id=\"FRC.WPILib.Extras\" version=\"{extrasVersion}\"/>";
                file[NTIndex] = $"      <package id=\"FRC.NetworkTables\" version=\"{ntVersion}\"/>";
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
