using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterBuilder.Packages;
using MasterBuilder.Repositories;

namespace MasterBuilder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private readonly NetworkTablesFactory m_ntFactory = new NetworkTablesFactory();
        private readonly WPILibFactory m_wpiFactory = new WPILibFactory();

        private async void LoadPackagesButton_Click(object sender, EventArgs e)
        {
            LoadPackagesButton.Enabled = false;
            try
            {
                await Task.WhenAll(m_ntFactory.DownloadAllPackages(), m_wpiFactory.DownloadAllPackages());
            }
            catch (Exception xe)
            {
                Console.WriteLine(xe.StackTrace);
                throw;
            }
            LoadPackagesButton.Enabled = true;
        }

        const string GitLocation = @"C:\Program Files (x86)\Git\bin\git.exe";

        private async void UpdateSubmodulesButton_Click(object sender, EventArgs e)
        {
            UpdateSubmodulesButton.Enabled = false;

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = GitLocation;
            processStartInfo.Arguments = "submodule foreach git pull origin master";

            Process p = Process.Start(processStartInfo);

            var tcs = new TaskCompletionSource<object>();
            p.EnableRaisingEvents = true;
            p.Exited += (o, args) => tcs.TrySetResult(null);
            await tcs.Task;

            UpdateSubmodulesButton.Enabled = true;
        }

        private void CheckForNewestUploadedNuGetButton_Click(object sender, EventArgs e)
        {
            bool isNTValid = m_ntFactory.IsNuGetNewest();
            bool isWPIValid = m_wpiFactory.IsNuGetNewest();

            if (isNTValid)
            {
                NTLabel.Text = "Network Tables is already newest";
            }
            else
            {
                NTLabel.Text =
                    $"Network Table Not Newest: NuGet:{m_ntFactory.NuGetPackage.Version}, AppVeyor:{m_ntFactory.AppVeyorPackage.Version}.";
            }

            if (isWPIValid)
            {
                WPILibLabel.Text = "WPILib is already newest";
            }
            else
            {
                WPILibLabel.Text =
                    $"WPILib Not Newest: NuGet:{m_wpiFactory.NuGetPackage.Version}, AppVeyor:{m_wpiFactory.AppVeyorPackage.Version}.";
            }
        }

        private void publishNTButton_Click(object sender, EventArgs e)
        {
            bool isNTValid = m_ntFactory.IsNuGetNewest();

            if (isNTValid) return;

            //Move package to updated.
        }
    }
}
