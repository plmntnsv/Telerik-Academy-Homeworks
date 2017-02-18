using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Enums;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageVersionTests
    {
        [Test]
        public void Constructor_PassValidParametersAndCheckIfMajorParameterIsAssignedCorrectly_ShouldPass()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, patch, type);

            // Assert
            Assert.AreEqual(major, packageVersion.Major);
        }

        [Test]
        public void Constructor_PassValidParametersAndCheckIfMinorParameterIsAssignedCorrectly_ShouldPass()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, patch, type);

            // Assert
            Assert.AreEqual(minor, packageVersion.Minor);
        }

        [Test]
        public void Constructor_PassValidParametersAndCheckIfPatchParameterIsAssignedCorrectly_ShouldPass()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, patch, type);

            // Assert
            Assert.AreEqual(patch, packageVersion.Patch);
        }

        [Test]
        public void Constructor_PassValidParametersAndCheckIfVersionTypeParameterIsAssignedCorrectly_ShouldPass()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, patch, type);

            // Assert
            Assert.AreEqual(type, packageVersion.VersionType);
        }

        [Test]
        public void Properties_PassValidParameters_ShouldPassCorrectly()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act & Assert
            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, type));
        }

        [Test]
        public void Properties_PassInvalidMajorParameter_ShouldThrowArgumentException()
        {
            // Arrange
            int major = -5;
            int minor = 4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, type));
        }

        [Test]
        public void Properties_PassInvalidMinorParameter_ShouldThrowArgumentException()
        {
            // Arrange
            int major = 5;
            int minor = -4;
            int patch = 3;
            VersionType type = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, type));
        }

        [Test]
        public void Properties_PassInvalidPatchParameter_ShouldThrowArgumentException()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = -3;
            VersionType type = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, type));
        }

        [Test]
        public void Properties_PassInvalidVersionTypeParameter_ShouldThrowArgumentException()
        {
            // Arrange
            int major = 5;
            int minor = 4;
            int patch = -3;
            VersionType type = (VersionType)5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, type));
        }
    }
}
