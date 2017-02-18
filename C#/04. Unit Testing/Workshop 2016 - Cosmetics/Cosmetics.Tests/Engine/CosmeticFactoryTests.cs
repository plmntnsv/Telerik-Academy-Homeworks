using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Common;
using Cosmetics.Engine;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticFactoryTests
    {
        [Test]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenPassedNullNameParameter()
        {
            // Arrange
            string name = null,
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();
            
            // Act
            var exc = Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product name", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenPassedEmptyNameParameter()
        {
            // Arrange
            string name = string.Empty,
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product name", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongNameParameter()
        {
            // Arrange
            string name = "ANameThatIsOverTheMaxLength",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product name", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortNameParameter()
        {
            // Arrange
            string name = "Hi",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product name", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenPassedNullBrandParameter()
        {
            // Arrange
            string name = "Shampoo",
                   brand = null;
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product brand", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenPassedEmptyBrandParameter()
        {
            // Arrange
            string name = "Shamzoo",
                   brand = string.Empty;
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product brand", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongBrandParameter()
        {
            // Arrange
            string name = "Shamboo",
                   brand = "ANameThatIsOverTheMaxLength";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product brand", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortBrandParameter()
        {
            // Arrange
            string name = "Shamwoo",
                   brand = "A";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act
            var exc = Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));

            // Assert
            StringAssert.Contains("Product brand", exc.Message);
        }

        [Test]
        public void CreateShampoo_ShouldReturnAnInstanceOfAShampoo_WhenPassedValidParameters()
        {
            // Arrange
            string name = "Shamdoo",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            uint milliliters = 200;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // Act 
            var shampooResult = factory.CreateShampoo(name, brand, price, gender, milliliters, usage);

            // Assert
            Assert.IsInstanceOf<IShampoo>(shampooResult);
        }

        [Test]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenPassedNullNameParameter()
        {
            // Arrange
            string name = null;

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenPassedEmptyNameParameter()
        {
            // Arrange
            string name = string.Empty;

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongNameParameter()
        {
            // Arrange
            string name = "ANameThatIsOverFifteenCharachtersLong";

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortNameParameter()
        {
            // Arrange
            string name = "2";

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ShouldReturnAnInstanceOfACategory_WhenPassedValidParameters()
        {
            // Arrange
            string name = "Valid";

            var factory = new CosmeticsFactory();

            // Act 
            var shampooResult = factory.CreateCategory(name);

            // Assert
            Assert.IsInstanceOf<ICategory>(shampooResult);
        }

        [Test]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenPassedNullNameParameter()
        {
            // Arrange
            string name = null,
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<NullReferenceException>().With.Message.Contains("Product name"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenPassedEmptyNameParameter()
        {
            // Arrange
            string name = string.Empty,
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<NullReferenceException>().With.Message.Contains("Product name"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongNameParameter()
        {
            // Arrange
            string name = "ANameThatIsOverTenCharachtersLong",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Name, Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Product name"));                 
        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortNameParameter()
        {
            // Arrange
            string name = "N",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Name, Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Product name"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenPassedNullBrandParameter()
        {
            // Arrange
            string name = "Valid",
                   brand = null;
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<NullReferenceException>().With.Message.Contains("Product brand"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenPassedEmptyBrandParameter()
        {
            // Arrange
            string name = "Valid",
                   brand = string.Empty;
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<NullReferenceException>().With.Message.Contains("Product brand"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongBrandParameter()
        {
            // Arrange
            string name = "Valid",
                   brand = "ANameThatIsOverTenCharachtersLong";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Product brand"));

        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortBrandParameter()
        {
            // Arrange
            string name = "Valid",
                   brand = "B";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients).Brand, Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Product brand"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooLongIngredientName()
        {
            // Arrange
            string name = "Name",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "HerbWhichNameIsOverTwelveCharachtersLong", "AnotherHerb" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients), Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Each ingredient"));
        }

        [Test]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedTooShortIngredientName()
        {
            // Arrange
            string name = "Name",
                   brand = "Brand";
            decimal price = 123.45m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>() { "Herb", "H" };

            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.That(() => factory.CreateToothpaste(name, brand, price, gender, ingredients), Throws.InstanceOf<IndexOutOfRangeException>().With.Message.Contains("Each ingredient"));
        }

        [Test]
        public void CreateShoppingCart_ShouldCreateAnInstanceOfShoppingCart_WhenPassedValidInput()
        {
            // Arrange
            var factory = new CosmeticsFactory();

            // Act 
            var shoppingCart = factory.CreateShoppingCart();

            // Assert
            Assert.IsInstanceOf<IShoppingCart>(shoppingCart);
        }
    }
}
