using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.Model;

namespace ShopBridge.Application.ProductAction
{
    public class ProductAction : IProductAction
    {
        ProductDataClassesDataContext db = new ProductDataClassesDataContext();

        public async Task<IEnumerable<Item>> Get()
        {
            //returning all records of table items.  
            return db.Items.ToList().AsEnumerable();
        }

        public async Task<int> SaveItem(Item item)
        {
            try
            {
                //validate incoming item
                if (!validateItem(item))
                {
                    throw new Exception("Invalid item");
                }

                //To add an new item record  
                db.Items.InsertOnSubmit(item);

                //Save the submitted record  
                db.SubmitChanges();

                return item.ItemID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Item> UpdateItem(Item item)
        {
            try
            {
                //Validate incoming item
                if (!validateItem(item))
                {
                    throw new Exception("Invalid item");
                }
                //fetching and filter specific item id record   
                var itemdetail = (from a in db.Items where a.ItemID == item.ItemID select a).FirstOrDefault();

                //checking fetched or not with the help of NULL or NOT.  
                if (itemdetail != null)
                {
                    //set received item object properties with itemdetail  
                    itemdetail.ItemName = item.ItemName;
                    itemdetail.Description = item.Description;
                    itemdetail.price = item.price;
                    //save set allocation.  
                    db.SubmitChanges();
                    return itemdetail;

                }
                else
                {
                    //return response error as Not Found  with exception message.  
                    throw new Exception("Item not found" + item.ItemID.ToString());
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<int> Delete(int itemId)
        {
            try
            {
                //fetching and filter specific item id record   
                var _DeleteItem = (from a in db.Items where a.ItemID == itemId select a).FirstOrDefault();

                //checking fetched or not with the help of NULL or NOT.  
                if (_DeleteItem != null)
                {

                    db.Items.DeleteOnSubmit(_DeleteItem);
                    db.SubmitChanges();
                    return itemId;
                }
                else
                {
                    //return response error as Not Found  with exception message.  
                    throw new Exception("Item not found" + itemId.ToString());
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private bool validateItem(Item item)
        {
            //Validate null value 
            if (item?.ItemName == null || item.price == null || item.Description == null)
                return false;

            //validate price
            if (item.price <= 0)
                return false;

            return true;
        }
    }
}