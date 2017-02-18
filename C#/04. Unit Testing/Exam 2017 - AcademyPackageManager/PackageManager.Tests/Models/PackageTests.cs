using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Models.Contracts;
using PackageManager.Models;
using PackageManager.Enums;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void Constructor_AssignValidNameAndCheckIfItIsCorrect_ShouldAssignItCorrectly()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.AreSame(name, package.Name);
        }

        [Test]
        public void Constructor_AssignInvalidNullName_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = null;
            var versionStub = new Mock<IVersion>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, versionStub.Object));
        }

        [Test]
        public void Constructor_AssignValidVersionAndCheckIfItIsCorrect_ShouldAssignItCorrectly()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.AreSame(versionStub.Object, package.Version);
        }

        [Test]
        public void Constructor_AssignInvalidNullVersion_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = "ValidName";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, null));
        }

        [Test]
        public void Constructor_PassValidParametersWithDefaultDependenciesParameter_ShouldCreateValidInstanceForDependencies()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void Constructor_PassValidParametersWithDependenciesParameter_ShouldAssignDependenciesCorrectly()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(name, versionStub.Object, dependenciesMock.Object);

            // Assert
            Assert.AreSame(dependenciesMock.Object, package.Dependencies);
        }

        [Test]
        public void Properties_PassValidNameParameterAndCheckIfItIsSetCorrectly_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.AreEqual(name, package.Name);
        }

        [Test]
        public void Properties_PassValidVersionParameterAndCheckIfItIsSetCorrectly_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.AreEqual(versionStub.Object, package.Version);
        }

        [Test]
        public void Properties_PassValidParametersAndCheckIfUrlIsSetCorrectly_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            var versionStub = new Mock<IVersion>();
            versionStub.SetupGet(v => v.Major).Returns(3);
            versionStub.SetupGet(v => v.Minor).Returns(2);
            versionStub.SetupGet(v => v.Patch).Returns(1);
            versionStub.SetupGet(v => v.VersionType).Returns((VersionType)1);

            string expectedUrl = "3.2.1-" + (VersionType)1;

            // Act
            var package = new Package(name, versionStub.Object);

            // Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }

        [Test]
        public void CompareTo_ProvideValidPackageArgument_ShouldNotThrow()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(3);
            versionOneStub.SetupGet(v => v.Minor).Returns(2);
            versionOneStub.SetupGet(v => v.Patch).Returns(1);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(6);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => package.CompareTo(otherPackageMock.Object));
        }

        [Test]
        public void CompareTo_ProvideInvalidNullPackageArgument_ShouldThrowArgumentNullExceptionWithExpectedMessage()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();

            var package = new Package(name, versionOneStub.Object);

            var expectedMesage = "cannot be null";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
            var actualMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedMesage, actualMessage);
        }

        [Test]
        public void CompareTo_ProvideValidPackageArgumentButWithDifferentName_ShouldThrowArgumentException()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("SomeOtherName");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackageMock.Object));
        }

        [Test]
        public void CompareTo_ProvideValidPackageArgumentWithHigherVersion_ShouldReturnAppropriateResult()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(3);
            versionOneStub.SetupGet(v => v.Minor).Returns(2);
            versionOneStub.SetupGet(v => v.Patch).Returns(1);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(6);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act
            int result = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareTo_ProvideValidPackageArgumentWithLowerVersion_ShouldReturnAppropriateResult()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(6);
            versionOneStub.SetupGet(v => v.Minor).Returns(5);
            versionOneStub.SetupGet(v => v.Patch).Returns(4);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(3);
            versionTwoStub.SetupGet(v => v.Minor).Returns(2);
            versionTwoStub.SetupGet(v => v.Patch).Returns(1);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)1);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act
            int result = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareTo_ProvideValidPackageArgumentWithSameVersion_ShouldReturnAppropriateResult()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(6);
            versionOneStub.SetupGet(v => v.Minor).Returns(5);
            versionOneStub.SetupGet(v => v.Patch).Returns(4);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(6);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act
            int result = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Equals_PassValidObjectArgument_ShouldNotThrow()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(6);
            versionOneStub.SetupGet(v => v.Minor).Returns(5);
            versionOneStub.SetupGet(v => v.Patch).Returns(4);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(6);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => package.Equals(otherPackageMock.Object));
        }

        [Test]
        public void Equals_PassInvalidNullObjectArgument_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();

            var package = new Package(name, versionOneStub.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void Equals_PassInvalidObjectArgumentThatIsNotIPackage_ShouldThrowArgumentExceptionWithMessage()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();

            var package = new Package(name, versionOneStub.Object);

            string invalidObj = "Wow";
            string expectedMessage = "must be IPackage";

            // Act 
            var exc = Assert.Throws<ArgumentException>(() => package.Equals(invalidObj));
            string actualMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [Test]
        public void Equals_PassValidObjectArgumentsThatAreEqual_ShouldReturnCorrectResult()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(6);
            versionOneStub.SetupGet(v => v.Minor).Returns(5);
            versionOneStub.SetupGet(v => v.Patch).Returns(4);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(6);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act
            bool result = package.Equals(otherPackageMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_PassValidObjectArgumentsThatArenotEqual_ShouldReturnCorrectResult()
        {
            // Arrange
            string name = "ValidName";
            var versionOneStub = new Mock<IVersion>();
            versionOneStub.SetupGet(v => v.Major).Returns(6);
            versionOneStub.SetupGet(v => v.Minor).Returns(5);
            versionOneStub.SetupGet(v => v.Patch).Returns(4);
            versionOneStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var versionTwoStub = new Mock<IVersion>();
            versionTwoStub.SetupGet(v => v.Major).Returns(7);
            versionTwoStub.SetupGet(v => v.Minor).Returns(5);
            versionTwoStub.SetupGet(v => v.Patch).Returns(4);
            versionTwoStub.SetupGet(v => v.VersionType).Returns((VersionType)2);

            var package = new Package(name, versionOneStub.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.SetupGet(p => p.Name).Returns("ValidName");
            otherPackageMock.SetupGet(p => p.Version).Returns(versionTwoStub.Object);

            // Act
            bool result = package.Equals(otherPackageMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
