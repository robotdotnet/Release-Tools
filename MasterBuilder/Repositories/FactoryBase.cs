using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterBuilder.Packages;

namespace MasterBuilder.Repositories
{
    public abstract class FactoryBase
    {
        public abstract Package NuGetPackage { get; protected set; }
        public abstract Package AppVeyorPackage { get; protected set; }

        public bool IsNuGetNewest()
        {
            return NuGetPackage.Version == AppVeyorPackage.Version;
        }

        public async Task DownloadAllPackages()
        {
            await Task.WhenAll(NuGetPackage.DownloadNewestPackage(), AppVeyorPackage.DownloadNewestPackage());
        }
    }
}
