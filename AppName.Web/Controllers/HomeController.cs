﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /*[route("/hello/{id2}")]
        public actionresult id(int id)
        {
            var product = new
            {
                name = "test",
                price = id
            };
            return json(product, jsonrequestbehavior.allowget);

            return redirect("http://plawgo.pl");

            return redirecttoaction("index");
        } */
    }
}