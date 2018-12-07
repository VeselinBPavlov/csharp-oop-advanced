namespace StorageMester.Tests.Structure
{
    #region Usings

    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    [TestFixture]
    public class StorageMasterStructureTests
    {
        // This is a test class for structure of StorageMaster assembly.

        // There are tests for existing of reqired classes, abstract 
        // classes and their constructors, properties and methods.

        // There are no tests for existing of reqired getters and setters.

        // There are no test for existing of reqired fields.

        #region Set up class for tests.
        private const int NumberOfRequiredClasses = 15;
        private Type type;
        private BindingFlags flagsFields;
        private BindingFlags flagsProperties;
        private BindingFlags flagsAll;
        private Assembly assembly;

        [SetUp]
        public void GenerateTypeAndCallAssemblyBeforeEachTest()
        {
            type = typeof(StartUp);
            flagsFields = BindingFlags.Instance | BindingFlags.NonPublic;
            flagsProperties = BindingFlags.Instance | BindingFlags.Public;
            flagsAll = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            assembly = Assembly.GetAssembly(type);
        }

        #endregion

        #region Check for required all classes, abstract classes and inheritance.

        [Test]
        [TestCase("StartUp")]
        [TestCase("Vehicle")]
        [TestCase("Van")]
        [TestCase("Truck")]
        [TestCase("Semi")]
        [TestCase("Warehouse")]
        [TestCase("Storage")]
        [TestCase("DistributionCenter")]
        [TestCase("AutomatedWarehouse")]
        [TestCase("SolidStateDrive")]
        [TestCase("Ram")]
        [TestCase("Product")]
        [TestCase("HardDrive")]
        [TestCase("Gpu")]
        [TestCase("StorageMaster")]
        public void TestIsAssemblyHasAllClassesNeeded(string className)
        {
            List<string> classes = assembly.GetTypes().Select(x => x.Name).ToList();
            Assert.IsTrue(classes.Contains(className), $"Assembly does not contains {className} class.");
        }


        // Test for required abstract classes.
        [Test]
        public void TestIsVehicleAbstractClass()
        {
            type = typeof(Vehicle);
            Assert.IsTrue(type.IsAbstract, $"Vehicle class has to be abstract.");
        }

        [Test]
        public void TestIsStorageAbstractClass()
        {
            type = typeof(Storage);
            Assert.IsTrue(type.IsAbstract, $"Storage class has to be abstract.");
        }

        [Test]
        public void TestIsProductAbstractClass()
        {
            type = typeof(Product);
            Assert.IsTrue(type.IsAbstract, $"Storage class has to be abstract.");
        }


        // Check for childs of abstract classes.
        [Test]
        [TestCase("Van")]
        [TestCase("Truck")]
        [TestCase("Semi")]
        public void TestIsAbstractClassVehicleHasRequiredChilds(string childClass)
        {
            Type parent = typeof(Vehicle);
            List<string> types = parent.Assembly.GetTypes().Where(t => parent.IsAssignableFrom(t)).Select(x => x.Name).ToList();            

            Assert.IsTrue(types.Contains(childClass), $"Assembly does not contains {childClass} class.");
        }

        [Test]
        [TestCase("Warehouse")]
        [TestCase("DistributionCenter")]
        [TestCase("AutomatedWarehouse")]
        public void TestIsAbstractClassStorageHasRequiredChilds(string childClass)
        {
            Type parent = typeof(Storage);
            List<string> types = parent.Assembly.GetTypes().Where(t => parent.IsAssignableFrom(t)).Select(x => x.Name).ToList();

            Assert.IsTrue(types.Contains(childClass), $"Assembly does not contains {childClass} class.");
        }

        [Test]
        [TestCase("SolidStateDrive")]
        [TestCase("Ram")]
        [TestCase("HardDrive")]
        [TestCase("Gpu")]
        public void TestIsAbstractClassProductHasRequiredChilds(string childClass)
        {
            Type parent = typeof(Product);
            List<string> types = parent.Assembly.GetTypes().Where(t => parent.IsAssignableFrom(t)).Select(x => x.Name).ToList();

            Assert.IsTrue(types.Contains(childClass), $"Assembly does not contains {childClass} class.");
        }

        #endregion

        #region Tests for contructors of required abstract classes.

        [Test]
        [TestCase("Vehicle")]
        [TestCase("Van")]
        [TestCase("Truck")]
        [TestCase("Semi")]
        [TestCase("Warehouse")]
        [TestCase("Storage")]
        [TestCase("DistributionCenter")]
        [TestCase("AutomatedWarehouse")]
        [TestCase("SolidStateDrive")]
        [TestCase("Ram")]
        [TestCase("Product")]
        [TestCase("HardDrive")]
        [TestCase("Gpu")]
        [TestCase("StorageMaster")]
        public void TestIsForVehicleContructor(string className)
        {            
            type = assembly.GetTypes().FirstOrDefault(t => t.Name == className);
            var costructor = type.Assembly.GetType().GetConstructor(flagsAll, null, Type.EmptyTypes, null);

            Assert.IsTrue(costructor.IsConstructor, $"{className} class should has constructor");
        }

        #endregion

        #region Tests for required properties of abstract classes.

        [Test]
        [TestCase("Trunk")]
        [TestCase("Capacity")]
        [TestCase("IsFull")]
        [TestCase("IsEmpty")]
        public void TestIsVehicleHasRequiredProperties(string propertyName)
        {
            type = typeof(Vehicle);
            var properties = type.GetProperties().Select(x => x.Name).ToList();

            Assert.IsTrue(properties.Contains(propertyName), $"Vehicle class does not contains {propertyName} class.");
        }

        [Test]
        [TestCase("Name")]
        [TestCase("Capacity")]
        [TestCase("GarageSlots")]
        [TestCase("IsFull")]
        [TestCase("Garage")]
        [TestCase("Products")]
        public void TestIsStorageHasRequiredProperties(string propertyName)
        {
            type = typeof(Storage);
            var properties = type.GetProperties().Select(x => x.Name).ToList();

            Assert.IsTrue(properties.Contains(propertyName), $"Storage class does not contains {propertyName} class.");
        }

        [Test]
        [TestCase("Price")]
        [TestCase("Weight")]
        public void TestIsProductHasRequiredProperties(string propertyName)
        {
            type = typeof(Product);
            var properties = type.GetProperties().Select(x => x.Name).ToList();

            Assert.IsTrue(properties.Contains(propertyName), $"Product class does not contains {propertyName} class.");
        }

        #endregion

        #region Tests for required methods of abstract classes.

        [Test]
        [TestCase("LoadProduct")]
        [TestCase("Unload")]
        public void TestIsVehicleHasRequiredMethods(string methodName)
        {
            type = typeof(Vehicle);
            var methods = type.GetMethods().Select(x => x.Name).ToList();

            Assert.IsTrue(methods.Contains(methodName), $"Vehicle class does not contains {methodName} class.");
        }

        [Test]
        [TestCase("GetVehicle")]
        [TestCase("SendVehicleTo")]
        [TestCase("UnloadVehicle")]
        public void TestIsStorageHasRequiredMethods(string methodName)
        {
            type = typeof(Storage);
            var methods = type.GetMethods().Select(x => x.Name).ToList();

            Assert.IsTrue(methods.Contains(methodName), $"Storage class does not contains {methodName} class.");
        }

        #endregion

        #region Clear
        // Clean up after each test.
        [TearDown]
        public void Clean() { }
        #endregion
    }
}
