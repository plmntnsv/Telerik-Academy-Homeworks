using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Repositories.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Models;
using PackageManager.Repositories;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Constructor_PassValidNameAndCheckIfItIsCorrect_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreSame(name, project.Name);
        }

        [Test]
        public void Constructor_PassInvalidNullName_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = null;
            string location = "ValidLocation";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location));
        }

        [Test]
        public void Constructor_PassValidLocationAndCheckIfItIsCorrect_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreSame(location, project.Location);
        }

        [Test]
        public void Constructor_PassInvalidNullLocation_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = "ValidName";
            string location = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location));
        }

        [Test]
        public void Constructor_PassValidParametersWithOptionalNullPackages_CheckIfReturnsCorrectInstance()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void Constructor_PassValidPackages_CheckIfAssignedCorrectly()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            var repositoryMock = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(name, location, repositoryMock.Object);

            // Assert
            Assert.AreSame(repositoryMock.Object, project.PackageRepository);
        }

        [Test]
        public void Properties_AssignValidNameCheckIfItIsSetCorrectly_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreEqual(name, project.Name);
        }

        [Test]
        public void Properties_AssignValidLocationCheckIfItIsSetCorrectly_ShouldBeCorrect()
        {
            // Arrange
            string name = "ValidName";
            string location = "ValidLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreEqual(location, project.Location);
        }
    }
}
