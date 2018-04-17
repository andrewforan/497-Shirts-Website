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
            cart = _context.Cart.FirstOrDefault(x => x.User == User.Identity.Name);

            Product p = new Product();
            p = _context.Products.FirstOrDefault(x => x.ParentID == pv.ID && x.Size == pv.Size);

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
        public ActionResult EditProduct(ProductsViewModel pv)
        {
            Product p = new Product();
            p = _context.Products.FirstOrDefault(x => x.ID == pv.ID);

            var view = new Product()
            {
                ID = pv.ID,
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
        public ActionResult DeleteProduct(ProductsViewModel pv)
        {
            Product p = new Product();
            p = _context.Products.FirstOrDefault(x => x.ID == pv.ID); //base
            _context.Products.Remove(p);
            _context.SaveChanges();

            p = _context.Products.FirstOrDefault(x => x.ID == (pv.ID + 1)); //small
            _context.Products.Remove(p);
            _context.SaveChanges();

            p = _context.Products.FirstOrDefault(x => x.ID == (pv.ID + 2)); //medium
            _context.Products.Remove(p);
            _context.SaveChanges();

            p = _context.Products.FirstOrDefault(x => x.ID == (pv.ID + 3)); //large
            _context.Products.Remove(p);
            _context.SaveChanges();

            p = _context.Products.FirstOrDefault(x => x.ID == (pv.ID + 4)); //xlarge
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

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == p.ID);
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var baseModel = _context.Entry(updatedProduct);
                baseModel.Property(e => e.Name).IsModified = true;
                baseModel.Property(e => e.Price).IsModified = true;
                baseModel.Property(e => e.ImageLink).IsModified = true;
                baseModel.Property(e => e.Size).IsModified = true;
                baseModel.Property(e => e.CategoryId).IsModified = true;
                baseModel.Property(e => e.NumberInStock).IsModified = true;
                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 1));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var small = _context.Entry(updatedProduct);
                small.Property(e => e.Name).IsModified = true;
                small.Property(e => e.Price).IsModified = true;
                small.Property(e => e.ImageLink).IsModified = true;
                small.Property(e => e.Size).IsModified = true;
                small.Property(e => e.CategoryId).IsModified = true;
                small.Property(e => e.NumberInStock).IsModified = true;
                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 2));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var medium = _context.Entry(updatedProduct);
                medium.Property(e => e.Name).IsModified = true;
                medium.Property(e => e.Price).IsModified = true;
                medium.Property(e => e.ImageLink).IsModified = true;
                medium.Property(e => e.Size).IsModified = true;
                medium.Property(e => e.CategoryId).IsModified = true;
                medium.Property(e => e.NumberInStock).IsModified = true;
                _context.SaveChanges();

                updatedProduct = _context.Products.First(x => x.ID == (p.ID + 3));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var large = _context.Entry(updatedProduct);
                large.Property(e => e.Name).IsModified = true;
                large.Property(e => e.Price).IsModified = true;
                large.Property(e => e.ImageLink).IsModified = true;
                large.Property(e => e.Size).IsModified = true;
                large.Property(e => e.CategoryId).IsModified = true;
                large.Property(e => e.NumberInStock).IsModified = true;
                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 4));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageLink = p.ImageLink;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var xlarge = _context.Entry(updatedProduct);
                xlarge.Property(e => e.Name).IsModified = true;
                xlarge.Property(e => e.Price).IsModified = true;
                xlarge.Property(e => e.ImageLink).IsModified = true;
                xlarge.Property(e => e.Size).IsModified = true;
                xlarge.Property(e => e.CategoryId).IsModified = true;
                xlarge.Property(e => e.NumberInStock).IsModified = true;
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
                    CategoryId = p.CategoryId,
                    NumberInStock = p.NumberInStock,
                };

                return View("NewProduct", view);
            }
            else
            {
                int numberInStock = p.NumberInStock;

                p.NumberInStock = 0;
                p.Size = "Blank";
                p.Viewable = true;
                _context.Products.Add(p);
                _context.SaveChanges();

                int max = _context.Products.Max(x => x.ID);
                p.ParentID = max;

                p.NumberInStock = numberInStock;
                p.Viewable = false;
                p.Size = "Small";
                _context.Products.Add(p);
                _context.SaveChanges();

                p.Size = "Medium";
                _context.Products.Add(p);
                _context.SaveChanges();

                p.Size = "Large";
                _context.Products.Add(p);
                _context.SaveChanges();

                p.Size = "Extra Large";
                _context.Products.Add(p);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public ActionResult Reports()
        {
            return View("Reports");
        }

        [HttpPost]
        public ActionResult ItemRevenueReport()
        {
            var orders = _context.Order.ToList();
            List<Product> itemOrderedList = new List<Product>();

            foreach (var order in orders)
            {
                string[] items = order.ItemsOrdered.Split(',');

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        string[] detailSplit = items[i].Split('x');
                        int ID = int.Parse(detailSplit[0]);
                        int quantity = int.Parse(detailSplit[1]);

                        Product p = new Product();
                        p = _context.Products.FirstOrDefault(x => x.ID == ID);
                        p.NumberInStock = quantity; // number in stock used for quanitity
                        itemOrderedList.Add(p);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            List<Product> combinedItemList = new List<Product>();

            for (int x = 0; x < itemOrderedList.Count(); x++)
            {
                int quantity = 0;

                for (int y = 0; y < itemOrderedList.Count(); y++)
                {
                    if (itemOrderedList[x].ParentID == itemOrderedList[y].ParentID)
                    {
                        quantity += itemOrderedList[y].NumberInStock;
                    }
                }
                Product p = new Product();
                p.ID = itemOrderedList[x].ParentID;
                p.Name = itemOrderedList[x].Name;
                p.Price = itemOrderedList[x].Price;
                p.NumberInStock = quantity;
                combinedItemList.Add(p);
            }

            combinedItemList = combinedItemList.GroupBy(x => x.ID).Select(x => x.FirstOrDefault()).ToList(); //remove duplicates
            combinedItemList = combinedItemList.OrderByDescending(x => x.NumberInStock).ToList(); // sort by highest quantity sold

            var viewModel = new OrdersViewModel
            {
                productsOrdered = combinedItemList,
            };

            return View("ItemRevenueReport", viewModel);
        }

        [HttpPost]
        public ActionResult ItemSizeReport()
        {
            var orders = _context.Order.ToList();
            List<Product> itemOrderedList = new List<Product>();

            foreach (var order in orders)
            {
                string[] items = order.ItemsOrdered.Split(',');

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        string[] detailSplit = items[i].Split('x');
                        int ID = int.Parse(detailSplit[0]);
                        int quantity = int.Parse(detailSplit[1]);

                        Product p = new Product();
                        p = _context.Products.FirstOrDefault(x => x.ID == ID);
                        p.NumberInStock = quantity; // number in stock used for quanitity
                        itemOrderedList.Add(p);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            List<Product> combinedItemList = new List<Product>();

            for (int x = 0; x < itemOrderedList.Count(); x++)
            {
                int quantity = 0;

                for (int y = 0; y < itemOrderedList.Count(); y++)
                {
                    if (itemOrderedList[x].ID == itemOrderedList[y].ID)
                    {
                        quantity += itemOrderedList[y].NumberInStock;
                    }
                }
                Product p = new Product();
                p.ID = itemOrderedList[x].ID;
                p.Name = itemOrderedList[x].Name;
                p.Price = itemOrderedList[x].Price;
                p.Size = itemOrderedList[x].Size;
                p.NumberInStock = quantity;
                combinedItemList.Add(p);
            }

            combinedItemList = combinedItemList.GroupBy(x => x.ID).Select(x => x.FirstOrDefault()).ToList(); //remove duplicates
            combinedItemList = combinedItemList.OrderByDescending(x => x.NumberInStock).ToList(); // sort by highest quantity sold

            var viewModel = new OrdersViewModel
            {
                productsOrdered = combinedItemList,
            };

            return View("ItemSizeReport", viewModel);
        }
    }
}