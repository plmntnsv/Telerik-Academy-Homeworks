using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Common;
using Cosmetics.Products;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShampooPrintTests
    {
        [Test]
        public void ShampooPrint_ShouldReturnStringInExpectedFormat_WhenProvidedValidInput()
        {
            // Arrange
            string name = "Shamgoo",
                   brand = "Brand";
            decimal price = 2m;
            var gender = GenderType.Unisex;
            uint milliliters = 20;
            var usage = UsageType.EveryDay;

            var shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);

            // Act 
            string result = shampoo.Print();

            // Assert
            StringAssert.Contains($"- {brand} - {name}:", result);
            StringAssert.Contains($"  * Price: ${price*milliliters}", result);
            StringAssert.Contains($"  * For gender: {gender}", result);
            StringAssert.Contains($"  * Quantity: {milliliters} ml", result);
            StringAssert.Contains($"  * Usage: {usage}", result);
        }
    }
}
