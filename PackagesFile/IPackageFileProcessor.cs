using System.Collections.Generic;
using NuGetPackageVisualizer.NuGetService;

namespace NuGetPackageVisualizer.PackagesFile
{
    public interface IPackageFileProcessor
    {
        IEnumerable<DependencyViewModel> Packages(string filePath);
    }
}