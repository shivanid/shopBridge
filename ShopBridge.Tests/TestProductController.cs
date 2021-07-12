using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge.Application.ProductAction;
using ShopBridge.Model;
using ShopBridge.Web.Controllers;

namespace ShopBridge.Tests
{
    [TestClass]
    public class TestProductController
    {
        private ProductController controller { get; set; }
        private Mock<IProductAction> _ProductActionMock { get; set; }

        [TestInitialize]
        public void TestSetup()
        {
            _ProductActionMock = new Mock<IProductAction>();

            controller = new ProductController(_ProductActionMock.Object);
        }

        [TestMethod]
        public void GetAllItems_GetItemMethosShouldGetCalled()
        {
            // Act
            controller.Get();

            // Assert
            _ProductActionMock.Verify(p => p.Get());
        }

        [TestMethod]
        public void OnSaveItem_SaveActionShouldGetCall()
        {
            // Arrange
            Item item = new Item() { ItemID = 1, ItemName = "Laptop", Description = "Dell i7", price = 100000 };
            _ProductActionMock.Setup(action => action.SaveItem(It.IsAny<Item>())).Returns(It.IsAny<Task<int>>());
            // Act
            controller.Post(item);

            // Assert
            _ProductActionMock.Verify(p => p.SaveItem(item));
        }

        [TestMethod]
        public void OnDelete_DeleteActionShouldGetCall()
        {
            // Arrange
            int itemId = 1;
            // Act
            controller.Delete(itemId);

            // Assert
            _ProductActionMock.Verify(p => p.Delete(itemId));
        }

        [TestMethod]
        public void Onupdate_UpdateActionShouldGetCall()
        {
            // Arrange
            Item item = new Item { ItemID = 1, ItemName = "Laptop", Description = "Dell i7", price = 120000 };

            // Act
            controller.Put(item);

            // Assert
            _ProductActionMock.Verify(p => p.UpdateItem(item));
        }

    }
}
