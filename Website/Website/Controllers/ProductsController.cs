using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        /*public ActionResult Random()
        {
            var product = new Product() {  Name = "Plain Shirt" };
            return View(product);
        }*/

        public ViewResult Index()
        {
            return View("ReadOnlyList");
        }
    }
}