//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase ("Subaru","Legacy", 10, 100)]
        [TestCase("Nissan","Micra", 5, 60 )]
        public void ConstructorShouldSetAllInfoCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make:make, model:model, fuelConsumption:fuelConsumption, fuelCapacity:fuelCapacity);

            Assert.AreEqual(make,car.Make);
            Assert.AreEqual(model,car.Model);
            Assert.AreEqual(fuelConsumption,car.FuelConsumption);
            Assert.AreEqual(fuelCapacity,car.FuelCapacity);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void ConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make , "Legacy", 10, 100));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Subaru", model, 10, 100));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ConstructorShouldThrowExceptionIfFuelConsumptionIsNegativeOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Subaru", "Legacy", fuelConsumption, 100));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ConstructorShouldThrowExceptionIfFuelConsumptionIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Subaru", "Legacy", 10, fuelCapacity));
        }

        [Test]
        [TestCase(100,15,15)]
        [TestCase(100,200,100)]
        public void MethodRefuelShouldIncreaseTheFuelAmountAndCheckFuelCapacity(double fuelCapacity,double fuelToRefuel,double expectedResult)
        {
            Car car = new Car("Subaru", "Legacy", 10, fuelCapacity);
            car.Refuel(fuelToRefuel);

            var expectedValue = expectedResult;
            var actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        [TestCase(-15)]
        [TestCase(0)]
        public void MethodRefuelShouldThrowExceptionByNegativeOrZeroFuelToRefuel(double fuelToRefuel)
        {
            Car car = new Car("Subaru", "Legacy", 10, 100);
           
            Assert.Throws<ArgumentException>(()=>car.Refuel(fuelToRefuel));

        }

        [Test]
        [TestCase(-200)]
        public void MethodRefuelShouldThrowExceptionByNegativeFuelAmount(double fuelToRefuel)
        {
            Car car = new Car("Subaru", "Legacy", 10, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));

        }

        [Test]
        [TestCase(100)]
        
        public void MethodDrivelShouldDecreaseTheFuelAmount(double distance)
        {
            Car car = new Car("Subaru", "Legacy", 10, 100);
            car.Refuel(100);
            car.Drive(distance);

            var expectedResult = 90;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(actualResult, expectedResult);


        }

        [Test]
        [TestCase(200)]
        

        public void MethodDrivelShouldThrowExceptionIfFuelamountBecomesNegative(double distance)
        {
            Car car = new Car("Subaru", "Legacy", 10, 100);
            car.Refuel(10);
            
            Assert.Throws<InvalidOperationException>(()=> car.Drive(distance));


        }

       


    }
}