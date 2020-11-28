namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robotWalle;
        private Robot robotIva;
        private Robot robotBumblebee;

        [SetUp]
        public void Setup()
        {
            robotWalle= new Robot("Walle", 50);
            robotIva = new Robot("Iva", 200);
            robotBumblebee = new Robot("Bumblebee", 300);
        }

        [Test]
        public void RobotCosntructorShouldSetCorrectInfo()
        {
            Robot robot = new Robot("Optimus", 1000);

            Assert.AreEqual("Optimus", robot.Name);
            Assert.AreEqual(1000, robot.Battery);
            Assert.AreEqual(1000, robot.MaximumBattery);

        }

        [Test]
        public void RobotManagerCosntructorShouldSetCorrectInfo()
        {
            RobotManager robotManager = new RobotManager(10);
           
            Assert.AreEqual(10, robotManager.Capacity);


        }

        [Test]
        public void RobotManagerCosntructorShouldThrowArgumentExceptionWhenTheCapacityIsNegative()
        {


            Assert.Throws<ArgumentException>(() => new RobotManager(-4));


        }

        [Test]
        public void RobotManagerCountShouldReturnCountOfRobostsAndAddMethodIncreaseTheCount()
        {

            RobotManager robotManager = new RobotManager(10);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);

            Assert.AreEqual(2, robotManager.Count);

        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAlreadyIsAddedTheRobot()
        {

            RobotManager robotManager = new RobotManager(10);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotWalle));

        }


        [Test]
        public void AddMethodShouldThrowExceptionIfTheCapacityLimitIsReached()
        {

            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotBumblebee));

        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfTheToBeRemovedRobotIsNotExistingInTheCollection()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(robotBumblebee.Name));

        }

        [Test]
        public void RemoveMethodShouldRemoveTheRobotFromTheCollection()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);
            robotManager.Remove(robotWalle.Name);

            Assert.AreEqual(1, robotManager.Count);
            
        }

        [Test]
        public void WorkMethodShouldThrowInvalidOperationExceptionIfDontExistsIntTheCollectionWantedRobot()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
            robotManager.Add(robotIva);
          

            Assert.Throws<InvalidOperationException>(()=>robotManager.Work(robotBumblebee.Name,"Cleaning",10));

        }

        [Test]
        public void WorkMethodShouldThrowInvalidOperationExceptionIfTheBatteryIsLowerThanNeededBatteryUsage()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
           

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotWalle.Name, "Cleaning", 100));

        }

        [Test]
        public void WorkMethodShouldDecreaseTheBattery()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
            robotManager.Work(robotWalle.Name, "cleaning", 10);

            Assert.AreEqual(40, robotWalle.Battery);
           
        }

        [Test]
        public void ChargeMethodShouldThrowInvalidOperationExceptionIfDontExistsInTheCollectionWantedRobot()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
           


            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robotIva.Name));

        }

        [Test]
        public void ChargeMethodShouldChargeToTheMaximumBattery()
        {

            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robotWalle);
            robotManager.Work(robotWalle.Name, "cook", 30);
            robotManager.Charge(robotWalle.Name);


            Assert.AreEqual(50,robotWalle.Battery);

        }

    }
}
