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
            decimal total = 0;
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
                        string[] detailSplit = items[i].Split('x');
                        int ID = int.Parse(detailSplit[0]);
                        int quantity = int.Parse(detailSplit[1]);

                        Product p = new Product();
                        p = _context.Products.First(x => x.ID == ID);
                        total += p.Price;
                        cartItems.Add(p);
                    }
                    catch
                    {
                        //
                    }
                }

                //c.Total = total;

                //_context.Cart.Attach(c);
                //var entry = _context.Entry(c);
                //entry.Property(e => e.Total).IsModified = true;
                //_context.SaveChanges();

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

        public ViewResult Checkout()
        {
            return View("Checkout");
        }

        public ActionResult ContinueShopping()
        {
            return RedirectToAction("Index", "Products");
        }

        //[HttpPost]
        //public ActionResult RemoveProduct()
        //{
        //    Cart cart = new Cart();
        //    cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);


        //    if (cart.Contents != null)
        //    {
        //        string[] items = cart.Contents.Split(',');
        //        List<Product> cartItems = new List<Product>();

        //        for (int i = 0; i < items.Count(); i++)
        //        {
        //            try
        //            {
        //                string[] detailSplit = items[i].Split('x');
        //                int ID = int.Parse(detailSplit[0]);
        //                byte quantity = byte.Parse(detailSplit[1]);

        //                Product p = new Product();
        //                p.ID = ID;
        //                p.NumberInStock = quantity; //used for number of items in cart
        //                cartItems.Add(p);
        //            }
        //            catch
        //            {
        //                //
        //            }
        //        }

        //        foreach (var cartItem in cartItems)
        //        {
        //            if (cartItem.ID)
        //        }
        //    }

        //        _context.Cart.Attach(cart);
        //    var entry = _context.Entry(cart);
        //    entry.Property(e => e.Contents).IsModified = true;
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Products");
        //}
    }
}