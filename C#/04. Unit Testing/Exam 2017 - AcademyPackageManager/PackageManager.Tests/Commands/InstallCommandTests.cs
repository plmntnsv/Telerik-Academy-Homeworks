using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Commands;
using PackageManager.Tests.Commands.Mocks;
using PackageManager.Enums;

namespace PackageManager.Tests.Commands
{
    [TestFixture]
    public class InstallCommandTests
    {
        [Test]
        public void Constructor_ProvideValidParameters_ShouldNotThrow()
        {
            // Arrange
            var installerStub = new Mock<IInstaller<IPackage>>();

            var packageStub = new Mock<IPackage>();

            // Act & Assert
            Assert.DoesNotThrow(() => new InstallCommand(installerStub.Object, packageStub.Object));
        }

        [Test]
        public void Constructor_ProvideInvalidNullInstallerParameter_ShouldThrowArgumentNullException()
        {
            // Arrange
            var packageStub = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageStub.Object));
        }

        [Test]
        public void Constructor_ProvideInvalidNullPackageParameter_ShouldThrowArgumentNullException()
        {
            // Arrange
            var installerStub = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerStub.Object, null));
        }

        [Test]
        public void Fields_ProvideValidInstallerParameter_ShouldAssignItCorrectly()
        {
            // Arrange
            var installerStub = new Mock<IInstaller<IPackage>>();

            var packageStub = new Mock<IPackage>();

            //Act
            var installerCommand = new ExtendedInstallCommand(installerStub.Object, packageStub.Object);

            // Assert
            Assert.AreSame(installerStub.Object, installerCommand.InstallerExposer);
        }

        [Test]
        public void Fields_ProvideValidPackageParameter_ShouldAssignItCorrectly()
        {
            // Arrange
            var installerStub = new Mock<IInstaller<IPackage>>();

            var packageStub = new Mock<IPackage>();

            //Act
            var installerCommand = new ExtendedInstallCommand(installerStub.Object, packageStub.Object);

            // Assert
            Assert.AreSame(packageStub.Object, installerCommand.PackageExposer);
        }

        [Test]
        public void Properties_CheckIfOperationIsAssignedCorrectly_ShouldReturnInstall()
        {
            // Arrange
            var installerStub = new Mock<IInstaller<IPackage>>();

            var packageStub = new Mock<IPackage>();

            //Act
            var installerCommand = new ExtendedInstallCommand(installerStub.Object, packageStub.Object);

            // Assert
            Assert.AreEqual(InstallerOperation.Install, installerCommand.InstallerExposer.Operation);
        }

        [Test]
        public void Execute_CallPerformOperationOnTheInstaller_ShouldBeCalledOnce()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(i => i.PerformOperation(It.IsAny<IPackage>()));

            var packageStub = new Mock<IPackage>();

            var installerCommand = new ExtendedInstallCommand(installerMock.Object, packageStub.Object);

            //Act
            installerCommand.Execute();

            // Assert
            installerMock.Verify(i => i.PerformOperation(It.IsAny<IPackage>()), Times.Once);
        }
    }
}
