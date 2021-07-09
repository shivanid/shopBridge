using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Model;

namespace ShopBridge.Application.ProductAction
{
    public interface IProductAction
    {
        Task<IEnumerable<Item>> Get();
        int SaveItem(Item item);
        Task<Item> UpdateItem(Item item);
        void Delete(int itemId);

    }
}