namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        // Arrange.
        private Database database;
        private const int MaxLength = 16;
        private const int DefaultIndexPosition = -1;
        private int[] ValidArray = new int[3] { 1, 2, 3 };
        private int[] InvalidArray = new int[17];
        private int[] MaxValidArray = new int[16];
        private int number = 1;
        
        // Test constructors.        
        [Test]
        public void TestIsEmptyContructorWorksCorrectly()
        {
            // Arrange.
            database = new Database();

            Type type = typeof(Database);

            var data = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "data")
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
        
        [Test]
        public void TestIsNotEmptyContructorWorksCorrectly()
        {
            // Arranage.
            database = new Database(ValidArray);

            Type type = typeof(Database);

            var data = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "data")
                .GetValue(database);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(database);

            var expextedIndexPosition = ValidArray.Length - 1;
            var expectedElementOnSecondIndex = ValidArray[2];

            // Assert.
            Assert.AreEqual(expextedIndexPosition, index, "Index should be on valid array length -1.");
            Assert.AreEqual(expectedElementOnSecondIndex, data[index], "Numbers from input array and data array should be equal.");
        }
        
        [Test]
        public void TestIsNotEmptyContructorThrowsAnErrorWithInputBiggerArray()
        {
            // Assert.        // Act.
            Assert.That(() => database = new Database(InvalidArray), Throws.InvalidOperationException.With.Message.EqualTo("Input array length is bigger than database length!"));
        }

        // Test Add method.
        [Test]
        public void TestIsAddMethodWillAddElement()
        {
            // Arrange.
            database = new Database(ValidArray);

            // Act.
            database.Add(number);

            Type type = typeof(Database);

            var data = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "data")
                .GetValue(database);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(database);

            var expectedValue = number;
            var expectedIndex = ValidArray.Length;

            // Assert.
            Assert.AreEqual(expectedValue, data[index], "Input number and number of data on the current index should be equal.");
            Assert.AreEqual(expectedIndex, index, "Expexted index possition should be equal to next index of ValidArray.");
        }

        [Test]
        public void TestIsAddMethodWillThrowErrorWithFullDatabase()
        {
            // Arrange.
            database = new Database(MaxValidArray);
            // Assert.        // Act.
            Assert.That(() => database.Add(number), Throws.InvalidOperationException.With.Message.EqualTo("There is no empty space in database!"));
        }


        // Test Remove method.
        [Test]
        public void TestIsRemoveMethodWorkCorrect()
        {
            // Arrange.
            database = new Database(ValidArray);

            // Act.
            database.Remove();

            Type type = typeof(Database);

            var data = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "data")
                .GetValue(database);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "index")
                .GetValue(database);

            var expectedIndex = ValidArray.Length - 1;

            // Assert.
            Assert.AreEqual(expectedIndex, data[index], "Current index shoud be on one possition back");
        }

        [Test]
        public void TestIsRemoveMethodThrowErrorWithEmptyDatabase()
        {
            // Assert.
            database = new Database();

            // Assert.        // Act.
            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove element from empty database!"));
        }

        // Test Fetch method.
        [Test]
        public void TestIsFetchMethodWorksCorrect()
        {
            // Assert.
            database = new Database(ValidArray);
            var outputArray = database.Fetch();

            //Assert.
            Assert.AreEqual(ValidArray, outputArray, "Arrays should be equals.");
        }

        // Clean up after each test.
        [TearDown]
        public void Clean() { }
    }
}
