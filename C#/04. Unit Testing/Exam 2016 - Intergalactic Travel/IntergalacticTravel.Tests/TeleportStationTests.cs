using System;
using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    [Category("TeleportStation")]
    public class TeleportStationTests
    {
        [Test]
        public void SetTeleportStation_ShouldCreateValidStation_WhenValidParametersArePassedToTheConstructor()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var expectedOwner = mockedOwner.Object;
            var expectedPath = mockedPath.Object;
            var expectedLocation = mockedLocation.Object;

            var teleportStation = new TeleportStationMock(expectedOwner, expectedPath, expectedLocation);

            // Act
            var actualOwner = teleportStation.Owner;
            var actualPath = teleportStation.Path;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreSame(expectedOwner, actualOwner);
            Assert.AreSame(expectedPath, actualPath);
            Assert.AreSame(expectedLocation, actualLocation);

        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var expectedOwner = mockedOwner.Object;
            var expectedPath = mockedPath.Object;
            var expectedLocation = mockedLocation.Object;
            var teleportStation = new TeleportStationMock(expectedOwner, expectedPath, expectedLocation);

            var mockedTargetLocation = new Mock<ILocation>();
            var targetLocationObj = mockedTargetLocation.Object;
            var expectedExcMessage = "unitToTeleport";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, targetLocationObj));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenTargetLocationIsNull()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var expectedOwner = mockedOwner.Object;
            var expectedPath = mockedPath.Object;
            var expectedLocation = mockedLocation.Object;
            var teleportStation = new TeleportStationMock(expectedOwner, expectedPath, expectedLocation);

            var mockedTargetUnit = new Mock<IUnit>();
            var targetUnitObj = mockedTargetUnit.Object;
            var expectedExcMessage = "destination";

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(targetUnitObj, null));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeExceptionWithExpectedMessage_WhenTeleportStationIsUsedForADistantLocation()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPlanet = new Mock<IPlanet>();
            var mockedGalaxy = new Mock<IGalaxy>();

            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var teleportStation = new TeleportStationMock(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            var mockedTargetLocation = new Mock<ILocation>();
            var mockedTargetPlanet = new Mock<IPlanet>();
            var mockedTargetGalaxy = new Mock<IGalaxy>();

            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Milky way");
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("Earth");

            var expectedExcMessage = "unitToTeleport.CurrentLocation";

            // Act
            var exc = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationExceptionWithExpectedMessage_WhenTryingToTeleportToAlreadyTakenLocation()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPlanet = new Mock<IPlanet>();
            var mockedGalaxy = new Mock<IGalaxy>();
            var mockedUnit = new Mock<IUnit>();
            var mockedGPS = new Mock<IGPSCoordinates>();

            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);

            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object }, mockedLocation.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            var mockedTargetLocation = new Mock<ILocation>();
            var mockedTargetPlanet = new Mock<IPlanet>();
            var mockedTargetGalaxy = new Mock<IGalaxy>();

            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var expectedExcMessage = "units will overlap";

            // Act
            var exc = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionExceptionWithExpectedMessage_WhenTryingToTeleportToNotExistingGalaxy()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            //
            var mockedGalacticGalaxy = new Mock<IGalaxy>();
            mockedGalacticGalaxy.SetupGet(gg => gg.Name).Returns("Waldo");

            var mockedGalacticPlanet = new Mock<IPlanet>();
            mockedGalacticPlanet.SetupGet(gp => gp.Galaxy).Returns(mockedGalacticGalaxy.Object);

            var mockedGalacticLocation = new Mock<ILocation>();
            mockedGalacticLocation.SetupGet(gloc => gloc.Planet).Returns(mockedGalacticPlanet.Object);

            var mockedGalacticPath = new Mock<IPath>();
            mockedGalacticPath.SetupGet(gp => gp.TargetLocation).Returns(mockedGalacticLocation.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedGalacticPath.Object }, mockedLocation.Object);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);

            var expectedExcMessage = "Galaxy";

            // Act
            var exc = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionExceptionWithExpectedMessage_WhenTryingToTeleportToNotExistingPlanet()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            //

            var mockedGalacticGalaxy = new Mock<IGalaxy>();
            mockedGalacticGalaxy.SetupGet(gg => gg.Name).Returns("Andromeda");

            var mockedGalacticPlanet = new Mock<IPlanet>();
            mockedGalacticPlanet.SetupGet(gp => gp.Galaxy).Returns(mockedGalacticGalaxy.Object);
            mockedGalacticPlanet.SetupGet(gp => gp.Name).Returns("Waldo");

            var mockedGalacticLocation = new Mock<ILocation>();
            mockedGalacticLocation.SetupGet(gloc => gloc.Planet).Returns(mockedGalacticPlanet.Object);

            var mockedGalacticPath = new Mock<IPath>();
            mockedGalacticPath.SetupGet(gp => gp.TargetLocation).Returns(mockedGalacticLocation.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedGalacticPath.Object }, mockedLocation.Object);


            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);

            var expectedExcMessage = "Planet";

            // Act
            var exc = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldThrowInsufficientResourcesExceptionWithExpectedMessage_WhenTryingToTeleportUnitThatCannotPayTheCost()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(20);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(30);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(40);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object }, mockedLocation.Object);

            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            var expectedExcMessage = "FREE LUNCH";

            // Act
            var exc = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));
            var actualExcMsg = exc.Message;

            // Assert
            StringAssert.Contains(expectedExcMessage, actualExcMsg);
        }

        [Test]
        public void TeleportUnit_ShouldRequirePaymentFromTeleportedUnit_WhenAllTheValidationsArePassedSuccessfully()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object }, mockedLocation.Object);

            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Resources());
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });
            mockedUnitToTeleport.Setup(u => u.PreviousLocation);

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object);

            // Assert
            mockedUnitToTeleport.Verify(u => u.Pay(mockedPath.Object.Cost), Times.Once());
        }

        [Test]
        public void TeleportUnit_TeleportStationShouldRequirePaymentForTeleportation_AndTheResourcesOfTheStationMustBeIncreasedByTheCostOfTheTeleportation()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object }, mockedLocation.Object);

            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockTargetUnitResources = new Mock<IResources>();
            mockTargetUnitResources.Setup(r => r.BronzeCoins).Returns(2);
            mockTargetUnitResources.Setup(r => r.SilverCoins).Returns(3);
            mockTargetUnitResources.Setup(r => r.GoldCoins).Returns(4);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockTargetUnitResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });
            mockedUnitToTeleport.Setup(u => u.PreviousLocation);

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object);

            // Assert
            Assert.AreEqual(2, teleportStation.Resources.BronzeCoins);
            Assert.AreEqual(3, teleportStation.Resources.SilverCoins);
            Assert.AreEqual(4, teleportStation.Resources.GoldCoins);
        }

        [Test]
        public void TeleportUnit_TeleportedUnitPreviousLocationMustBeItsCurrentLocation_ShouldBeCorrect()
        {
            // Arrange
            // Teleport Location
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            // Wanted Location
            var mockedWantedGPS = new Mock<IGPSCoordinates>();
            mockedWantedGPS.SetupGet(g => g.Latitude).Returns(15.15);
            mockedWantedGPS.SetupGet(g => g.Longtitude).Returns(16.16);

            var mockedWantedGalaxy = new Mock<IGalaxy>();
            mockedWantedGalaxy.SetupGet(g => g.Name).Returns("Some Galaxy");

            var mockedWantedPlanet = new Mock<IPlanet>();
            mockedWantedPlanet.SetupGet(p => p.Galaxy).Returns(mockedWantedGalaxy.Object);
            mockedWantedPlanet.SetupGet(p => p.Name).Returns("Some Planet");
            mockedWantedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var mockedWantedLocation = new Mock<ILocation>();
            mockedWantedLocation.SetupGet(loc => loc.Planet).Returns(mockedWantedPlanet.Object);
            mockedWantedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedWantedGPS.Object);

            var mockedWantedPath = new Mock<IPath>();
            mockedWantedPath.SetupGet(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.Cost).Returns(mockedCostResources.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object, mockedWantedPath.Object }, mockedLocation.Object);

            // Current Location of Unit
            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockTargetUnitResources = new Mock<IResources>();
            mockTargetUnitResources.Setup(r => r.BronzeCoins).Returns(2);
            mockTargetUnitResources.Setup(r => r.SilverCoins).Returns(3);
            mockTargetUnitResources.Setup(r => r.GoldCoins).Returns(4);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockTargetUnitResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedWantedLocation.Object);

            // Assert
            mockedUnitToTeleport.VerifySet(x => x.PreviousLocation = mockedTargetLocation.Object, Times.Once());
        }

        [Test]
        public void TeleportUnit_TeleportedUnitCurrentLocationMustBeItsNewLocation_ShouldBeCorrect()
        {
            // Arrange
            // Teleport Location
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            // Wanted Location
            var mockedWantedGPS = new Mock<IGPSCoordinates>();
            mockedWantedGPS.SetupGet(g => g.Latitude).Returns(15.15);
            mockedWantedGPS.SetupGet(g => g.Longtitude).Returns(16.16);

            var mockedWantedGalaxy = new Mock<IGalaxy>();
            mockedWantedGalaxy.SetupGet(g => g.Name).Returns("Some Galaxy");

            var mockedWantedPlanet = new Mock<IPlanet>();
            mockedWantedPlanet.SetupGet(p => p.Galaxy).Returns(mockedWantedGalaxy.Object);
            mockedWantedPlanet.SetupGet(p => p.Name).Returns("Some Planet");
            mockedWantedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var mockedWantedLocation = new Mock<ILocation>();
            mockedWantedLocation.SetupGet(loc => loc.Planet).Returns(mockedWantedPlanet.Object);
            mockedWantedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedWantedGPS.Object);

            var mockedWantedPath = new Mock<IPath>();
            mockedWantedPath.SetupGet(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.Cost).Returns(mockedCostResources.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object, mockedWantedPath.Object }, mockedLocation.Object);

            // Current Location of Unit
            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockTargetUnitResources = new Mock<IResources>();
            mockTargetUnitResources.Setup(r => r.BronzeCoins).Returns(2);
            mockTargetUnitResources.Setup(r => r.SilverCoins).Returns(3);
            mockTargetUnitResources.Setup(r => r.GoldCoins).Returns(4);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockTargetUnitResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedWantedLocation.Object);

            // Assert
            mockedUnitToTeleport.VerifySet(x => x.CurrentLocation = mockedWantedLocation.Object, Times.Once());
        }

        [Test]
        public void TeleportUnit_TeleportedUnitShouldBeAddedToTheUnitsOfTheTargetPlanetLocation_WhenTeleportationIsASuccess()
        {
            // Arrange
            // Teleport Location
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            // Wanted Location
            var mockedWantedGPS = new Mock<IGPSCoordinates>();
            mockedWantedGPS.SetupGet(g => g.Latitude).Returns(15.15);
            mockedWantedGPS.SetupGet(g => g.Longtitude).Returns(16.16);

            var mockedWantedGalaxy = new Mock<IGalaxy>();
            mockedWantedGalaxy.SetupGet(g => g.Name).Returns("Some Galaxy");

            var mockedWantedPlanet = new Mock<IPlanet>();
            mockedWantedPlanet.SetupGet(p => p.Galaxy).Returns(mockedWantedGalaxy.Object);
            mockedWantedPlanet.SetupGet(p => p.Name).Returns("Some Planet");
            mockedWantedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { });

            var mockedWantedLocation = new Mock<ILocation>();
            mockedWantedLocation.SetupGet(loc => loc.Planet).Returns(mockedWantedPlanet.Object);
            mockedWantedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedWantedGPS.Object);

            var mockedWantedPath = new Mock<IPath>();
            mockedWantedPath.SetupGet(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.Cost).Returns(mockedCostResources.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object, mockedWantedPath.Object }, mockedLocation.Object);

            // Current Location of Unit
            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockTargetUnitResources = new Mock<IResources>();
            mockTargetUnitResources.Setup(r => r.BronzeCoins).Returns(2);
            mockTargetUnitResources.Setup(r => r.SilverCoins).Returns(3);
            mockTargetUnitResources.Setup(r => r.GoldCoins).Returns(4);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockTargetUnitResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedWantedLocation.Object);

            // Assert
            Assert.AreEqual(1, mockedWantedPlanet.Object.Units.Count);
        }

        [Test]
        public void TeleportUnit_TeleportedUnitShouldBeRemovedFromTheUnitsOfTheCurrentPlanetLocation_WhenTeleportationIsASuccess()
        {
            // Arrange
            // Teleport Location
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            // Wanted Location
            var mockedWantedGPS = new Mock<IGPSCoordinates>();
            mockedWantedGPS.SetupGet(g => g.Latitude).Returns(15.15);
            mockedWantedGPS.SetupGet(g => g.Longtitude).Returns(16.16);

            var mockedWantedGalaxy = new Mock<IGalaxy>();
            mockedWantedGalaxy.SetupGet(g => g.Name).Returns("Some Galaxy");

            var mockedWantedPlanet = new Mock<IPlanet>();
            mockedWantedPlanet.SetupGet(p => p.Galaxy).Returns(mockedWantedGalaxy.Object);
            mockedWantedPlanet.SetupGet(p => p.Name).Returns("Some Planet");
            mockedWantedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { });

            var mockedWantedLocation = new Mock<ILocation>();
            mockedWantedLocation.SetupGet(loc => loc.Planet).Returns(mockedWantedPlanet.Object);
            mockedWantedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedWantedGPS.Object);

            var mockedWantedPath = new Mock<IPath>();
            mockedWantedPath.SetupGet(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.TargetLocation).Returns(mockedWantedLocation.Object);
            mockedWantedPath.Setup(p => p.Cost).Returns(mockedCostResources.Object);

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object, mockedWantedPath.Object }, mockedLocation.Object);

            // Current Location of Unit
            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockTargetUnitResources = new Mock<IResources>();
            mockTargetUnitResources.Setup(r => r.BronzeCoins).Returns(2);
            mockTargetUnitResources.Setup(r => r.SilverCoins).Returns(3);
            mockTargetUnitResources.Setup(r => r.GoldCoins).Returns(4);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockTargetUnitResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedWantedLocation.Object);

            // Assert
            Assert.AreEqual(0, mockedTargetPlanet.Object.Units.Count);
        }

        [Test]
        public void PayProfits_ReturnTheTotalAmountOfProfitsGeneratedUsingTheTeleportUnitService_WhenTheOwnerIsValid()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            mockedOwner.SetupGet(o => o.IdentificationNumber).Returns(1);

            var mockedGPS = new Mock<IGPSCoordinates>();
            mockedGPS.SetupGet(g => g.Latitude).Returns(11.11);
            mockedGPS.SetupGet(g => g.Longtitude).Returns(12.12);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(p => p.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");

            var mockedLocation = new Mock<ILocation>();
            mockedLocation.SetupGet(loc => loc.Planet).Returns(mockedPlanet.Object);
            mockedLocation.SetupGet(loc => loc.Coordinates).Returns(mockedGPS.Object);

            var mockedCostResources = new Mock<IResources>();
            mockedCostResources.SetupGet(r => r.BronzeCoins).Returns(1);
            mockedCostResources.SetupGet(r => r.SilverCoins).Returns(2);
            mockedCostResources.SetupGet(r => r.GoldCoins).Returns(3);

            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(p => p.TargetLocation).Returns(mockedLocation.Object);
            mockedPath.SetupGet(p => p.Cost).Returns(mockedCostResources.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(u => u.CurrentLocation).Returns(mockedLocation.Object);
            mockedPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>() { mockedUnit.Object });

            var teleportStation = new TeleportStationMock(mockedOwner.Object, new[] { mockedPath.Object }, mockedLocation.Object);

            var mockedTargetGPS = new Mock<IGPSCoordinates>();
            mockedTargetGPS.SetupGet(g => g.Latitude).Returns(13.13);
            mockedTargetGPS.SetupGet(g => g.Longtitude).Returns(14.14);

            var mockedTargetGalaxy = new Mock<IGalaxy>();
            mockedTargetGalaxy.SetupGet(g => g.Name).Returns("Andromeda");

            var mockedTargetPlanet = new Mock<IPlanet>();
            mockedTargetPlanet.SetupGet(p => p.Name).Returns("KELT-2Ab");
            mockedTargetPlanet.SetupGet(p => p.Galaxy).Returns(mockedTargetGalaxy.Object);

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.SetupGet(loc => loc.Planet).Returns(mockedTargetPlanet.Object);
            mockedTargetLocation.SetupGet(loc => loc.Coordinates).Returns(mockedTargetGPS.Object);

            var mockedUnitToTeleport = new Mock<IUnit>();
            mockedUnitToTeleport.SetupGet(u => u.CurrentLocation).Returns(mockedTargetLocation.Object);
            mockedUnitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnitToTeleport.Setup(u => u.Pay(mockedCostResources.Object)).Returns(mockedCostResources.Object);
            mockedTargetPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { mockedUnitToTeleport.Object });
            mockedUnitToTeleport.Setup(u => u.PreviousLocation);

            // Act 
            teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object);
            var result = teleportStation.PayProfits(mockedOwner.Object);

            // Assert
            Assert.AreEqual(1, result.BronzeCoins);
            Assert.AreEqual(2, result.SilverCoins);
            Assert.AreEqual(3, result.GoldCoins);
        }
    }
}
