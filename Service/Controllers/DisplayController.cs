using LetsShop;
using LetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Controllers
{
    public class DisplayController : Controller
    {
        private LetshopContext db = new LetshopContext();
        private List<ProductDetails> products = new List<ProductDetails>();
        // GET: Display
        public ActionResult DisplayPage()
        {
            var lproducts = new List<ProductDetails>();
            lproducts = db.ProductDetails.ToList();
            return View(lproducts);
        }

        // GET: Display/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Display/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Display/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Display/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Display/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Display/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Display/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
