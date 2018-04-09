using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cart
        public ViewResult Index()
        {
            Cart c = new Cart();
            c = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);

            if (c.Contents != null)
            {
                string[] items = c.Contents.Split(',');
                List<Product> cartItems = new List<Product>();

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        string[] idSplit = items[i].Split('-');
                        int ID = int.Parse(idSplit[0]);

                        string[] sizeSplit = idSplit[1].Split('x');
                        string size = sizeSplit[0];
                        int quantity = int.Parse(sizeSplit[1]);

                        Product p = new Product();
                        p = _context.Products.First(x => x.ID == ID);
                        cartItems.Add(p);
                    }
                    catch
                    {
                        //
                    }
                }

                var products = cartItems;

                var viewModel = new ProductsViewModel
                {
                    Products = products,
                };

                return View("List", viewModel);
            }
            else
            {
                return View("List");
            }
        }
    }
}