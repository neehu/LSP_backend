using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsShop.Models
{
   public class ProductList
    {
        [Key]
        public int ProductsListID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int SelectedQuantity { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
