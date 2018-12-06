namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        // Arrage.
        private Axe weapon;
        private Dummy dummy;
        private const int weaponAttack = 100;
        private const int weaponDurability = 10;
        private const int dummyHealth = 100;
        private const int dummyExperience = 20;

        [SetUp]
        public void CreateWeaponBeforeEachTest()
        {
            this.weapon = new Axe(weaponAttack, weaponDurability);
            this.dummy = new Dummy(dummyHealth, dummyExperience);
        }

        // Act.
        [Test]
        public void TestIsWeaponLosesDurabilityAfterEachAttack()
        {
            this.weapon.Attack(this.dummy);
            const int exepectedResult = 9;

            // Assert.
            Assert.AreEqual(exepectedResult, this.weapon.DurabilityPoints, "Weapon does not loses durability after each attack");
        }

        // Act.
        [Test]
        public void TestForAttackingWithBrokenWeapon()
        {
            this.weapon = new Axe(100, 0);

            // Assert.
            Assert.That(() => this.weapon.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }

        // Clean up after each test.
        [TearDown]
        public void Clean() { }
    }
}

