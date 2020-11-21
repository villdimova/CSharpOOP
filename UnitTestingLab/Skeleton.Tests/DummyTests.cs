using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyMustLoseHealthIfAttacked()
    {


        //Arrange
        Dummy dummy = new Dummy(100, 100);

        //Act
        dummy.TakeAttack(10);

        //Assert

        var expectedResult = 90;
        var actualResult = dummy.Health;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DidDeadDummyThrowsExceptionIfAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 100);
        //Act

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));


    }

    [Test]

    public void DidDeadDummyDeadCanGiveXP()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 10);
        
        //Act
        dummy.GiveExperience();


        //Assert
        var expectedResult = 10;
        var actualResult = dummy.GiveExperience();
        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    public void AliveDummyShouldNotGiveXP()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);
        
        //Act-Assert

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());


    }
}
