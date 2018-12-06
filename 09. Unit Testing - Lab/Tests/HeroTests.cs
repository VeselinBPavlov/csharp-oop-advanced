namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    [TestFixture]
    public class HeroTests
    {
        // Testing with fake objects is not a good practice.
        // Arrange.
        //private Hero hero;
        //private const string name = "Pesho";
        //private IWeapon fakeWeapon = new FakeWeapon();
        //private ITarget fakeTarget = new FakeTarget();

        //[SetUp]
        //public void CreateHeroForAllTests()
        //{
        //    this.hero = new Hero(fakeWeapon, name);
        //}

        //// Act.
        //public void TestIsHeroGainExperience()
        //{
        //    this.hero.Attack(fakeTarget);
        //    var expectedResult = 10;

        //    // Assert.
        //    Assert.AreEqual(expectedResult, this.hero.Experience, "Hero should receive experience if target is dead!");
        //}


        // Using Moq library for testing with objects simulation.

        // Arrange.
        private const string name = "Pesho";
        private Hero hero;
        private Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        private Mock<ITarget> fakeTarget = new Mock<ITarget>();

        [SetUp]
        public void CreateHeroForAllTests()
        {
            this.hero = new Hero(fakeWeapon.Object, name);
        }

        // Act.
        [Test]
        public void TestIsHeroGainExperience()
        {
            fakeWeapon.Setup(x => x.AttackPoints).Returns(10);
            fakeWeapon.Setup(x => x.DurabilityPoints).Returns(15);

            fakeTarget.Setup(x => x.Health).Returns(0);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(10);
            fakeTarget.Setup(x => x.IsDead()).Returns(true);

            this.hero.Attack(fakeTarget.Object);
            var expectedResult = 10;

            // Assert.
            Assert.AreEqual(expectedResult, this.hero.Experience, "Hero should receive experience if target is dead!");
        }

        // Act.
        [Test]
        public void TestIsHeroNotGainExperience()
        {
            fakeWeapon.Setup(x => x.AttackPoints).Returns(10);
            fakeWeapon.Setup(x => x.DurabilityPoints).Returns(15);

            fakeTarget.Setup(x => x.Health).Returns(20);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(10);
            fakeTarget.Setup(x => x.IsDead()).Returns(false);

            this.hero.Attack(fakeTarget.Object);
            var expectedResult = 0;

            // Assert.
            Assert.AreEqual(expectedResult, this.hero.Experience, "Hero should not receive experience if target is dead!");
        }

        // Clean up after each test.
        [TearDown]
        public void Clean() { }
    }
}
