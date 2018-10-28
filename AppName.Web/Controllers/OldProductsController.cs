using AppName.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bogus;

namespace AppName.Web.Controllers
{
    public class OldProductsController : Controller
    {
        //BOGUS z nuGet
        private static List<Product> _products;
        static OldProductsController()
        {
            
        }
        // GET: Products
        public ActionResult Index()
        {
            using (var db = new DataContex())
            {
                return View(db.Products
                    .Where(p => p.Id >2)
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.Id)
                    .Skip(1)
                    .Take(2)
                    .ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {/*powinno sie dodawac w kazdej akcji*/
            if (ModelState.IsValid == false)
            {
                return View();
            }
            using (var db = new DataContex())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //_products.Add(product);
            
        }
    }
}