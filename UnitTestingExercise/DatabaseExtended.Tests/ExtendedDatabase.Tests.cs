using NUnit.Framework;

namespace Tests
{
  //using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ByAnEmptyCollectionConstructorCountSholudReturnZero()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            var expectedOutput = 0;
            var actualOutput = database.Count;

            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionByMoreThan16Persons()
        {
            Person[] persons = new Person[17];


            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));

        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionOperationByAddingRangeWithmorePersonsThan16()
        {
            Person[] persons = new Person[17];
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));

        }

        [Test]
        public void AddPersonAndIncreaseTheCount()
        {
            Person personOne = new Person(12317, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person personTwo = new Person(123, "Ivan");
            database.Add(personTwo);

            var expectedResult = 2;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenPersonsAreAlready16()
        {
            Person[] persons = new Person[16];
            
            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i + 1, $"Ivan{i + 1 }");
            }

            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person person = new Person(122, "Maria");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void ThrowExceptionByAddingPersonWhithIdWhichExists()
        {
            Person personOne = new Person(12, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person personTwo = new Person(12, "Petar");

            Assert.Throws<InvalidOperationException>(() => database.Add(personTwo));


        }

        [Test]
        public void ThrowExceptionByAddingPersonWhithUsernameWhichExists()
        {
            Person personOne = new Person(12, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person personTwo = new Person(5487, "Maria");

            Assert.Throws<InvalidOperationException>(() => database.Add(personTwo));


        }


        [Test]
        public void ThrowExceptionByRemovePersonWhichDontExists()
        {

            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void ShouldRemoveCorrectly()
        {
            Person personOne = new Person(12317, "Maria");
            Person personTwo = new Person(568, "Petar");
            Person[] persons = { personOne, personTwo };
            ExtendedDatabase database = new ExtendedDatabase(persons);
            database.Remove();

            string expectedName = "Maria";
            string actualName = database.FindById(12317).UserName;


            Assert.AreEqual(expectedName, actualName);

        }

        [Test]
        public void ShouldRemoveReduceTheCount()
        {
            Person personOne = new Person(12317, "Maria");
            Person personTwo = new Person(568, "Petar");
            Person[] persons = { personOne, personTwo };
            ExtendedDatabase database = new ExtendedDatabase(persons);
            database.Remove();

            int expectedCount = 1;
            int actualCount = database.Count;


            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionBySearchingForNotExistingUser()
        {

            Person personOne = new Person(12317, "Maria");
            Person[] persons = { personOne};
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivan"));

        }

        [Test]
        [TestCase (null)]
        public void FindByUsernameShouldThrowArgumentNullExceptionByEmptyName(string username)
        {

            
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));

        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionBySearchingForWrrongWrittenName()
        {

            Person personOne = new Person(12317, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("maria"));

        }

        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {

            Person personOne = new Person(12317, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.AreEqual(personOne, database.FindByUsername("Maria"));

        }



        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionBySearchingForNotExistingId()
        {

            Person personOne = new Person(12317, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => database.FindById(1999));

        }

        [Test]
        public void FindByIdShouldThrowArgumentExceptionByFindingNegativeIds()
        {

            Person personOne = new Person(-144, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-144));

        }

        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {

            Person personOne = new Person(12, "Maria");
            Person[] persons = { personOne };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.AreEqual(personOne, database.FindById(12));

        }

    }
}