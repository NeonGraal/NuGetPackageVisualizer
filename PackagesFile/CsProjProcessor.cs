using System.Collections.Generic;
using System.Xml.Linq;

namespace NuGetPackageVisualizer.PackagesFile
{
    internal class CsProjProcessor : IPackageFileProcessor
    {
        public IEnumerable<DependencyViewModel> Packages(string filePath)
        {
            var csProj = XDocument.Load(filePath);

            foreach (var package in csProj.Descendants("PackageReference"))
            {
                var id = package.Attribute("Include")?.Value;
                var version = package.Attribute("Version")?.Value;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(version)) continue;

                yield return new DependencyViewModel {NugetId = id, Version = version};
            }
        }
    }
}
