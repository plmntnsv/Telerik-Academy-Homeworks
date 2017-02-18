using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Products;
using Cosmetics.Common;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ToothpastePrintTests
    {
        [Test]
        public void ToothpastePrint_ShouldReturnStringInExpectedFormat_WhenProvidedValidInput()
        {
            // Arrange
            string name = "AquaSvej",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var toothpaste = new Toothpaste(name, brand, price, gender, ingredients);

            // Act 
            string result = toothpaste.Print();

            // Assert
            StringAssert.Contains($"- {brand} - {name}:", result);
            StringAssert.Contains($"  * Price: ${price}", result);
            StringAssert.Contains($"  * For gender: {gender}", result);
            StringAssert.Contains($"  * Ingredients: {string.Join(", ", ingredients)}", result);
        }
    }
}