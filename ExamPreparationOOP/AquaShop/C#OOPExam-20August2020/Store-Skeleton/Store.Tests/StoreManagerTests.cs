using NUnit.Framework;
using System;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Product productOne;
        private Product productTwo;
        private Product productThree;
        private Product productInvalidQuantity;
        private Product invalidProduct;

        [SetUp]
        public void Setup()
        {
            this.storeManager = new StoreManager();
            this.productOne = new Product("Milk", 2, 2.5m);
            this.productTwo = new Product("Bread", 1, 1.30m);
            this.productThree = new Product("Wine", 3, 18.5m);
            this.productInvalidQuantity = new Product("Milk", 0, 2.5m);
            this.invalidProduct = null;
        }

        [Test]
        public void ConstructorShouldWorksProperly()
        {
            StoreManager storeManager = new StoreManager();

            Assert.IsNotNull(storeManager.Products);
        }

        [Test]
        public void CountShouldReturnCorrectInfo()
        {
            int expectedResult = 0;
            int actualResult = storeManager.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowArgumentExceptionIfProductToBeAddedIsNull()
        {

            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(invalidProduct));
        }

        [Test]
        public void AddMethodShouldThrowArgumentExceptionIfProductToBeAddedQuantityIsZeroOrNegative()
        {

            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(productInvalidQuantity));
        }

        [Test]
        public void AddMethodShouldIncreaseTheCount()
        {

            storeManager.AddProduct(productOne);
            storeManager.AddProduct(productTwo);

            int expectedResult = 2;
            int actualResult = storeManager.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void AddMethodShouldAddTheProductToProducts()
        {

            storeManager.AddProduct(productOne);
            bool addedProduct = storeManager.Products.Any(p => p.Name == "Milk");
            Assert.IsTrue(addedProduct);

        }

        [Test]
        public void BuyMethodShouldThrowArgumentNullExceptionWhenWantToBuyProductWhichDontExists()
        {

            storeManager.AddProduct(productOne);

            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct(productTwo.Name, 1));

        }

        [Test]
        public void BuyMethodShouldThrowArgumentExceptionWhenThereIsNotEnoughQuantityFromProduct()
        {

            storeManager.AddProduct(productOne);

            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct(productOne.Name, 5));

        }

        [Test]
        public void BuyMethodShouldDecreaseTheCountOfTheBoughtProduct()
        {

            storeManager.AddProduct(productOne);

            storeManager.BuyProduct(productOne.Name, 1);
            int expectedResult = 1;
            int actualResult = storeManager.Products.FirstOrDefault(p => p.Name == "Milk").Quantity;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void BuyMethodShouldReturnFinalPriceOfTheBoughtProduct()
        {

            storeManager.AddProduct(productOne);
           
            decimal expectedResult = 2.5m;
            decimal actualResult = storeManager.BuyProduct(productOne.Name, 1);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void GetTheMostExpensiveProductShouldReturnTheCorrectInformation()
        {

            storeManager.AddProduct(productOne);
            storeManager.AddProduct(productTwo);
            storeManager.AddProduct(productThree);

            Product actualResult = storeManager.GetTheMostExpensiveProduct();

            Assert.AreEqual(productThree, actualResult);

        }
    }
}