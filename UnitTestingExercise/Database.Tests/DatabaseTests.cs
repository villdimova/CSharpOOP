using NUnit.Framework;

namespace Tests
{
   // using Database;
    using System;

    public class DatabaseTests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] elements = new int[16];
            Database database = new Database(elements);

            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        
        public void ConstructorShouldThrowInvalidOperationExceptionWhenConstructotIsNotInitializedWith16Elements()
        {
            int[] elements = new int[17];
           
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        public void AddMethodShouldIncreaseTheCount()
        {
            
            Database database = new Database();
            database.Add(1);
            
            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenElementsAreAlready16()
        {
            int[] elements = new int[16];
            Database database = new Database(elements);
            int element = 3;


            Assert.Throws<InvalidOperationException>(() => database.Add(element));
        }

        [Test]
        public void DatabaseShouldAddOnTheNextEmptyIndex()
        {
            int[] elements = { 1, 2, 3, 4, 5 };
            Database database = new Database(elements);
            database.Add(6);
            int expextedResult = 6;
            int actualResult = database.Fetch()[5];
            Assert.AreEqual(expextedResult, actualResult);

        }

        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseTheCount()
        {
            int[] elements = { 1, 2, 3 };
            Database database = new Database(elements);
            database.Remove();

            int expectedValue = 2;
            int actualValue = database.Fetch()[database.Count-1];

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenArrayIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void FetchMethodShouldReturnAllElementsAsArray()
        {
            int[] elements = { 1, 6, 9, 4, 5 };
            Database database = new Database(elements);
            
            int[] expextedValues = { 1, 6, 9, 4, 5 };
            int[] actualValues = database.Fetch();
            Assert.AreEqual(expextedValues, actualValues);
        }
    }
}