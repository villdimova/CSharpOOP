using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(10,10,10,10,9)]
    public void AxeLosesDurabilyAfterAttack(int health,int exp,int attack,int durability,int expectedResult)
    {
        //Arrange

       
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);

        //Act

        axe.Attack(dummy);
        //Assert

       
        var actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AttackShouldThrowInvalidOperationExceptionWhenAxeDurabilityIsNegative()
    {
        //Arrange

        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);

        //Act--Assert

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}