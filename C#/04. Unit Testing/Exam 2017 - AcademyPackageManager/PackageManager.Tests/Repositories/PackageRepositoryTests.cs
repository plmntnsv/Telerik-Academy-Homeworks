using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Repositories;
using PackageManager.Models.Contracts;
using PackageManager.Enums;
using PackageManager.Tests.Repositories.Mocks;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    public class PackageRepositoryTests
    {
        [Test]
        public void Add_ProvideValidPackage_ShouldNotThrow()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => packageRepository.Add(packageMock.Object));
        }

        [Test]
        public void Add_ProvideInvalidPackage_ShouldThrowArgumentNullException_WithExpectedMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var packageRepository = new PackageRepository(loggerMock.Object);

            string expectedMsg = "The package cannot be null";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));
            string actualMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedMsg, actualMsg);
        }

        [Test]
        public void Add_ProvideValidPackageThatIsNotAlreadyInThePackages_ItShouldBeAdded()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.IsAny<string>()));

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            var result = packageRepository.GetAll();

            // Assert
            CollectionAssert.Contains(result, packageMock.Object);
        }

        [Test]
        public void Add_ProvideValidPackageThatAlreadyExistsWithTheSameVersionInThePackages_ItShouldLogExpectedMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            packageRepository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.Is<string>(s => s == "PackageOne: Package with the same version is already installed!")), Times.Once);
        }

        [Test]
        public void Add_ProvideValidPackageThatAlreadyExistsWithDifferentVersionInThePackages_ItShouldUpdate()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionOneMock = new Mock<IVersion>();

            var versionTwoMock = new Mock<IVersion>();

            var packageOneMock = new Mock<IPackage>();
            packageOneMock.SetupGet(p => p.Name).Returns("Name");
            packageOneMock.SetupGet(p => p.Version).Returns(versionOneMock.Object);

            var packageTwoMock = new Mock<IPackage>();
            packageTwoMock.SetupGet(p => p.Name).Returns("Name");
            packageTwoMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageOneMock.Object);
            packageRepository.Add(packageTwoMock.Object);

            // Assert
            packageTwoMock.Verify(p => p.Version, Times.Once);
        }

        [Test]
        public void Add_ProvideValidPackageThatAlreadyExistsWithLowerVersionInThePackages_ShouldLogExpectedMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionOneMock = new Mock<IVersion>();

            var versionTwoMock = new Mock<IVersion>();

            var packageOneMock = new Mock<IPackage>();
            packageOneMock.SetupGet(p => p.Name).Returns("Name");
            packageOneMock.SetupGet(p => p.Version).Returns(versionOneMock.Object);

            var packageTwoMock = new Mock<IPackage>();
            packageTwoMock.SetupGet(p => p.Name).Returns("Name");
            packageTwoMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageOneMock.Object);
            packageRepository.Add(packageTwoMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.Is<string>(s => s == "Name: There is a package with newer version!")), Times.Once);
        }

        [Test]
        public void Delete_PassValidPackage_ShouldPass()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            packageRepository.Delete(packageMock.Object);

            // Assert
            CollectionAssert.DoesNotContain(packageRepository.GetAll(), packageMock.Object);
        }

        [Test]
        public void Delete_PassInvalidNullPackage_ShouldThrowArgumentNullException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(null));
        }

        [Test]
        public void Delete_PassValidPackageWithDependencies_ShouldFailToDelete_LogMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>() { packageMock.Object });

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            packageRepository.Delete(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.Is<string>(s => s == "PackageOne: The package is a dependency and could not be removed!")));
        }

        [Test]
        public void Delete_PassValidPackage_ShouldReturnThePackage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>() { packageMock.Object });

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            var result = packageRepository.Delete(packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, result);
        }

        [Test]
        public void Update_PassValidPackage_ShouldPass()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);

            // Assert            
            Assert.IsTrue(packageRepository.Update(packageMock.Object));
        }

        [Test]
        public void Update_PassInvalidNullPackage_ShouldThrowArgumentNullException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Update(null));
        }

        [Test]
        public void Update_PassValidPackageThatIsNotInThePackages_ShouldThrowArgumentNullException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Update(packageMock.Object));
        }

        [Test]
        public void Update_PassValidPackageWithHigherVersionThanTheOneInPackages_ShouldTryToChangeVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);
            packageMock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);
            packageRepository.Update(packageMock.Object);

            // Assert
            packageMock.Verify(p => p.Version, Times.Once);
        }

        [Test]
        public void Update_PassValidPackageWithLowerVersionThanTheOneInPackages_ShouldLogMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => packageRepository.Update(packageMock.Object));
            loggerMock.Verify(l => l.Log(It.Is<string>(s => s == "PackageOne: The package has higher version than you are trying to install!")), Times.Once);
        }

        [Test]
        public void Update_PassValidPackageWithSameVersion_ShouldLogMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(l => l.Log(It.Is<string>(s => s == "PackageOne: The package was added!")));

            var versionMock = new Mock<IVersion>();
            versionMock.SetupGet(v => v.Major).Returns(1);
            versionMock.SetupGet(v => v.Minor).Returns(1);
            versionMock.SetupGet(v => v.Patch).Returns(1);
            versionMock.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(p => p.Name).Returns("PackageOne");
            packageMock.SetupGet(p => p.Version).Returns(versionMock.Object);
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);

            // Assert
            Assert.IsFalse(packageRepository.Update(packageMock.Object));
            loggerMock.Verify(l => l.Log(It.Is<string>(s => s == "PackageOne: Package with the same version is already installed!")), Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnEmptyCollection_WhenNoCollectionIsAvailable()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            var result = packageRepository.GetAll();

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void GetAll_ShouldReturnCollectionWithSameCount_WhenCollectionIsAvailable()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageTwoMock = new Mock<IPackage>();

            var packageRepository = new PackageRepository(loggerMock.Object, new HashSet<IPackage>() { packageMock.Object, packageTwoMock.Object });

            // Act
            var result = packageRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
