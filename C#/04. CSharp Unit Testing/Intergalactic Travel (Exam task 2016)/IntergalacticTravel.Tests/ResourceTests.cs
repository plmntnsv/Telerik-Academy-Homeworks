using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    [Category("Resources")]
    public class ResourceTests
    {
        [TestCase("gold(20) silver(30) bronze(40)")]
        [TestCase("gold(20) bronze(40) silver(30)")]
        [TestCase("silver(30) bronze(40) gold(20)")]
        [TestCase("silver(30) gold(20) bronze(40)")]
        [TestCase("bronze(40) gold(20) silver(30)")]
        [TestCase("bronze(40) silver(30) gold(20)")]
        public void GetResources_ShouldReturnNewlyCreatedResourcesWithCorrectlySetUpProperties_WhenTheInputStringIsInTheCorrectFormat(string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act
            var resources = resourceFactory.GetResources("create resources " + command);

            // Assert
            Assert.AreEqual(40, resources.BronzeCoins);
            Assert.AreEqual(30, resources.SilverCoins);
            Assert.AreEqual(20, resources.GoldCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_ShouldThrowInvalidOperationException_WhenInputStringIsInvalidCommand(string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();
            
            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => resourceFactory.GetResources(command));
            var expectedMessage = "command";
            var actualMessage = exception.Message;

            // Assert
            //Assert.IsTrue(exception.Message.Contains(expectedMessage));
            StringAssert.Contains(expectedMessage, actualMessage);            
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ShouldThrowOverflowException_WhenTheInputCommandIsCorrect_ButTheResourceAmountsAreTooBig(string command)
        {
            var resourceFactory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(() => resourceFactory.GetResources(command));
        }
    }
}
