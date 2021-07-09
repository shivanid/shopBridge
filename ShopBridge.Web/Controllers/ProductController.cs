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
        //Return Collection of Values  
        // GET api/values
        // 
        public ProductController(IProductAction productAction)
        {
            _productAction = productAction;
        }
        public async Task<IEnumerable<Item>> Get()
        {
            //returning all records of table tblMember.  
            return await _productAction.Get();
        }


        //Receive the value and post it  
        // POST api/values  
        public IHttpActionResult Post([FromBody] Item item)
        {
            try
            {
                var result = _productAction.SaveItem(item);
                //return response status as successfully created with member entity  
                //var msg = Request.CreateResponse(HttpStatusCode.Created, item);
                //Response message with requesturi for check purpose  
                // msg.Headers.Location = new Uri(Request.RequestUri + item.ItemID.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return response as bad request  with exception message.  
                return BadRequest();
            }
        }

        ////Receive the value and update it  
        //// PUT api/values/5  
        public IHttpActionResult Put(int id, [FromBody] Item item)
        {

            var itemdetail = _productAction.UpdateItem(item);
            //return response status as successfully updated with member entity  
            if (itemdetail != null)
                return Ok(itemdetail);
            else
            {
                //return response error as NOT FOUND  with message.  
                return NotFound();
            }



        }

        ////Delete the value  
        //// DELETE api/values/5  
        public IHttpActionResult Delete(int itemId)
        {
            try
            {
                _productAction.Delete(itemId);

                //return response status as successfully deleted with member id  
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
