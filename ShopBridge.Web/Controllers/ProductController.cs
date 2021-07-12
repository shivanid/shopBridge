using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ShopBridge.Application.ProductAction;
using ShopBridge.Model;

namespace ShopBridge.Web.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductAction _productAction;

        // GET api/Product
        public ProductController(IProductAction productAction)
        {
            _productAction = productAction;
        }
        public async Task<IEnumerable<Item>> Get()
        {
            //returning all records of table Item.  
            return await _productAction.Get();
        }

        //Receive the value and post it  
        // POST api/Product  
        public async Task<IHttpActionResult> Post([FromBody] Item item)
        {
            try
            {
                //Save new Item in Items table
                var result = await _productAction.SaveItem(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return response as bad request  with exception message.  
                return BadRequest(ex.Message);
            }
        }

        ////Receive the value and update it  
        //// PUT api/Product/ 
        public async Task<IHttpActionResult> Put([FromBody] Item item)
        {

            var itemdetail = await _productAction.UpdateItem(item);
            //return response status as successfully updated with item entity  
            if (itemdetail != null)
                return Ok(itemdetail);
            else
            {
                //return response error as NOT FOUND  with message.  
                return NotFound();
            }
        }

        ////Delete the value  
        //// DELETE api/Product/5  
        public async Task<IHttpActionResult> Delete(int itemId)
        {
            try
            {
                await _productAction.Delete(itemId);
                //return response status as successfully deleted with item id  
                return Ok(itemId);
            }

            catch (Exception ex)
            {
                //return response error as bad request  with exception message.  
                return BadRequest(ex.ToString());
            }
        }
    }
}
