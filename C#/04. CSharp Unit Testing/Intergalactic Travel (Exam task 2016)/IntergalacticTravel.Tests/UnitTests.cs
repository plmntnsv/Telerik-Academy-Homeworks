using System;
using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class UnitTests
    {
        [Test]
        public void Pay_ShouldThrowNullReferenceException_WhenPassedNullObject()
        {
            var unit = new Unit(1, "Name");

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_ShouldDecreaseTheOwnersAmountOfResourcesByTheAmountOfTheCost_WhenPassedValidCostResources()
        {
            // Arrange
            var resourcesStub = new Mock<IResources>();
            resourcesStub.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesStub.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesStub.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportationStationStub = new Mock<ITeleportStation>();
            teleportationStationStub.Setup(t => t.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesStub.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation>() { teleportationStationStub.Object });

            // Act
            owner.CollectProfits();
            owner.Pay(resourcesStub.Object);

            // Assert
            Assert.AreEqual(0, owner.Resources.BronzeCoins);
            Assert.AreEqual(0, owner.Resources.SilverCoins);
            Assert.AreEqual(0, owner.Resources.GoldCoins);
        }

        [Test]
        public void Pay_ShouldResourceObject_WhenPassedValidResources()
        {
            // Arrange
            var resourcesStub = new Mock<IResources>();
            resourcesStub.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesStub.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesStub.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportationStationStub = new Mock<ITeleportStation>();
            teleportationStationStub.Setup(t => t.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesStub.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation>() { teleportationStationStub.Object });

            // Act
            owner.CollectProfits();
            var result = owner.Pay(resourcesStub.Object);

            // Assert
            Assert.IsInstanceOf<IResources>(result);
        }
    }
}
