namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        Part cpu;
        Part motherboard;
        Part ram;

        [SetUp]
        public void Setup()
        {
            cpu = new Part("CPU", 400);
            motherboard = new Part("Motherboard", 300);
            ram = new Part("RAM", 200);
        }

        [Test]
        public void PartConstructorShouldWorkProperly()
        {
            Part videocard = new Part("Videocard", 200);
            Assert.AreEqual("Videocard", videocard.Name);
            Assert.AreEqual(200, videocard.Price);

        }

        [Test]
        public void ComputerConstructorShouldWorkProperly()
        {
            Computer PC = new Computer("Asus");

            Assert.AreEqual("Asus", PC.Name);
            Assert.IsNotNull(PC.Parts);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionByInvalidName()
        {

            Assert.Throws<ArgumentNullException>(() => new Computer(null));
            Assert.Throws<ArgumentNullException>(() => new Computer(" "));
            Assert.Throws<ArgumentNullException>(() => new Computer(""));

        }

        [Test]
        public void TotalPriceShouldReturnTotalPriceOfPC()
        {

            Computer computer = new Computer("Dell");
            computer.AddPart(cpu);
            computer.AddPart(motherboard);

            decimal expectedPrice = cpu.Price + motherboard.Price;

            Assert.AreEqual(expectedPrice, computer.TotalPrice);
        }

        [Test]
        public void AddPartMethodShouldThrowArgumentNullExceptionByInvalidPart()
        {
            Computer computer = new Computer("Hp");

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void AddPartMethodShouldWorkProperly()
        {
            Computer computer = new Computer("Hp");
            computer.AddPart(motherboard);
            computer.AddPart(ram);

            CollectionAssert.Contains(computer.Parts, motherboard);
            CollectionAssert.Contains(computer.Parts, ram);

            
        }

        [Test]
        public void RemovePartMethodShouldWorkProperly()
        {
            Computer computer = new Computer("Hp");
            computer.AddPart(motherboard);
            CollectionAssert.Contains(computer.Parts, motherboard);
           bool result= computer.RemovePart(motherboard);
            Assert.IsTrue(result);
            CollectionAssert.DoesNotContain(computer.Parts, motherboard);


        }

       [Test]
        public void GetPartMethodShouldWorkProperly()
        {
            Computer computer = new Computer("Hp");
            computer.AddPart(motherboard);

            Part result = computer.GetPart("Motherboard");
            Assert.AreEqual(motherboard, result);
           


        }
    }
}