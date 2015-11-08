using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NuGet;

namespace MasterBuilder.Packages
{
    public class Package
    {
        public string PackageId { get; }
        public string RepositoryUrl { get; }
        public string OutputFolder { get; }

        public SemanticVersion Version { get; private set; } = null;

        public Package(string packageId, string repositoryUrl, string outputFolder)
        {
            PackageId = packageId;
            RepositoryUrl = repositoryUrl;
            OutputFolder = outputFolder;
        }

        public async Task DownloadNewestPackage()
        {
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository(RepositoryUrl);
            List<IPackage> packages = repo.FindPackagesById(PackageId).Where(item => item.IsLatestVersion).ToList();

            if (packages.Count > 0)
            {
                IPackage package = packages[0];
                Version = package.Version;
                using (WebClient client = new WebClient())
                {
                    Directory.CreateDirectory(OutputFolder);
                    await client.DownloadFileTaskAsync(((DataServicePackage)package).DownloadUrl.AbsoluteUri, 
                        $"{OutputFolder}{Path.DirectorySeparatorChar}{package.Id}.{Version}.nupkg");
                }
            }
            else
            {
                throw new FileNotFoundException($"Could not find the newest {PackageId} on {RepositoryUrl}.");
            }
        }
    }
}
