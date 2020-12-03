using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        Computer computerAsus;
        Computer computerHpEnvy;  
        Computer computerHpSpectre;  

       [SetUp]
        public void Setup()
        {
            computerAsus = new Computer("Asus", "Huracan", 800);
            computerHpEnvy = new Computer("Hp", "Envy", 1800);
            computerHpSpectre = new Computer("Hp", "Spectre", 2000);
        }

        [Test]
        public void ComputerConstructorShouldSetCorrectInfo()
        {
            Computer computer = new Computer("Dell", "Latitude", 1500);

            Assert.AreEqual("Dell",computer.Manufacturer);
            Assert.AreEqual("Latitude", computer.Model);
            Assert.AreEqual(1500, computer.Price);
        }

        [Test]
        public void ComputerManagerConstructorShouldSetCorrectInfo()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void CountMethodShouldReturnCountOfComputers()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.AreEqual(1, computerManager.Count);
            Assert.AreEqual(1, computerManager.Computers.Count);
        }

        [Test]
        public void ByAddingComputerThrowArgumentNullExceptionIfComputerIsNull()
        {
            ComputerManager computerManager = new ComputerManager();
            

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void ByAddingComputerThrowArgumentExceptionIfComputerIsAlreadyAdded()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computerHpEnvy));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);
            bool addedComputer=computerManager.Computers.Any(c => c.Manufacturer == "Hp" && c.Model == "Envy");

            Assert.IsTrue(addedComputer);
        }

        [Test]
        public void GetComputerMethodShouldThrowArgumentNullExceptionByNullManufacturerOrNullModel()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "Envy"));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("HP", null));

        }

        [Test]
        public void GetComputerMethodShouldThrowArgumentExceptionIfNotMatchingComputerIsFound()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Asus", "Huracan"));


        }

        [Test]
        public void GetComputerMethodShouldReturnMatchingComputer()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);


            Assert.AreEqual(computerHpEnvy, computerManager.GetComputer("Hp","Envy"));


        }
        [Test]
        public void RemoveComputerMethodShouldThrowArgumentExceptionIfNotMatchingComputerIsFound()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Asus", "Huracan"));


        }


        [Test]
        public void RemoveMethodShouldThrowArgumentNullExceptionByNullManufacturerOrNullModel()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "Envy"));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("HP", null));

        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);
            var removed = computerManager.RemoveComputer("Hp", "Envy");
            Assert.AreEqual(computerHpEnvy, removed);
            Assert.AreEqual(0, computerManager.Count);


        }

      
       
        [Test]
        public void GetComputersByManufacturerMethodShouldThrowNewargumentExceptionByNullManufacturer()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));


        }

        [Test]
        public void GetComputersByManufacturerMethodShouldReturnCorrectCollection()
        {

            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerHpEnvy);
            computerManager.AddComputer(computerHpSpectre);
            var returnedComputers = computerManager.GetComputersByManufacturer("Hp"); 

            CollectionAssert.Contains(returnedComputers,computerHpEnvy);
            CollectionAssert.Contains(returnedComputers, computerHpSpectre);


        }

        [Test]
        public void GetComputersByManufacturerShouldReturnCorrectCount()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computerAsus);
            computerManager.AddComputer(computerHpEnvy);
            computerManager.AddComputer(computerHpSpectre);
           

            var collection = computerManager.GetComputersByManufacturer("Hp").ToList();
            int expectedCount = 2;

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }
    }
}