using AppName.Web.Models;
using AppName.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.Controllers
{
    public class Products1Controller : Controller
    {
        // GET: Products1
        public ActionResult Index()
        {
            using (var db = new DataContex())
            {
                var viewModels = db.Products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category.Name

                }).ToList();
                return View(viewModels);
            }
            
        }

        public ActionResult Create()
        {
            using(var db = new DataContex())
            {
                var viewModel = new ProductViewModel();
                Supply(viewModel, db);
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            using (var db = new DataContex())
            {          
                if (ModelState.IsValid == false)
                {
                    Supply(viewModel, db);
                    return View(viewModel);
                }
                var product = new Product()
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    CategoryId = viewModel.CategoryId
                };
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
        }
        private void Supply(ProductViewModel viewModel, DataContex db)
        {
            viewModel.Categories = db.Categories
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
        }
    }
}