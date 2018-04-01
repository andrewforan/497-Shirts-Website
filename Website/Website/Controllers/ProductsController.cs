using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

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

        public ActionResult ReadOnlyList()
        {
            var products = new List<Product>
            {
                new Product {ID = 1 , Name = "Gildan Men's Classic T-Shirt", Price = 19.99m },
                new Product { ID = 2, Name = "Shirt 2", Price = 14.99m},
                new Product { ID = 3, Name = "Shirt 3", Price = 11.99m},
                new Product { ID = 4, Name = "Shirt 4", Price = 17.99m},
                new Product { ID = 5, Name = "Shirt 5", Price = 14.99m},
                new Product { ID = 6, Name = "Shirt 6", Price = 19.99m},
                new Product { ID = 7, Name = "Shirt 7", Price = 9.99m},
                new Product { ID = 8, Name = "Shirt 8", Price = 13.99m},
                new Product { ID = 9, Name = "Shirt 9", Price = 19.99m}
            };

            var viewModel = new ProductsViewModel
            {
                Products = products,
            };

            return View(viewModel);
        }
    }
}