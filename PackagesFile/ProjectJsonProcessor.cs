using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NuGetPackageVisualizer.PackagesFile
{
    internal class ProjectJsonProcessor : IPackageFileProcessor
    {
        public IEnumerable<DependencyViewModel> Packages(string filePath)
        {
            JObject dependencies ;

            using (var input = File.OpenText(filePath))
            {
                var projects = JObject.Parse(input.ReadToEnd());

                dependencies = (JObject) projects["dependencies"];
            }

            foreach (var package in dependencies.Properties())
            {
                var id = package.Name;
                var version = (string)package.Value;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(version)) continue;

                yield return new DependencyViewModel {NugetId = id, Version = version};
            }
        }
    }
}
