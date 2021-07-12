using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Model;

namespace ShopBridge.Application.ProductAction
{
    public interface IProductAction
    {
        Task<IEnumerable<Item>> Get();
        Task<int> SaveItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<int> Delete(int itemId);

    }
}