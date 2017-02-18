using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Contracts;
using Cosmetics.Tests.Products.Mocks;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_ShouldAddTheProvidedProductToTheProductsList_WhenProvidedValidInput()
        {
            // Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartExtended();

            // Act
            shoppingCart.AddProduct(productMock.Object);

            // Assert
            CollectionAssert.Contains(shoppingCart.ProductsExposer, productMock.Object);
        }

        [Test]
        public void RemoveProduct_ShouldRemoveProductFromTheProductsList_WhenProvidedValidInput()
        {
            // Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartExtended();

            // Act
            shoppingCart.AddProduct(productMock.Object);
            shoppingCart.RemoveProduct(productMock.Object);

            // Assert
            CollectionAssert.DoesNotContain(shoppingCart.ProductsExposer, productMock.Object);
        }

        [Test]
        public void ContainsProduct_ShouldReturnTrueIfThePassedProductIsInTheProductsList_WhenProvidedValidInput()
        {
            // Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartExtended();

            // Act
            shoppingCart.AddProduct(productMock.Object);
            bool result = shoppingCart.ContainsProduct(productMock.Object);

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TotalPrice_ShouldReturnTotalPriceOfAllTheProductsInTheProductsList_WhenProvidedValidInput()
        {
            // Arrange
            var productMock = new Mock<IProduct>();
            productMock.SetupGet(p => p.Price).Returns(20m);
            var productTwoMock = new Mock<IProduct>();
            productTwoMock.SetupGet(p => p.Price).Returns(10m);
            var shoppingCart = new ShoppingCartExtended();

            // Act
            shoppingCart.AddProduct(productMock.Object);
            shoppingCart.AddProduct(productTwoMock.Object);
            var result = shoppingCart.TotalPrice();

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void TotalPrice_ShouldReturnZeroWhenThereAreNoProductsInTheProductsList_WhenProvidedValidInput()
        {
            // Arrange
            var shoppingCart = new ShoppingCartExtended();

            // Act
            var result = shoppingCart.TotalPrice();

            // Assert
            //Assert.AreEqual(0, result);
            Assert.That(result, Is.Zero);
        }
    }
}
