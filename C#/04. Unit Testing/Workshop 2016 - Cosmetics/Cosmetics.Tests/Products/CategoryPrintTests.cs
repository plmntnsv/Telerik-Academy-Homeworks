using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Contracts;
using Cosmetics.Products;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class CategoryPrintTests
    {
        [Test]
        public void CategoryPrint_ShouldReturnStringInExpectedFormat_WhenProvidedValidInput()
        {
            // Arrange
            string name = "Toilet paper";
            var category = new Category(name);

            var productOneMock = new Mock<IProduct>();
            productOneMock.SetupGet(p => p.Brand).Returns("ABrand");
            productOneMock.SetupGet(p => p.Price).Returns(10m);
            productOneMock.Setup(p => p.Print()).Returns("First");
            category.AddProduct(productOneMock.Object);

            var productTwoMock = new Mock<IProduct>();
            productTwoMock.SetupGet(p => p.Brand).Returns("BBrand");
            productTwoMock.SetupGet(p => p.Price).Returns(50m);
            productTwoMock.Setup(p => p.Print()).Returns("Second");
            category.AddProduct(productTwoMock.Object);

            var productThreeMock = new Mock<IProduct>();
            productThreeMock.SetupGet(p => p.Brand).Returns("CBrand");
            productThreeMock.SetupGet(p => p.Price).Returns(20m);
            productThreeMock.Setup(p => p.Print()).Returns("Fourth");
            category.AddProduct(productThreeMock.Object);

            var productFourMock = new Mock<IProduct>();
            productFourMock.SetupGet(p => p.Brand).Returns("CBrand");
            productFourMock.SetupGet(p => p.Price).Returns(40m);
            productFourMock.Setup(p => p.Print()).Returns("Third");
            category.AddProduct(productFourMock.Object);

            string expectedMessage = name + " category - 4 products in total\r\nFirst\r\nSecond\r\nThird\r\nFourth";

            // Act 
            string resultMessage = category.Print();

            // Assert
            Assert.AreEqual(expectedMessage, resultMessage);
        }
    }
}