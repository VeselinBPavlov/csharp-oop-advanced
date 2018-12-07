namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class StorageMasterBusinessLogicTests
    {
        // Tests of controller methods are indirect tests for
        // properties methods of classes and their factories.

        #region Set up class for tests.

        private const string ProductLowWeigth = "Ram";
        private const string ProductHighWeigth = "HardDrive";
        private const string InvalidType = "Hello";
        private const double ValidPrice = 12.00;
        private const double InvalidPrice = -12.00;
        private const string ValidStorageType = "Warehouse";
        private const string DestinationStorage = "DistributionCenter";
        private const string DestinationStorageName = "Avtogara";
        private const string StorageName = "DAP";
        private const string InvalidStorage = "Mars";
        private const int DestinationSlot = 3;
        private const int ValidGarageSlot = 0;
        private const int InvalidGarageSlot = 100;
        private const int EmptySlot = 5; // Is invalid for AutomatedWarehouse
        private readonly List<string> ValidProductsToLoad = new List<string>() { "Ram", "Ram", "Ram" };
        private readonly List<string> ValidProductsToLoadMany = new List<string>() { "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive"};

                
        private StorageMaster.Core.StorageMaster storageMaster;

        [SetUp]
        public void CreateInstanceForEachTest()
        {
            storageMaster = new StorageMaster.Core.StorageMaster();
        }

        #endregion

        #region Tests for AddProduct method
        [Test]
        public void TestIsAddProductWorksCorrect()
        {
            var result = storageMaster.AddProduct(ProductLowWeigth, ValidPrice);
            var expectedResult = $"Added {ProductLowWeigth} to pool";

            Assert.AreEqual(expectedResult, result, "AddProdcuct method has to store product");
        }

        [Test]
        public void TestIsAddProductThrowErrorWithInvalidProductType()
        {
            Assert.That(() => storageMaster.AddProduct(InvalidType, ValidPrice), Throws.InvalidOperationException.With.Message.EqualTo("Invalid product type!"));
        }

        [Test]
        public void TestIsAddProductThrowErrorWithInvalidPrice()
        {
            Assert.That(() => storageMaster.AddProduct(ProductLowWeigth, InvalidPrice), Throws.InvalidOperationException.With.Message.EqualTo("Price cannot be negative!"));
        }

        #endregion

        #region Tests for RegisterStorage method
        [Test]
        public void TestIsRegisterStorageMethodWorksCorrect()
        {
            var result = storageMaster.RegisterStorage(ValidStorageType, StorageName);
            var expectedResult = $"Registered {StorageName}";

            Assert.AreEqual(expectedResult, result, "Register storage should work correct.");
        }

        [Test]
        public void TestIsRegisterStorageMethodThrowErrorWithInvalidType()
        {
            Assert.That(() => storageMaster.RegisterStorage(InvalidType, StorageName), Throws.InvalidOperationException.With.Message.EqualTo("Invalid storage type!"));
        }

        #endregion

        #region Tests for SelectVehicle method

        [Test]
        public void TestIsSelectVehicleMethodWorksCorrect()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            var result = storageMaster.SelectVehicle(StorageName, ValidGarageSlot);
            var expectedResult = $"Selected Semi";

            Assert.AreEqual(expectedResult, result, "SelectVehicle should work correct.");
        }

        [Test]
        public void TestIsSelectVehicleMethodWithInvalidSlot()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);

            Assert.That(() => storageMaster.SelectVehicle(StorageName, InvalidGarageSlot), Throws.InvalidOperationException.With.Message.EqualTo("Invalid garage slot!"));
        }

        [Test]
        public void TestIsSelectVehicleMethodWithEmptySlot()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);

            Assert.That(() => storageMaster.SelectVehicle(StorageName, EmptySlot), Throws.InvalidOperationException.With.Message.EqualTo("No vehicle in this garage slot!"));
        }

        #endregion

        #region Tests for LoadVehicle method

        [Test]
        public void TestIsLoadVehicleMethodWorksCorrect()
        {
            storageMaster.AddProduct(ProductLowWeigth, ValidPrice);
            storageMaster.AddProduct(ProductLowWeigth, ValidPrice);
            storageMaster.AddProduct(ProductLowWeigth, ValidPrice);
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            storageMaster.SelectVehicle(StorageName, ValidGarageSlot);            

            var result = storageMaster.LoadVehicle(ValidProductsToLoad);
            var expectedResult = $"Loaded {ValidProductsToLoad.Count}/{ValidProductsToLoad.Count} products into Semi";

            Assert.AreEqual(expectedResult, result, "Load vehicle should work correct.");
        }

        [Test]
        public void TestIsLoadVehicleMethodWithOutOfStockProducts()
        {            
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            storageMaster.SelectVehicle(StorageName, ValidGarageSlot);

            // Test with out of stock.
            Assert.That(() => storageMaster.LoadVehicle(ValidProductsToLoad), Throws.InvalidOperationException.With.Message.EqualTo($"{ProductLowWeigth} is out of stock!"));

            // Test with not enough stock.
            storageMaster.AddProduct(ProductLowWeigth, ValidPrice);
            Assert.That(() => storageMaster.LoadVehicle(ValidProductsToLoad), Throws.InvalidOperationException.With.Message.EqualTo($"{ProductLowWeigth} is out of stock!"));
        }

        // TODO: Test with overload vehicle.

        #endregion

        #region Tests for SendVehicleTo method

        [Test]
        public void TestIsSendVehicleToMethodWorksCorrect()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            storageMaster.RegisterStorage(DestinationStorage, DestinationStorageName);            

            var result = storageMaster.SendVehicleTo(StorageName, ValidGarageSlot, DestinationStorageName);
            var expectedResult = $"Sent Semi to {DestinationStorageName} (slot {DestinationSlot})";
            Assert.AreEqual(expectedResult, result, "Load vehicle should work correct.");
        }

        [Test]
        public void TestIsSendVehicleToMethodInvalidSourceStorage()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            storageMaster.RegisterStorage(DestinationStorage, DestinationStorageName);
            
            // Test with invlid source storage.
            Assert.That(() => storageMaster.SendVehicleTo(InvalidStorage, ValidGarageSlot, DestinationStorageName), Throws.InvalidOperationException.With.Message.EqualTo("Invalid source storage!"));
            // Test with invalid destination storage.
            Assert.That(() => storageMaster.SendVehicleTo(StorageName, ValidGarageSlot, InvalidStorage), Throws.InvalidOperationException.With.Message.EqualTo("Invalid destination storage!"));
        }

        [Test]
        public void TestIsSendVehicleToMethodNoFreeSlotsInDestinationStorage()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);
            storageMaster.RegisterStorage(DestinationStorage, DestinationStorageName);

            storageMaster.SendVehicleTo(StorageName, ValidGarageSlot, DestinationStorageName);
            storageMaster.SendVehicleTo(StorageName, ValidGarageSlot + 1, DestinationStorageName);

            Assert.That(() => storageMaster.SendVehicleTo(StorageName, ValidGarageSlot + 2, DestinationStorageName), Throws.InvalidOperationException.With.Message.EqualTo("No room in garage!"));
        }

        #endregion

        #region Tests for UnloadVehicle method

        [Test]
        public void TestIsUnloadVehicleMethodWorksCorrect()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);            

            var result = storageMaster.UnloadVehicle(StorageName, ValidGarageSlot);
            var expectedResult = $"Unloaded 0/0 products at {StorageName}";
            Assert.AreEqual(expectedResult, result, "UnloadVehicle should work correct.");
        }

        // TODO: Tests UnloadVehicle method with exeption "Storage is full"! 

        #endregion

        #region Tests for GetStorageStatus method

        [Test]
        public void TestIsGetStorageStatusMethodWorksCorrect()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);

            var result = storageMaster.GetStorageStatus(StorageName);            
            var expectedResult = $"Stock (0/10): []\r\nGarage: [Semi|Semi|Semi|empty|empty|empty|empty|empty|empty|empty]";
            Assert.AreEqual(expectedResult, result, "GetStorageStatus should work correct.");
        }

        #endregion

        #region Tests for GetSummary method

        [Test]
        public void TestIsGetSummaryMethodWorksCorrect()
        {
            storageMaster.RegisterStorage(ValidStorageType, StorageName);

            var result = storageMaster.GetSummary();
            var expectedResult = $"{StorageName}:\r\nStorage worth: $0.00";
            Assert.AreEqual(expectedResult, result, "GetSummary should work correct.");
        }

        #endregion

    }
}
