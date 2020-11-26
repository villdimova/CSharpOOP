using NUnit.Framework;
using FightingArena;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CosntructorShouldSetCorrectInfo()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);

        }

        [Test]
        [TestCase("Dark", 100, 50)]
        [TestCase("Dark", 40, 50)]

        public void EnrollMethodShouldThrowExceptionIfWarriorIsAlreadyEnrolled(string name, int damage, int Hp)
        {
            Warrior warriorOne = new Warrior("Dark", 100, 50);
            Warrior warriorTwo = new Warrior(name, damage, Hp);

            Arena arena = new Arena();
            arena.Enroll(warriorOne);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warriorTwo));

        }


        [Test]
        public void CountShouldReturnProperInfo()
        {
            Warrior defender = new Warrior("Dark", 100, 50);
            Warrior attacker = new Warrior("Second", 80, 30);

            Arena arena = new Arena();
            arena.Enroll(defender);
            arena.Enroll(attacker);

            var expectedResult = 2;
            var actualResult = arena.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfAtackerIsNotEnrolledForTheFight()
        {
            Warrior defender = new Warrior("Dark", 100, 50);
            Warrior atacker = new Warrior("Second", 80, 30);

            Arena arena = new Arena();
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(defender.Name, atacker.Name));

        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfDefenderIsNotEnrolledForTheFight()
        {
            Warrior defender = new Warrior("Dark", 100, 50);
            Warrior atacker = new Warrior("Second", 80, 30);

            Arena arena = new Arena();
            arena.Enroll(atacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(defender.Name, atacker.Name));

        }

        [Test]
        public void FightMethodShouldThrowExceptionWhenThereIsNoAttacker()
        {
            Arena arena = new Arena();
            Warrior deffender = new Warrior("Good", 50, 100);
            arena.Enroll(deffender);

            Assert.Throws<InvalidOperationException>(() =>
            
                arena.Fight("Black", deffender.Name));
        }

        [Test]
        public void FightMethodShouldThrowExceptionWhenThereIsNoDeffender()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Black", 50, 100);
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            
                arena.Fight(attacker.Name, "Good"));
        }

        [Test]
        public void MethodEnrollShouldAddWarrior()
        {
            Warrior warrior = new Warrior("Good", 50, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            int expectedResult = 1;
            var addeWarrior = arena.Warriors.Any(w => w.Name == "Good");

            Assert.AreEqual(expectedResult, arena.Count);
            Assert.IsTrue(addeWarrior);
        }


        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(0)]

        public void MethodFightShouldThrowInvalidOperationExceptionIfHpOfAttackerIsBelow30(int Hp)
        {
            Warrior attacker = new Warrior("Good", 10, Hp);
            Warrior defender = new Warrior("Black", 10, 50);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(0)]

        public void MethodFightShouldThrowInvalidOperationExceptionIfDefenderHpIsBelow30(int Hp)
        {
            Warrior attacker = new Warrior("Good", 10, 50);
            Warrior defender = new Warrior("Black", 10, Hp);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));

        }

        [Test]
        [TestCase(80, 50, 30)]
        [TestCase(80, 80, 0)]

        public void MethodFightShouldDecreaseAttackerHp(int hp, int warriorDamage, int resultHp)
        {
            Warrior attacker = new Warrior("Good", 50, hp);
            Warrior defender = new Warrior("Black", warriorDamage, 50);

            int expectedResult = resultHp;
            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedResult, attacker.HP);
        }

        [Test]
        [TestCase(30, 50, 20)]
        [TestCase(200, 80, 0)]

        public void MethodFightShouldDecreaseDefenderHpOtMakeItZero(int damage, int warriorHp, int resultHp)
        {
            Warrior attacker = new Warrior("Good", damage, 90);
            Warrior defender = new Warrior("Black", 50, warriorHp);

            int expectedResult = resultHp;
            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedResult, defender.HP);
        }


        [Test]
        [TestCase(50, 100)]
        [TestCase(40, 200)]
        public void MethodAttackShouldThrowInvalidOperationExceptionIfEnemyIsTooStrong(int Hp, int enemyDamage)
        {
            Warrior warrior = new Warrior("Good", 10, Hp);
            Warrior enemyWarrior = new Warrior("Black", enemyDamage, 20);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemyWarrior));
        }

    }
}
