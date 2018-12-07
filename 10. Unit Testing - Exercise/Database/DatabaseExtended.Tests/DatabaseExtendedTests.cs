namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    // There unit test include only specific unit tests for database extended task. 

    [TestFixture]
    public class DatabaseExtendedTests
    {
        private Database database;
        private Person person;

        private const int MaxLength = 16;
        private const int DefaultIndexPosition = -1;
        private const string Name = "Pesho";
        private const long Id = 123456;
        
        // Test constructors.        
        [Test]
        public void TestIsEmptyContructorWorksCorrectly()
        {
            // Arrange.
            database = new Database();

            Type type = typeof(Database);

            var data = (Person[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "people")
                .GetValue(database);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(database);

            var expextedLength = MaxLength;
            var expextedIndexPosition = DefaultIndexPosition;

            // Assert.
            Assert.AreEqual(expextedLength, data.Length, "Database length should be 16.");
            Assert.AreEqual(expextedIndexPosition, index, "Index should be on -1 possition.");
        }

        // Test Add method.
        [Test]
        public void TestIsAddMethodAddPersonCoorect()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);

            // Act.
            database.Add(person);

            Type type = typeof(Database);

            var data = (Person[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "people")
                .GetValue(database);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(database);

            var expectedIndex = 0;
            var expectedPerson = person;

            // Assert.
            Assert.AreEqual(expectedIndex, index, "Index should be at 0 possition.");
            Assert.AreEqual(expectedPerson.Name, data[index].Name, "Should return the same person.");
        }

        [Test]
        public void TestIsAddMethodThrowErrorForTwoPersonsWithSameName()
        {
            // Arrange.
            database = new Database();
            var personOne = new Person("Pesho", 123);
            var samePerson = new Person("Pesho", 11123);

            // Act.
            database.Add(personOne);

            // Assert.
            Assert.That(() => database.Add(samePerson), Throws.InvalidOperationException.With.Message.EqualTo("There is already a person with the same name!"));
        }

        [Test]
        public void TestIsAddMethodThrowErrorForTwoPersonsWithSameId()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);            

            // Act.
            database.Add(person);

            // Assert.
            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("There is already a person with the same Id!"));
        }

        // Test FindByUsername method.
        [Test]
        public void TestIsFindPersonByUsernameMethodWorkCorrect()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);
            database.Add(person);

            // Act.
            var result = database.FindByUsername("Pesho");

            // Assert.
            Assert.AreEqual(person.Name, result.Name, "Find person by username not work correct!");
        }

        [Test]
        public void TestIsFindPersonByUsernameMethodThrowErrorIfNotFind()
        {
            // Arrange.
            database = new Database();

            // Assert.      // Act.
            Assert.That(() => database.FindByUsername("Pesho"), Throws.InvalidOperationException.With.Message.EqualTo("Person does not exists in database."));
        }

        [Test]
        public void TestIsFindPersonByUsernameMethodThrowErrorNullInput()
        {
            // Arrange.
            database = new Database();

            // Assert.      // Act.
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null), "Input username cannot be null");
        }

        // Test FindById method.
        [Test]
        public void TestIsFindPersonByIdWorksCorrect()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);
            database.Add(person);

            // Act.
            var result = database.FindById(123);

            // Assert.
            Assert.AreEqual(person.Name, result.Name, "Find person by Id not work correct!");
        }

        [Test]
        public void TestIsFindPersonByIdThowErrorWithNegativeInput()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);
            database.Add(person);

            // Assert.      // Act.
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-123), "Should throw exeption.");
        }

        [Test]
        public void TestIsFindPersonByIdThowErrorWithIdNotFound()
        {
            // Arrange.
            database = new Database();
            person = new Person("Pesho", 123);
            database.Add(person);

            // Assert.      // Act.
            Assert.Throws<InvalidOperationException>(() => database.FindById(124), "Should throw exeption.");
        }
    }
}
