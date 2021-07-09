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
            //returning all records of table tblMember.  
            return db.Items.ToList().AsEnumerable();
        }

        public int SaveItem(Item item)
        {


            //To add an new member record  
            db.Items.InsertOnSubmit(item);

            //Save the submitted record  
            db.SubmitChanges();

            return item.ItemID;

        }

        public async Task<Item> UpdateItem(Item item)
        {

            if (!validateItem(item))
            {
                throw new Exception("Invalid item");
            }
            //fetching and filter specific member id record   
            var itemdetail = (from a in db.Items where a.ItemID == item.ItemID select a).FirstOrDefault();

            //checking fetched or not with the help of NULL or NOT.  
            if (itemdetail != null)
            {
                //set received _member object properties with memberdetail  
                itemdetail.ItemName = item.ItemName;
                itemdetail.Description = item.Description;
                itemdetail.price = item.price;
                //save set allocation.  
                db.SubmitChanges();
                return itemdetail;

            }

            return null;
        }

        public async void Delete(int itemId)
        {
            //fetching and filter specific member id record   
            var _DeleteItem = (from a in db.Items where a.ItemID == itemId select a).FirstOrDefault();

            //checking fetched or not with the help of NULL or NOT.  
            if (_DeleteItem != null)
            {

                db.Items.DeleteOnSubmit(_DeleteItem);
                db.SubmitChanges();

                //return response status as successfully deleted with member id  
            }
            else
            {
                //return response error as Not Found  with exception message.  
                throw new Exception("Item not found" + itemId.ToString());
            }

        }

        private bool validateItem(Item item)
        {
            if (item.ItemName == null || item.price == null || item.Description == null)
                return false;
            return true;
        }
    }
}