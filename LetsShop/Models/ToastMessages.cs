using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsShop.Models
{
   public class ToastMessages
    {
        [Key]
        public int MessageID { get; set; }
        public string Content { get; set; }
        public string Style { get; set; }
        public Boolean Dismissed { get; set; }

        public ToastMessages()
        {
            

        }

        public ToastMessages( string Content,string style="info",Boolean dismissed=false)
        {
            this.Content = Content;
            this.Style = style;
            this.Dismissed = dismissed;
        }

    }
}
