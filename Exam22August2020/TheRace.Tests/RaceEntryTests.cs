using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar carPorshe;
        UnitCar carFord;
        UnitCar carMustang;
        UnitDriver driverPesho;
        UnitDriver driverGosho;


        [SetUp]
        public void Setup()
        {
            carPorshe = new UnitCar("Porshe", 300, 5000);
            carFord = new UnitCar("Ford", 200, 3000);
            carMustang = new UnitCar("Mustang", 100, 4000);

            driverPesho = new UnitDriver("Pesho",carPorshe);
            driverGosho = new UnitDriver("Gosho", carFord);

        }

        [Test]
        public void UnitCarConstructorShouldSetTheCorrectInfo()
        {
            UnitCar carSubaru = new UnitCar("Subaru", 100, 4000);
            Assert.AreEqual("Subaru", carSubaru.Model);
            Assert.AreEqual(100, carSubaru.HorsePower);
            Assert.AreEqual(4000, carSubaru.CubicCentimeters);
        }

        [Test]
        public void UnitDriverConstructorShouldSetTheCorrectInfo()
        {
            UnitCar carSubaru = new UnitCar("Subaru", 100, 4000);
            UnitDriver driverDaniel = new UnitDriver("Daniel", carSubaru);

            Assert.AreEqual("Daniel", driverDaniel.Name);
            Assert.AreSame(carSubaru, driverDaniel.Car);
        }

        [Test]
        public void UnitDriverConstructorShouldThrowArgumentNullExceptionByInvalidName()
        {
            UnitCar carSubaru = new UnitCar("Subaru", 100, 4000);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, carSubaru));
 
        }

        [Test]
        public void RaceEntryConstructorShouldWorkProperly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.IsTrue(raceEntry.Counter == 0);

        }

        [Test]
        public void RaceEntryCounterShouldWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driverGosho);

            Assert.AreEqual(1,raceEntry.Counter);

        }

        [Test]
        public void AddMethodshouldThrowExceptionByNullValueName()
        {
            RaceEntry raceEntry = new RaceEntry();


            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

        }

        [Test]
        public void AddMethodshouldThrowExceptionByAlreadyaddedDriver()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driverGosho);


            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driverGosho));

        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            
            string expectedGosho = "Driver Gosho added in race.";
            string expectedPesho = "Driver Pesho added in race.";
            

            Assert.AreEqual(expectedGosho, raceEntry.AddDriver(driverGosho));
            Assert.AreEqual(expectedPesho, raceEntry.AddDriver(driverPesho));

        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionByInvalidCount()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driverGosho);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectValue()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driverGosho);
            raceEntry.AddDriver(driverPesho);

            double expectedValue = (driverPesho.Car.HorsePower + driverGosho.Car.HorsePower)/2;

            Assert.AreEqual(expectedValue, raceEntry.CalculateAverageHorsePower());
            

        }
    }
}