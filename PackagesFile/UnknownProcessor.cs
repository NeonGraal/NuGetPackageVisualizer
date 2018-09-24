using System;
using System.Collections.Generic;
using NuGetPackageVisualizer.NuGetService;

namespace NuGetPackageVisualizer.PackagesFile
{
    class UnknownProcessor : IPackageFileProcessor
    {
        public IEnumerable<DependencyViewModel> Packages(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
