using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsShop.Models
{
   public class CategoryDetails
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfProducts { get; set; }
        public string CategoryDescription { get; set; }
    }
}
