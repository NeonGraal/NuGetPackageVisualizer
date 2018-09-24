using System.Collections.Generic;
using System.Xml.Linq;

namespace NuGetPackageVisualizer.PackagesFile
{
    internal class PackagesConfigProcessor : IPackageFileProcessor
    {
        public IEnumerable<DependencyViewModel> Packages(string filePath)
        {
            var packagesConfig = XDocument.Load(filePath);

            foreach (var package in packagesConfig.Descendants("package"))
            {
                var id = package.Attribute("id")?.Value;
                var version = package.Attribute("version")?.Value;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(version)) continue;

                yield return new DependencyViewModel {NugetId = id, Version = version};
            }
        }
    }
}
