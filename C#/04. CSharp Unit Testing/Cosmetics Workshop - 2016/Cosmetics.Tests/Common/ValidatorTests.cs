using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Cosmetics.Common;

namespace Cosmetics.Tests.Common
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ValidateIfObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            object objectToTest = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(objectToTest));
        }

        [Test]
        public void CheckIfNull_ValidateIfObjectIsNull_ShouldNotThrow()
        {
            // Arrange
            object objectToTest = new object();

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(objectToTest));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenProvidedStringIsNull()
        {
            // Arrange
            string testString = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(testString));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenProvidedStringIsEmpty()
        {
            // Arrange
            string testString = string.Empty;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(testString));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrow_WhenProvidedStringIsValid()
        {
            // Arrange
            string testString = "valid";

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(testString));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_WhenProvidedStringWithLowerLengthThanTheMinimum()
        {
            // Arrange
            string testString = "a";

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(testString, 10, 5));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_WhenProvidedStringWithGreaterLengthThanTheMaximum()
        {
            // Arrange
            string testString = "LongerThanTheMax";

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(testString, 10, 5));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldNotThrowIndexOutOfRangeException_WhenProvidedStringIsWithinBoundaries()
        {
            // Arrange
            string testString = "valid";

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(testString, 8, 3));
        }
    }

}
