using PackageManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.Mocks
{
    internal class ExtendedPackageInstaller : PackageInstaller
    {
        public ExtendedPackageInstaller(IDownloader downloader, IProject project) : base(downloader, project)
        {
        }

        public bool IsItCalled { get; set; }

        public override void PerformOperation(IPackage package)
        {
            this.IsItCalled = true;
        }
    }
}
