using LetsShop;
using Service.Models;
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
    public class CustomerController : ApiController
    {
        private LetshopContext db = new LetshopContext();

        //Add new Customer
        [AllowAnonymous]
        [HttpPost]
        [ActionName("GetNewCustomer")]
        public HttpResponseMessage GetNewCustomer([FromUri] string userName, string password, string emailAddress, long phoneNumber, string city, string address)
        {
           var response= checkIfUserExists(userName, emailAddress);
            if (response.IsSuccessStatusCode)
            {
                db.CustomerDetails.Add(
                    new CustomerDetails
                    {
                        UserName = userName,
                        Password = password,
                        EmailAddress = emailAddress,
                        PhoneNumber = phoneNumber,
                        City = city,
                        Address = address
                    }
                );
                db.SaveChanges();
            }
            return response;
           
        }

       public HttpResponseMessage checkIfUserExists(string userName,string emailAddress)
        {
            if(db.CustomerDetails.Where(c=>(c.UserName==userName)||(c.EmailAddress==emailAddress)).FirstOrDefault()!=null)
            {
                if(db.CustomerDetails.Where(c=>(c.UserName==userName)).FirstOrDefault()!=null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "UserName Exists Please Choose Another");
                }
                if(db.CustomerDetails.Where(c=>(c.EmailAddress==emailAddress)).FirstOrDefault()!=null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden,"Email Address is registered");
                }
               
            }
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Registerd Sucessfully");
        }

        //Get customer details by ID
        [AllowAnonymous]
        [HttpGet]
        [ActionName("PostCustomerDetail")]
        public IHttpActionResult PostCustomerDetail([FromUri] int customerID)
        {
            CustomerDetails customer = new CustomerDetails();
            customer = db.CustomerDetails.Where(
             c => (c.CustomerID == customerID)).FirstOrDefault();
            return Ok(customer);
        }


        // DELETE a customer
        [AllowAnonymous]
        [HttpGet]
        [ActionName("DeleteCustomer")]
        public void Delete([FromUri]int ID)
        {

            CustomerDetails customer = db.CustomerDetails.Where(c => (c.CustomerID == ID)).FirstOrDefault();
            db.CustomerDetails.Remove(customer);
            db.SaveChanges();
        }

        //Check loginDetails
        [AllowAnonymous]
        [HttpGet]
        [ActionName("CheckLoginDetails")]
        public HttpResponseMessage CheckLoginDetails([FromUri] string userName, string password)
        {
            CustomerDetails customer = new CustomerDetails();
            HttpResponseMessage result = new HttpResponseMessage();


            ////Validate USerName and Password from Databse
             result=ValidateLoginDetails(userName, password);
            ////If user is valid generate a token 
            customer = result.Content.ReadAsAsync<CustomerDetails>().Result;
            if (result.IsSuccessStatusCode)
            {
                customer.AccessToken = new JWTManager().GenerateToken(customer.UserName,customer.Password);
                return Request.CreateResponse<CustomerDetails>(result.StatusCode,customer);

            }
            return result;
        }

        public HttpResponseMessage ValidateLoginDetails(string userName, string password)
        {
            CustomerDetails customer = new CustomerDetails();
            //Check if username exists
            if (db.CustomerDetails.Where(c => (c.UserName == userName)).FirstOrDefault() != null)
            {
                //
                if (db.CustomerDetails.Where(c => (c.UserName == userName)&&(c.Password == password)).FirstOrDefault() != null)
                {
                  customer = db.CustomerDetails.Where(c => (c.UserName == userName)&&(c.Password == password)).FirstOrDefault();
                    return Request.CreateResponse<CustomerDetails> (HttpStatusCode.OK ,customer);
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "InvalidPassword");
                }
            }
            else
            {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserNameNotFound");
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("ChangeEmail")]
        public HttpResponseMessage ChangeEmail([FromUri]int customerID,string newEmailAddress)
        {
            var result=checkIfEmailAddressExists(newEmailAddress, customerID);
            if (result.StatusCode != HttpStatusCode.Forbidden)
            {
                var customer = db.CustomerDetails.Where(x => x.CustomerID == customerID).FirstOrDefault();
                customer.EmailAddress = newEmailAddress;
                db.SaveChanges();
              
                return Request.CreateResponse(HttpStatusCode.OK, "EmailAddress Changed");
            }

            else
            {
                return result;
            }
        }

        public HttpResponseMessage checkIfEmailAddressExists(string newEmailAddress, int customerID)
        {
           var oldEmailAddress= db.CustomerDetails.Where(x => x.CustomerID == customerID).Select(x => x.EmailAddress).First();
           var ifEmailAddressExists = db.CustomerDetails.Select(x => x.EmailAddress).Contains(newEmailAddress);
            if((oldEmailAddress==newEmailAddress) || (ifEmailAddressExists))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "EmailAddress already registered.Please enter new one");
            }
            return  Request.CreateErrorResponse(HttpStatusCode.OK, ""); ;
        }


    }
}

