using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterBuilder.Packages;

namespace MasterBuilder.Repositories
{
    public class NetworkTablesFactory : FactoryBase
    {
        public override Package NuGetPackage { get; protected set; }

        public override Package AppVeyorPackage { get; protected set; }

        public const string PackageId = "FRC.NetworkTables";
        public const string NuGetUrl = "https://packages.nuget.org/api/v2";
        public const string AppVeyorUrl = "https://ci.appveyor.com/nuget/networktablescore-appveyor";

        public const string NuGetFolder = "NuGet";
        public const string AppVeyorFolder = "AppVeyor";


        public NetworkTablesFactory()
        {
            NuGetPackage = new Package(PackageId, NuGetUrl, NuGetFolder);
            AppVeyorPackage = new Package(PackageId, AppVeyorUrl, AppVeyorFolder);
        }
    }
}
