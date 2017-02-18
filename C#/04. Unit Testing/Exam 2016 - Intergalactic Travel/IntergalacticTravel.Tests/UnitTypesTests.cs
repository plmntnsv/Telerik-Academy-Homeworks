using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class UnitTypesTests
    {
        [Test]
        public void GetUnit_ShouldReturnNewProcyonUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act
            var procyon = createUnit.GetUnit("create unit Procyon Gosho 1");

            // Assert
            Assert.AreEqual(procyon.GetType().Name, "Procyon");
            Assert.AreEqual(procyon.NickName, "Gosho");
            Assert.AreEqual(procyon.IdentificationNumber, 1);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLuytenUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act
            var luyten = createUnit.GetUnit("create unit Luyten Pesho 2");

            // Assert
            Assert.AreEqual(luyten.GetType().Name, "Luyten");
            Assert.AreEqual(luyten.NickName, "Pesho");
            Assert.AreEqual(luyten.IdentificationNumber, 2);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLacailleUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act
            var lacaille = createUnit.GetUnit("create unit Lacaille Tosho 3");

            // Assert      
            Assert.AreEqual(lacaille.GetType().Name, "Lacaille");
            Assert.AreEqual(lacaille.NickName, "Tosho");
            Assert.AreEqual(lacaille.IdentificationNumber, 3);
        }

        [Test]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenAnEmptyCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => createUnit.GetUnit(string.Empty));
        }

        [Test]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenNullCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => createUnit.GetUnit(null));
        }

        [Test]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenInvalidFormatCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => createUnit.GetUnit("Procyon Gosho 1 create unit"));
        }

        [Test]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenInvalidUnitTypeCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            Assert.Throws<InvalidUnitCreationCommandException>(() => createUnit.GetUnit("create unit Procyno Gosho 1"));
        }

        [Test]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenInvalidUnitIdCommandIsPassed()
        {
            // Arrange
            var createUnit = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => createUnit.GetUnit("create unit Procyon Gosho 165461854894651654986164894615"));
        }
    }
}
