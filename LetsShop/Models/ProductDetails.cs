using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsShop.Models
{
   public class ProductDetails
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public CategoryDetails CategoryDetails { get; set; }

    }
}
