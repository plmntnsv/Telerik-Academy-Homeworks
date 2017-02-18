using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Contracts;
using Cosmetics.Tests.Engine.Fakes;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_ShouldReadParseExecuteCreateCategoryCommandAndThenAddItToTheListOfCategories_WhenProvidedValidInput()
        {
            // Arrange
            var command = "CreateCategory";
            var name = "NameOfCategory";
            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(c => c.Name).Returns(command);
            commandMock.Setup(c => c.Parameters).Returns(new List<string>() { name });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            //Assert.AreEqual(1, cosmeticsEngine.CategoriesExposer.Count);
            Assert.IsTrue(cosmeticsEngine.CategoriesExposer.ContainsKey(name));
        }

        [Test]
        public void Start_ShouldReadParseExecuteAddToCategoryCommandAndThenAddProductToTheCategory_WhenProvidedValidInput()
        {
            // Arrange
            var command = "AddToCategory";
            var categoryName = "CategoryOne";
            var productName = "AddProductName";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandAddMock = new Mock<ICommand>();
            commandAddMock.Setup(c => c.Name).Returns(command);
            commandAddMock.Setup(c => c.Parameters).Returns(new List<string>() { categoryName, productName });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandAddMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            cosmeticsEngine.CategoriesExposer.Add(categoryName, categoryMock.Object);
            cosmeticsEngine.ProductsExposer.Add(productName, productMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            categoryMock.Verify(x => x.AddProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void Start_ShouldReadParseExecuteRemoveToCategoryCommandAndThenRemoveProductFromTheCategory_WhenProvidedValidInput()
        {
            // Arrange
            var command = "RemoveFromCategory";
            var categoryName = "CategoryOne";
            var productName = "AddProductName";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandAddMock = new Mock<ICommand>();
            commandAddMock.Setup(c => c.Name).Returns(command);
            commandAddMock.Setup(c => c.Parameters).Returns(new List<string>() { categoryName, productName });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandAddMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            cosmeticsEngine.CategoriesExposer.Add(categoryName, categoryMock.Object);
            cosmeticsEngine.ProductsExposer.Add(productName, productMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            categoryMock.Verify(x => x.RemoveProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void Start_ShouldReadParseExecuteShowCategoryCommandAndCallThePrintMethod_WhenProvidedValidInput()
        {
            // Arrange
            var command = "ShowCategory";
            var categoryName = "CategoryOne";
            var productName = "AddProductName";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandAddMock = new Mock<ICommand>();
            commandAddMock.Setup(c => c.Name).Returns(command);
            commandAddMock.Setup(c => c.Parameters).Returns(new List<string>() { categoryName, productName });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandAddMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            cosmeticsEngine.CategoriesExposer.Add(categoryName, categoryMock.Object);
            cosmeticsEngine.ProductsExposer.Add(productName, productMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            categoryMock.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_ShouldReadParseExecuteCreateShampooCommandAndAddTheShampooToTheProducts_WhenProvidedValidInput()
        {
            // Arrange
            var command = "CreateShampoo";
            var ShampooName = "ShampooName";
            var shampooBrand = "ShampooBrand";
            var shampooPrice = "12.34";
            var shampooGender = "men";
            var shampooMilliliters = "20";
            var shampooUsage = "everyday";
            
            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var commandCreateShampooMock = new Mock<ICommand>();
            commandCreateShampooMock.Setup(c => c.Name).Returns(command);
            commandCreateShampooMock.Setup(c => c.Parameters).Returns(new List<string>() { ShampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandCreateShampooMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            Assert.True(cosmeticsEngine.ProductsExposer.ContainsKey(ShampooName));
        }

        [Test]
        public void Start_ShouldReadParseExecuteCreateToothpasteCommandAndAddTheToothpasteToTheProducts_WhenProvidedValidInput()
        {
            // Arrange
            var command = "CreateToothpaste";
            var toothpasteName = "Tooth";
            var toothpasteBrand = "ToothBrand";
            var toothpastePrice = "12.34";
            var toothpasteGender = "men";
            var toothpasteIngrediends = "IngrediendOne, IngrediendTwo, IngrediendThree";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var commandCreateToothpasteMock = new Mock<ICommand>();
            commandCreateToothpasteMock.Setup(c => c.Name).Returns(command);
            commandCreateToothpasteMock.Setup(c => c.Parameters).Returns(new List<string>() { toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngrediends });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandCreateToothpasteMock.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            Assert.True(cosmeticsEngine.ProductsExposer.ContainsKey(toothpasteName));
        }

        [Test]
        public void Start_ShouldReadParseExecuteAddToShoppingCartCommandAndAddTheProductToTheShoppingCart_WhenProvidedValidInput()
        {
            // Arrange
            var command = "AddToShoppingCart";
            var productName = "Product";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var productMock = new Mock<IProduct>();

            var commandAddToShoppingCart = new Mock<ICommand>();
            commandAddToShoppingCart.Setup(c => c.Name).Returns(command);
            commandAddToShoppingCart.Setup(c => c.Parameters).Returns(new List<string>() { productName });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandAddToShoppingCart.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            cosmeticsEngine.ProductsExposer.Add(productName, productMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            shoppingCartMock.Verify(s => s.AddProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void Start_ShouldReadParseExecuteRemoveFromShoppingCartCommandAndRemoveTheProductFromTheShoppingCart_WhenProvidedValidInput()
        {
            // Arrange
            var command = "RemoveFromShoppingCart";
            var productName = "Product";

            var cosmeticsFactoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            shoppingCartMock.Setup(s => s.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            var productMock = new Mock<IProduct>();

            var commandRemoveFromShoppingCart = new Mock<ICommand>();
            commandRemoveFromShoppingCart.Setup(c => c.Name).Returns(command);
            commandRemoveFromShoppingCart.Setup(c => c.Parameters).Returns(new List<string>() { productName });

            var commandParserMock = new Mock<ICommandParser>();
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand>() { commandRemoveFromShoppingCart.Object });

            var cosmeticsEngine = new CosmeticsEngineExtended(cosmeticsFactoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            cosmeticsEngine.ProductsExposer.Add(productName, productMock.Object);

            // Act
            cosmeticsEngine.Start();

            // Assert
            shoppingCartMock.Verify(s => s.RemoveProduct(It.IsAny<IProduct>()), Times.Once);
        }
    }
}
