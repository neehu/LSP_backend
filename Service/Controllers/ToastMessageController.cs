using LetsShop;
using LetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToastMessageController : ApiController
    {
        private LetshopContext db = new LetshopContext();

        [AllowAnonymous]
        [HttpGet]
        [ActionName("postMessages")]
        public IHttpActionResult postMessages()
        {
           var listOfToastMessages=this.db.ToastMessages.ToList();
            return Ok(listOfToastMessages);
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("getMessages")]
        public IHttpActionResult getMessages([FromUri]string content,string style)
        {
            ToastMessages toastMessage = new ToastMessages(content,style);
            this.db.ToastMessages.Add(new ToastMessages {
                Content= content,
                Style=style
            }
                );
            db.SaveChanges();
            return Ok("Added");
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("dismissMessage")]
        public IHttpActionResult dismissMessage(int messageID)
        {
           var result= this.db.ToastMessages.Where(message => messageID == message.MessageID).FirstOrDefault().Dismissed = true;
            db.SaveChanges();
            return Ok("Done");
        }

    }
}
