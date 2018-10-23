using LetsShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsShop
{
   public class CustomerDetails
    {
        [Key]
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string AccessToken { get; set; }
        public ICollection<ProductList> ProductList { get; set; }


    }
}
