using Academy.Tests.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests
{
    [TestFixture]
    [Category("User")]
    public class AbstractUserTests
    {
        [Test]
        public void SetConsturcor_ShouldAssignPassedValues_Correctly()
        {
            // Arrange
            var expectedName = "Valid name";

            // Act
            var user = new UserMock(expectedName);

            // Assert
            Assert.AreEqual(expectedName, user.Username);
        }

        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("a")]
        [TestCase("aVeryLongNameThatShouldThrowExceptionBecauseItIsLongerThanSixteenCharachters")]
        public void Username_ShouldThrowArgumentException_WhenPassedValuesAreInvalid(string username)
        {
            // Arrange
            var expectedName = username;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new UserMock(expectedName));
        }

        [Test]
        public void Username_ShouldNotThrowArgumentException_WhenPassedValuesAreValid()
        {
            // Arrange
            var expectedName = "Valid name";

            // Act & Assert
            Assert.DoesNotThrow(() => new UserMock(expectedName));
        }

        [Test]
        public void Username_ShouldSetCorrectName_WhenProvidedNameIsValid()
        {
            // Arrange
            var expectedName = "A name";
            var secondExpectedName = "B name";
            var user = new UserMock(expectedName);

            // Act
            user.Username = secondExpectedName;

            // Assert
            Assert.AreEqual(secondExpectedName, user.Username);
        }
    }
}
