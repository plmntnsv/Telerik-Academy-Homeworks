using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    [Category("Business owner")]

    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerProfitsFromAllHisTeleportationStationsPayments_ShouldCollectAccurateBronzeCoins()
        {
            // Arrange
            var resourcesMock = new Mock<IResources>();
            resourcesMock.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesMock.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportStationMock = new Mock<ITeleportStation>();
            teleportStationMock.Setup(t => t.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesMock.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation>() { teleportStationMock.Object });

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(10, owner.Resources.BronzeCoins);
        }

        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerProfitsFromAllHisTeleportationStationsPayments_ShouldCollectAccurateSilverCoins()
        {
            // Arrange
            var resourcesMock = new Mock<IResources>();
            resourcesMock.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesMock.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportStationMock = new Mock<ITeleportStation>();
            teleportStationMock.Setup(t => t.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesMock.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation>() { teleportStationMock.Object });

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(20, owner.Resources.SilverCoins);
        }

        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerProfitsFromAllHisTeleportationStationsPayments_ShouldCollectAccurateGoldCoins()
        {
            // Arrange
            var resourcesMock = new Mock<IResources>();
            resourcesMock.SetupGet(r => r.BronzeCoins).Returns(10);
            resourcesMock.SetupGet(r => r.SilverCoins).Returns(20);
            resourcesMock.SetupGet(r => r.GoldCoins).Returns(30);

            var teleportStationMock = new Mock<ITeleportStation>();
            teleportStationMock.Setup(t => t.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesMock.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation>() { teleportStationMock.Object });

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(30, owner.Resources.GoldCoins);
        }
    }
}
