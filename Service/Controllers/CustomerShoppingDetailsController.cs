using LetsShop;
using LetsShop.Models;
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
    public class CustomerShoppingDetailsController : ApiController
    {
        private LetshopContext db = new LetshopContext();

        [AllowAnonymous]
        [ActionName("GetselectedProducts")]
        [HttpGet]
        public HttpResponseMessage GetselectedProducts([FromUri]int productID, int customerID, int quantity)
        {
            var result=searchIfProductExists(productID,customerID, quantity);
            if (result!=true)
            {
                AddProductToList(productID, customerID, quantity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Success");
        }


        public void AddProductToList(int productID, int customerID, int quantity)
        {
            db.ProductList.Add(
                    new ProductList
                    {
                        CustomerID = customerID,
                        ProductID = productID,
                        SelectedQuantity = quantity
                    });
            db.SaveChanges();

        }

        public bool searchIfProductExists(int productID, int customerID, int quantity)
        {
            var selectedProducts = db.ProductList.Where(c => c.CustomerID == customerID).ToArray();
            if (selectedProducts.Where(c=>c.ProductID==productID).SingleOrDefault()!= null)
            {
                var productQuantity = selectedProducts.Where(c => c.ProductID == productID).Select(d => d.SelectedQuantity=d.SelectedQuantity+quantity).First();
                db.SaveChanges();
                return true;
            }
            return false;
        }


        [AllowAnonymous]
        [ActionName("postSelectedProductList")]
        [HttpGet]
        public IHttpActionResult postSelectedProductList([FromUri]int customerID)
        {
            List<ProductDetails> selectedProducts = new List<ProductDetails>();
            var list = db.ProductList.Where(c => c.CustomerID == customerID).ToArray();

            foreach (var product in list)
            {
                var productDetails = db.ProductDetails.Where(c => c.ProductID == product.ProductID).FirstOrDefault();
                productDetails.Quantity = product.SelectedQuantity;
                selectedProducts.Add(productDetails);
            }
            return Ok(selectedProducts.ToArray());
        }

        [AllowAnonymous]
        [ActionName("deleteProduct")]
        [HttpGet]
        public void deleteProduct([FromUri]int customerID,int productID)
        {
            var productList = db.ProductList.Where(c => c.CustomerID == customerID).Where(d => d.ProductID == productID).Select(x=>x).FirstOrDefault();
            db.ProductList.Remove(productList);
            db.SaveChanges();
        }

    }
}
