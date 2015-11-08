using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void updateWPILibButton_Click(object sender, EventArgs e)
        {
            SubmoduleUpdater.UpdateWPILibSubmodule();
        }

        private void updateNTButton_Click(object sender, EventArgs e)
        {
            SubmoduleUpdater.UpdateNTSubmodule();
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
    }
}
