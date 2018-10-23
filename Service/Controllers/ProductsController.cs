using LetsShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private LetshopContext db = new LetshopContext();
        [AllowAnonymous]
        [HttpGet]
        [ActionName("postProductdetails")]
        public IHttpActionResult postProductdetails()
        {
            return Ok(db.ProductDetails.ToArray());
        }
        [AllowAnonymous]
        [HttpGet]
        [ActionName("postlistofCategories")]
        public IHttpActionResult postlistofCategories()
        {
            return Ok(db.CategoryDetails.ToArray());
        }

    }
}
