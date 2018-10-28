using AppName.Web.Models;
using AppName.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        //[Display(Name = "Nazwa")]
        [Display(Name = "Name",
            ResourceType = typeof(ProductResources))]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }
        //[Display(Name = "Cena")]
        [Display(Name = "Price",
            ResourceType = typeof(ProductResources))]
        public decimal Price { get; set; }
        //public string Category { get; set; }
        public int CategoryId { get; set; }

        public string Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}