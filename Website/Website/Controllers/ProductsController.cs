using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var products = _context.Products.ToList();

            var viewModel = new ProductsViewModel
            {
                Products = products,
            };

            if (User.IsInRole(RoleName.Admin))
                return View("List", viewModel);

            return View("ReadOnlyList", viewModel);
        }



        [HttpPost]
        public ActionResult AddProduct(ProductsViewModel pv) // to cart
        {
            Cart cart = new Cart();
            cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);

            Product p = new Product();
            p = _context.Products.First(x => x.ParentID == pv.ID && x.Size == pv.Size);

            string currItem = (p.ID + "x" + pv.quantity + ",");

            if (p.NumberInStock >= pv.quantity)
            {
                try
                {
                    if (cart.Contents != null)
                    {
                        string[] items = cart.Contents.Split(',');
                        bool reconstructed = false;
                        bool added = false;

                        for (int i = 0; i < items.Count(); i++)
                        {
                            try
                            {
                                string[] detailSplit = items[i].Split('x');
                                int ID = int.Parse(detailSplit[0]);
                                int quantity = int.Parse(detailSplit[1]);

                                if (p.ID == ID)
                                {
                                    cart.Contents = null;
                                    items[i] = (p.ID + "x" + (pv.quantity + quantity));

                                    for (int x = 0; x < items.Count() - 1; x++)
                                    {
                                        cart.Contents += items[x] + ",";
                                    }
                                    reconstructed = true;
                                }
                                else
                                {
                                    if (reconstructed == false && added == false)
                                    {
                                        cart.Contents += currItem;
                                        added = true;
                                    }
                                }
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                    else
                    {
                        cart.Contents += currItem;
                    }
                }
                catch
                {
                    //
                }
            }
            else
            {
                return RedirectToAction("Index", "Products");
            }

            _context.Cart.Attach(cart);
            var entry = _context.Entry(cart);
            entry.Property(e => e.Contents).IsModified = true;
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public ActionResult EditProduct(int id)
        {
            Product p = new Product();
            p = _context.Products.First(x => x.ID == id);

            var view = new Product()
            {
                ID = id,
                Name = p.Name,
                Price = p.Price,
                ImageLink = p.ImageLink,
                Size = p.Size,
                CategoryId = p.CategoryId,
                NumberInStock = p.NumberInStock,
            };

            return View("EditProduct", view);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            Product p = new Product();
            p = _context.Products.First(x => x.ID == id);
            _context.Products.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public ActionResult SaveEditedProduct(Product p)
        {
            if (!ModelState.IsValid)
            {
                var view = new Product()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    ImageLink = p.ImageLink,
                    Size = p.Size,
                    CategoryId = p.CategoryId,
                    NumberInStock = p.NumberInStock,
                };

                return View("EditProduct", view);
            }
            else
            {
                Product updatedProduct = new Product();
                updatedProduct = _context.Products.First(x => x.ID == p.ID);

                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;

                _context.Products.Attach(updatedProduct);
                var entry = _context.Entry(updatedProduct);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Price).IsModified = true;
                entry.Property(e => e.ImageLink).IsModified = true;
                entry.Property(e => e.Size).IsModified = true;
                entry.Property(e => e.CategoryId).IsModified = true;
                entry.Property(e => e.NumberInStock).IsModified = true;

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public ActionResult NewProduct()
        {
            return View("NewProduct");
        }

        [HttpPost]
        public ActionResult AddNewProduct(Product p)
        {
            if (!ModelState.IsValid)
            {
                var view = new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    ImageLink = p.ImageLink,
                    Size = p.Size,
                    CategoryId = p.CategoryId,
                    NumberInStock = p.NumberInStock,
                };

                return View("NewProduct", view);
            }
            else
            {
                _context.Products.Add(p);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }
    }
}