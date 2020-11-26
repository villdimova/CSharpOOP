using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Spartac",10,100)]
        public void CosntructorShouldSetCorrectInfo(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name: name, damage: damage, hp: hp);

            Assert.AreEqual(name,warrior.Name);
            Assert.AreEqual(damage,warrior.Damage);
            Assert.AreEqual(hp,warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]

        public void ConstructorShouldThrowExceptionIfNameIsNullWhitespaceOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
    

        public void ConstructorShouldThrowExceptionIfDamageIsNullOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Spiderman", damage, 100));
        }

        [Test]
        [TestCase(-10)]


        public void ConstructorShouldThrowExceptionIfHpIsNullOrNegative(int Hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Spiderman", 10, Hp));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(0)]
      
        public void MethodAttackShouldThrowInvalidOperationExceptionIfHpIsBelow30(int Hp)
        {
            Warrior warrior = new Warrior("Good", 10, Hp);
            Warrior enemyWarrior = new Warrior("Black", 10, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(0)]
        
        public void MethodAttackShouldThrowInvalidOperationExceptionIfEnemeyHpIsBelow30(int Hp)
        {
            Warrior warrior = new Warrior("Good", 10, 50);
            Warrior enemyWarrior = new Warrior("Black", 10, Hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase(80,50,30)]
        [TestCase(80,80,0)]
        
        public void MethodAttackShouldDecreaseWarriorHp(int hp,int warriorDamage,int resultHp)
        {
            Warrior warrior = new Warrior("Good", 50, hp);
            Warrior enemyWarrior = new Warrior("Black", warriorDamage, 50);

            int expectedResult = resultHp;
            warrior.Attack(enemyWarrior);
           
            Assert.AreEqual(expectedResult, warrior.HP);
        }

        [Test]
        [TestCase(30, 50, 20)]
        [TestCase(200, 80, 0)]

        public void MethodAttackShouldDecreaseWarriorHpOrMakeItZero(int damage, int warriorHp, int resultHp)
        {
            Warrior warrior = new Warrior("Good", damage, 90);
            Warrior enemyWarrior = new Warrior("Black", 50, warriorHp);

            int expectedResult = resultHp;
            warrior.Attack(enemyWarrior);

            Assert.AreEqual(expectedResult, enemyWarrior.HP);
        }


        [Test]
        [TestCase(50,100)]
        [TestCase(40, 200)]
        public void MethodAttackShouldThrowInvalidOperationExceptionIfEnemyIsTooStrong(int Hp,int enemyDamage)
        {
            Warrior warrior = new Warrior("Good", 10, Hp);
            Warrior enemyWarrior = new Warrior("Black", enemyDamage, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }
    }
}