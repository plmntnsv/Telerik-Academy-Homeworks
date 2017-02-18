using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Core;
using PackageManager.Tests.Core.Mocks;

namespace PackageManager.Tests.Core
{
    [TestFixture]
    public class PackageInstallerTests
    {
        [Test]
        public void Constructor_ShouldRestorePackages_WhenConstructed()
        {
            // Arrange
            var downloadMock = new Mock<IDownloader>();
            downloadMock.Setup(d => d.Download(It.IsAny<string>()));
            downloadMock.Setup(d => d.Remove(It.IsAny<string>()));

            var packageDependencyMock = new Mock<IPackage>();
            packageDependencyMock.SetupGet(p => p.Name).Returns("DependencyName");
            packageDependencyMock.SetupGet(p => p.Url).Returns("DependencyUrl");
            packageDependencyMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { });

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("Name");
            packageMock.SetupGet(p => p.Url).Returns("URLURL");
            packageMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { packageDependencyMock.Object });
                        
            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            projectMock.Setup(p => p.PackageRepository.Add(It.IsAny<IPackage>()));


            // Act
            var packageInstaller = new PackageInstaller(downloadMock.Object, projectMock.Object);

            // Assert
            projectMock.Verify(p => p.PackageRepository.Add(It.Is<IPackage>(x => x == packageMock.Object)), Times.Once);
            projectMock.Verify(p => p.PackageRepository.Add(It.Is<IPackage>(x => x == packageDependencyMock.Object)), Times.Once);
        }

        [Test]
        public void Constructor_ShouldCallRestorePackagesMethod_WhenConstructed()
        {
            // Arrange
            var downloadMock = new Mock<IDownloader>();

            var packageDependencyMock = new Mock<IPackage>();

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { packageDependencyMock.Object });

            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });


            // Act
            var packageInstaller = new ExtendedPackageInstaller(downloadMock.Object, projectMock.Object);

            // Assert
            Assert.IsTrue(packageInstaller.IsItCalled);
        }

        [Test]
        public void PerformOperation_WithInstallCommandAndEmptyDependencies_ShouldCallDownloadTwiceAndRemoveOnce()
        {
            // Arrange
            var downloadMock = new Mock<IDownloader>();
            downloadMock.Setup(d => d.Download(It.IsAny<string>()));
            downloadMock.Setup(d => d.Remove(It.IsAny<string>()));

            var packageDependencyMock = new Mock<IPackage>();

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("Name");
            packageMock.SetupGet(p => p.Url).Returns("URLURL");
            packageMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { });

            var packageRepo = new List<IPackage>();

            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            projectMock.Setup(p => p.PackageRepository.Add(It.IsAny<IPackage>()));

            // Act
            var packageInstaller = new PackageInstaller(downloadMock.Object, projectMock.Object);

            // Assert
            downloadMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(2));
            downloadMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PerformOperation_WithInstallCommandAndOneDependency_ShouldCallDownloadFourTimesAndRemoveTwice()
        {
            // Arrange
            var downloadMock = new Mock<IDownloader>();
            downloadMock.Setup(d => d.Download(It.IsAny<string>()));
            downloadMock.Setup(d => d.Remove(It.IsAny<string>()));

            var packageDependencyMock = new Mock<IPackage>();
            packageDependencyMock.SetupGet(p => p.Name).Returns("DependencyName");
            packageDependencyMock.SetupGet(p => p.Url).Returns("DependencyUrl");
            packageDependencyMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { });

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("Name");
            packageMock.SetupGet(p => p.Url).Returns("URLURL");
            packageMock.SetupGet(p => p.Dependencies).Returns(new HashSet<IPackage>() { packageDependencyMock.Object });

            var packageRepo = new List<IPackage>();

            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            projectMock.Setup(p => p.PackageRepository.Add(It.IsAny<IPackage>()));

            // Act
            var packageInstaller = new PackageInstaller(downloadMock.Object, projectMock.Object);

            // Assert
            downloadMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(4));
            downloadMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
