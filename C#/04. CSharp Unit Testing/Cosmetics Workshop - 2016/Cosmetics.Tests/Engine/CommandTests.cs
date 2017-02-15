using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ShouldReturnNewCommand_WhenProvidedValidInput()
        {
            // Arrange
            string input = "Name";

            // Act
            var result = Command.Parse(input);

            // Assert
            Assert.IsInstanceOf<ICommand>(result);
        }

        [Test]
        public void Parse_ShouldSetNameCorrectlyOfNewlyCreatedCommandObjects_WhenProvidedValidInput()
        {
            // Arrange
            string commandToParse = "Name ParameterOne ParameterTwo",
                   expectedName = "Name";

            // Act
            var result = Command.Parse(commandToParse);

            // Assert
            Assert.AreEqual(expectedName, result.Name);
        }

        [Test]
        public void Parse_ShouldSetParametersCorrectlyOfNewlyCreatedCommandObjects_WhenProvidedValidInput()
        {
            // Arrange
            string commandToParse = "Name ParameterOne ParameterTwo",
                   expectedParameterOne = "ParameterOne",
                   expectedParameterTwo = "ParameterTwo";

            // Act
            var result = Command.Parse(commandToParse);

            // Assert
            Assert.Contains(expectedParameterOne, result.Parameters.ToList());
            Assert.Contains(expectedParameterTwo, result.Parameters.ToList());
        }

        [Test]
        public void Parse_ShouldThrowNullReferenceException_WhenProvidedNullInput()
        {
            // Arrange
            string commandToParse = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(commandToParse));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullException_WhenProvidedEmptyNameInput()
        {
            // Arrange
            string commandToParse = string.Empty;
            string expectedMsg = "Name";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => Command.Parse(commandToParse));
            var excMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedMsg, excMsg);
            //Assert.That(() => Command.Parse(commandToParse), Throws.ArgumentNullException.With.Message.Contains(expectedMsg));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenProvidedInvalidNameInput()
        {
            // Arrange
            string commandToParse = " Parameters";
            string expectedMsg = "Name";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => Command.Parse(commandToParse));
            var excMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedMsg, excMsg);
            //Assert.That(() => Command.Parse(commandToParse), Throws.ArgumentNullException.With.Message.Contains(expectedMsg));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullException_WhenProvidedEmptyParameterInput()
        {
            // Arrange
            string commandToParse = "Name ";
            string expectedMsg = "List";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => Command.Parse(commandToParse));
            var excMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedMsg, excMsg);
            //Assert.That(() => Command.Parse(commandToParse), Throws.ArgumentNullException.With.Message.Contains(expectedMsg));
        }
    }
}
