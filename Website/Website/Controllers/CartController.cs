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
                        p.NumberInStock = quantity; // number in stock used for quanitity, hack
                        total += p.Price;
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

        public ViewResult Checkout()
        {
            return View("Checkout");
        }

        public ActionResult ContinueShopping()
        {
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public ActionResult RemoveProduct(ProductsViewModel pv)
        {
            Cart cart = new Cart();
            cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);


            if (cart.Contents != null)
            {
                string[] items = cart.Contents.Split(',');
                cart.Contents = null;

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        string[] detailSplit = items[i].Split('x');
                        int ID = int.Parse(detailSplit[0]);
                        int quantity = int.Parse(detailSplit[1]);

                        if (ID != pv.ID)
                        {
                            cart.Contents += items[i] + ",";
                        }
                    }
                    catch
                    {
                        //
                    }
                }
            }

            _context.Cart.Attach(cart);
            var entry = _context.Entry(cart);
            entry.Property(e => e.Contents).IsModified = true;
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }


        [HttpPost]
        public ActionResult UpdateQuantity(ProductsViewModel pv)
        {
            Cart cart = new Cart();
            cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);


            if (cart.Contents != null)
            {
                string[] items = cart.Contents.Split(',');
                cart.Contents = null;

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        string[] detailSplit = items[i].Split('x');
                        int ID = int.Parse(detailSplit[0]);
                        int quantity = int.Parse(detailSplit[1]);

                        Product p = new Product();
                        p = _context.Products.First(x => x.ID == ID);

                        if (ID != pv.ID)
                        {
                            cart.Contents += items[i] + ",";
                        }
                        else
                        {
                            if (p.NumberInStock >= pv.quantity)
                            {
                                string updatedItem = ID + "x" + pv.quantity + ",";
                                cart.Contents += updatedItem;
                            }
                            else
                            {
                                cart.Contents += items[i] + ",";
                            }
                        }
                    }
                    catch
                    {
                        //
                    }
                }
            }

            _context.Cart.Attach(cart);
            var entry = _context.Entry(cart);
            entry.Property(e => e.Contents).IsModified = true;
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
    }
}