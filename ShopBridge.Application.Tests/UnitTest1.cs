using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Model;

namespace ShopBridge.Application.Tests
{
    [TestClass]
    public class ApplicationTests
    {

        private ProductAction.ProductAction _productBaseAction;

        [TestInitialize]
        public void Initialize()
        {
            _productBaseAction = new ProductAction.ProductAction();
        }

        [TestMethod]
        public void GetItem_Test()
        {
            // Arrange

            // Act
            var items = _productBaseAction.Get();

            //Assert
            Assert.IsNotNull(items);
        }

        private List<Item> GetTestItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item { ItemID = 1, ItemName = "Laptop", Description = "Dell i7", price = 100000 });
            items.Add(new Item { ItemID = 1, ItemName = "Mouse", Description = "Dell", price = 650 });
            items.Add(new Item { ItemID = 1, ItemName = "HeadPhones", Description = "JBL", price = 1800 });
            items.Add(new Item { ItemID = 1, ItemName = "Charger", Description = "Dell", price = 4000 });
            return items;
        }
    }
}
