using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Repositories.Mocks
{
    internal class ExtendedPackageRepository : PackageRepository
    {
        public ExtendedPackageRepository(ILogger logger, ICollection<IPackage> packages = null) : base(logger, packages)
        {
        }

        public override bool Update(IPackage package)
        {
            return true;
        }
    }
}
