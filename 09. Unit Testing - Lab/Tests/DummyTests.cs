namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        // Arrage.
        private Dummy dummy;
        private const int dummyHealth = 20;
        private const int dummyExperience = 100;

        [SetUp]
        public void CreateDummyBeforeEachTest()
        {
            this.dummy = new Dummy(dummyHealth, dummyExperience);
        }

        // Act.
        [Test]
        public void TestIsDummyLosesHealthAfterAttack()
        {
            this.dummy.TakeAttack(10);
            const int expectedResult = 10;

            // Assert.
            Assert.AreEqual(expectedResult, this.dummy.Health, "Dummy does not loses health after attack");
        }

        // Act.
        [Test]
        public void TestIsDeadDummyThrowsExceptionIfAttacked()
        {
            this.dummy.TakeAttack(30);
            const int expectedResult = -10;

            // Assert.
            Assert.That(this.dummy.Health, Is.EqualTo(expectedResult));            
            Assert.That(() => this.dummy.TakeAttack(10), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        // Act.
        [Test]
        public void TestIsDeadDummyGiveExperience()
        {
            this.dummy.TakeAttack(30);            
            const int expectedResult = 100;

            // Assert.
            Assert.AreEqual(expectedResult, this.dummy.GiveExperience(), "Dead dummy should return experience points.");
        }

        // Act.
        [Test]
        public void TestIsAliveDummyThrowExeptionForGiveExperience()
        {
            // Assert.
            Assert.That(() => this.dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        // Clean up after each test.
        [TearDown]
        public void Clean() { }
    }
}
