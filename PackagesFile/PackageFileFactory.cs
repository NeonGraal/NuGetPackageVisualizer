using System;
using System.IO;
using JetBrains.Annotations;

namespace NuGetPackageVisualizer.PackagesFile
{
    class PackageFileFactory
    {
        public static IPackageFileProcessor CreateProcessor([NotNull] string file)
        {
            if (Path.GetFileName(file).Equals("packages.config", StringComparison.CurrentCultureIgnoreCase))
            {
                return new PackagesConfigProcessor();
            }

            if (Path.GetFileName(file).Equals("project.json", StringComparison.CurrentCultureIgnoreCase))
            {
                return new ProjectJsonProcessor();
            } 
            
            if (Path.GetExtension(file).Equals(".csproj", StringComparison.CurrentCultureIgnoreCase))
            {
                return new CsProjProcessor();
            }

            return new UnknownProcessor();
        }
    }
}
