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

            if (p.NumberInStock >= pv.quantity && pv.quantity > 0)
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
                ImageUploadBytes = p.ImageUploadBytes,
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
        public ActionResult SaveEditedProduct(Product p, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                var view = new Product()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    NumberInStock = p.NumberInStock,
                };

                return View("EditProduct", view);
            }
            else
            {
                if (image != null)
                {
                    p.ImageMimeType = image.ContentType;
                    p.ImageUploadBytes = new byte[image.ContentLength];
                    image.InputStream.Read(p.ImageUploadBytes, 0, image.ContentLength);
                }

                Product updatedProduct = new Product();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == p.ID);
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageUploadBytes = p.ImageUploadBytes;
                updatedProduct.ImageMimeType = p.ImageMimeType;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = 0;
                _context.Products.Attach(updatedProduct);
                var baseModel = _context.Entry(updatedProduct);
                baseModel.Property(e => e.Name).IsModified = true;
                baseModel.Property(e => e.Price).IsModified = true;

                if (image != null)
                {
                    baseModel.Property(e => e.ImageUploadBytes).IsModified = true;
                    baseModel.Property(e => e.ImageMimeType).IsModified = true;
                }

                baseModel.Property(e => e.CategoryId).IsModified = true;
                baseModel.Property(e => e.NumberInStock).IsModified = true;
                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 1));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageUploadBytes = p.ImageUploadBytes;
                updatedProduct.ImageMimeType = p.ImageMimeType;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var small = _context.Entry(updatedProduct);
                small.Property(e => e.Name).IsModified = true;
                small.Property(e => e.Price).IsModified = true;

                if (image != null)
                {
                    small.Property(e => e.ImageUploadBytes).IsModified = true;
                    small.Property(e => e.ImageMimeType).IsModified = true;
                }

                small.Property(e => e.CategoryId).IsModified = true;

                if (p.NumberInStock != 0)
                {
                    small.Property(e => e.NumberInStock).IsModified = true;
                }

                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 2));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageUploadBytes = p.ImageUploadBytes;
                updatedProduct.ImageMimeType = p.ImageMimeType;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var medium = _context.Entry(updatedProduct);
                medium.Property(e => e.Name).IsModified = true;
                medium.Property(e => e.Price).IsModified = true;

                if (image != null)
                {
                    medium.Property(e => e.ImageUploadBytes).IsModified = true;
                    medium.Property(e => e.ImageMimeType).IsModified = true;
                }

                medium.Property(e => e.CategoryId).IsModified = true;

                if (p.NumberInStock != 0)
                {
                    medium.Property(e => e.NumberInStock).IsModified = true;
                }

                _context.SaveChanges();

                updatedProduct = _context.Products.First(x => x.ID == (p.ID + 3));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageUploadBytes = p.ImageUploadBytes;
                updatedProduct.ImageMimeType = p.ImageMimeType;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var large = _context.Entry(updatedProduct);
                large.Property(e => e.Name).IsModified = true;
                large.Property(e => e.Price).IsModified = true;

                if (image != null)
                {
                    large.Property(e => e.ImageUploadBytes).IsModified = true;
                    large.Property(e => e.ImageMimeType).IsModified = true;
                }

                large.Property(e => e.CategoryId).IsModified = true;

                if (p.NumberInStock != 0)
                {
                    large.Property(e => e.NumberInStock).IsModified = true;
                }

                _context.SaveChanges();

                updatedProduct = _context.Products.FirstOrDefault(x => x.ID == (p.ID + 4));
                updatedProduct.Name = p.Name;
                updatedProduct.Price = p.Price;
                updatedProduct.ImageUploadBytes = p.ImageUploadBytes;
                updatedProduct.ImageMimeType = p.ImageMimeType;
                updatedProduct.Size = p.Size;
                updatedProduct.CategoryId = p.CategoryId;
                updatedProduct.NumberInStock = p.NumberInStock;
                _context.Products.Attach(updatedProduct);
                var xlarge = _context.Entry(updatedProduct);
                xlarge.Property(e => e.Name).IsModified = true;
                xlarge.Property(e => e.Price).IsModified = true;

                if (image != null)
                {
                    xlarge.Property(e => e.ImageUploadBytes).IsModified = true;
                    xlarge.Property(e => e.ImageMimeType).IsModified = true;
                }

                xlarge.Property(e => e.CategoryId).IsModified = true;

                if (p.NumberInStock != 0)
                {
                    xlarge.Property(e => e.NumberInStock).IsModified = true;
                }

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
        public ActionResult AddNewProduct(Product p, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                var view = new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    NumberInStock = p.NumberInStock,
                };

                return View("NewProduct", view);
            }
            else
            {
                if (image != null)
                {
                    p.ImageMimeType = image.ContentType;
                    p.ImageUploadBytes = new byte[image.ContentLength];
                    image.InputStream.Read(p.ImageUploadBytes, 0, image.ContentLength);
                }

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
            List<Report> itemOrderedList = new List<Report>();
            List<Report> combinedItemList = new List<Report>();

            if (orders.Count() > 0)
            {
                for (int x = 0; x < orders.Count(); x++)
                {
                    string[] items = orders[x].ItemsOrdered.Split(',');

                    for (int i = 0; i < items.Count(); i++)
                    {
                        try
                        {
                            string[] detailSplit = items[i].Split('x');
                            int ID = int.Parse(detailSplit[0]);
                            int quantity = int.Parse(detailSplit[1]);

                            Product p = new Product();
                            p = _context.Products.FirstOrDefault(c => c.ID == ID);

                            Report r = new Report();
                            r.ID = p.ParentID;
                            r.ItemName = p.Name;
                            r.Price = p.Price;
                            r.Quantity = quantity;
                            itemOrderedList.Add(r);
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                for (int x = 0; x < itemOrderedList.Count(); x++)
                {
                    int quantity = 0;

                    for (int y = 0; y < itemOrderedList.Count(); y++)
                    {
                        if (itemOrderedList[x].ID == itemOrderedList[y].ID)
                        {
                            quantity += itemOrderedList[y].Quantity;
                        }
                    }
                    Report item = new Report();
                    item.ID = itemOrderedList[x].ID;
                    item.ItemName = itemOrderedList[x].ItemName;
                    item.Price = itemOrderedList[x].Price;
                    item.Quantity = quantity;
                    combinedItemList.Add(item);
                }

                combinedItemList = combinedItemList.GroupBy(x => x.ID).Select(x => x.FirstOrDefault()).ToList(); //remove duplicates
                combinedItemList = combinedItemList.OrderByDescending(x => x.NumberInStock).ToList(); // sort by highest quantity sold
            }

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
            List<Report> itemList = new List<Report>();
            List<Report> sizeDetails = new List<Report>();

            if (orders.Count() > 0)
            {
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

                            Report s = new Report();
                            s.Size = p.Size;
                            s.Quantity = quantity;
                            s.NumberInStock = p.NumberInStock;
                            itemList.Add(s);
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                int numOrderedSmall = 0;
                int totalStockSmall = 0;
                int numOrderedMedium = 0;
                int totalStockMedium = 0;
                int numOrderedLarge = 0;
                int totalStockLarge = 0;
                int numOrderedXLarge = 0;
                int totalStockXLarge = 0;


                foreach (var item in itemList)
                {
                    switch (item.Size)
                    {
                        case "Small":
                            numOrderedSmall += item.Quantity; //Stock ordered
                            break;
                        case "Medium":
                            numOrderedMedium += item.Quantity; //Stock ordered
                            break;
                        case "Large":
                            numOrderedLarge += item.Quantity; //Stock ordered
                            break;
                        case "Extra Large":
                            numOrderedXLarge += item.Quantity; //Stock ordered
                            break;
                    }
                }

                Report smallDetails = new Report();
                smallDetails.Size = "Small";
                smallDetails.TotalQuantitySold = numOrderedSmall;

                Report mediumDetails = new Report();
                mediumDetails.Size = "Medium";
                mediumDetails.TotalQuantitySold = numOrderedMedium;

                Report largeDetails = new Report();
                largeDetails.Size = "Large";
                largeDetails.TotalQuantitySold = numOrderedLarge;

                Report xlargeDetails = new Report();
                xlargeDetails.Size = "Extra Large";
                xlargeDetails.TotalQuantitySold = numOrderedXLarge;

                var products = _context.Products.ToList();

                foreach (var product in products)
                {
                    switch (product.Size)
                    {
                        case "Small":
                            totalStockSmall += product.NumberInStock;
                            break;
                        case "Medium":
                            totalStockMedium += product.NumberInStock;
                            break;
                        case "Large":
                            totalStockLarge += product.NumberInStock;
                            break;
                        case "Extra Large":
                            totalStockXLarge += product.NumberInStock;
                            break;
                    }
                }
                smallDetails.TotalQuantityInStock = totalStockSmall;
                mediumDetails.TotalQuantityInStock = totalStockMedium;
                largeDetails.TotalQuantityInStock = totalStockLarge;
                xlargeDetails.TotalQuantityInStock = totalStockXLarge;

                sizeDetails.Add(smallDetails);
                sizeDetails.Add(mediumDetails);
                sizeDetails.Add(largeDetails);
                sizeDetails.Add(xlargeDetails);
            }


            var viewModel = new ReportViewModel
            {
                ReportList = sizeDetails,
            };

            return View("ItemSizeReport", viewModel);
        }

        [HttpPost]
        public ActionResult YearlyRevenueReport()
        {
            var orders = _context.Order.ToList();
            List<Report> yearRevList = new List<Report>();
            
            if (orders.Count() > 0)
            {
                int currentYear = 0;
                int previousYear = 0;
                decimal totalRev = 0;

                for (int x = 0; x < orders.Count(); x++)
                {
                    currentYear = orders[x].OrderTime.Year;

                    if (x != 0 && orders[x].OrderTime.Year != previousYear)
                    {
                        Report s = new Report();
                        s.Year = previousYear;
                        s.TotalRevenue = totalRev;
                        yearRevList.Add(s);
                        totalRev = 0;
                    }

                    string[] items = orders[x].ItemsOrdered.Split(',');

                    for (int i = 0; i < items.Count(); i++)
                    {
                        try
                        {
                            string[] detailSplit = items[i].Split('x');
                            int ID = int.Parse(detailSplit[0]);
                            int quantity = int.Parse(detailSplit[1]);

                            Product p = new Product();
                            p = _context.Products.FirstOrDefault(c => c.ID == ID);
                            totalRev += (p.Price * quantity);
                        }
                        catch
                        {
                            //
                        }
                    }
                    previousYear = orders[x].OrderTime.Year;

                    if (orders.Count() == (x + 1))
                    {
                        Report s = new Report();
                        s.Year = currentYear;
                        s.TotalRevenue = totalRev;
                        yearRevList.Add(s);
                    }
                }
            }

            var viewModel = new ReportViewModel
            {
                ReportList = yearRevList,
            };

            return View("YearlyRevenueReport", viewModel);
        }

        [HttpPost]
        public ActionResult CategoryRevenueReport()
        {
            var orders = _context.Order.ToList();
            List<Report> itemList = new List<Report>();
            List<Report> categoryList = new List<Report>();

            if (orders.Count() > 0)
            {
                for (int x = 0; x < orders.Count(); x++)
                {
                    string[] items = orders[x].ItemsOrdered.Split(',');

                    for (int i = 0; i < items.Count(); i++)
                    {
                        try
                        {
                            string[] detailSplit = items[i].Split('x');
                            int ID = int.Parse(detailSplit[0]);
                            int quantity = int.Parse(detailSplit[1]);

                            Product p = new Product();
                            p = _context.Products.FirstOrDefault(c => c.ID == ID);

                            Report r = new Report();
                            r.ID = p.ParentID;
                            r.ItemName = p.Name;
                            r.Price = p.Price;
                            r.Quantity = quantity;
                            r.CategoryId = p.CategoryId;
                            itemList.Add(r);
                        }
                        catch
                        {
                            //
                        }
                    }
                }


                List<Report> combinedItemList = new List<Report>();

                for (int x = 0; x < itemList.Count(); x++)
                {
                    int quantity = 0;

                    for (int y = 0; y < itemList.Count(); y++)
                    {
                        if (itemList[x].ID == itemList[y].ID)
                        {
                            quantity += itemList[y].Quantity;
                        }
                    }
                    Report item = new Report();
                    item.ID = itemList[x].ID;
                    item.ItemName = itemList[x].ItemName;
                    item.Price = itemList[x].Price;
                    item.Quantity = quantity;
                    item.CategoryId = itemList[x].CategoryId;
                    combinedItemList.Add(item);
                }

                combinedItemList = combinedItemList.GroupBy(x => x.ID).Select(x => x.FirstOrDefault()).ToList(); //remove duplicates
                combinedItemList = combinedItemList.OrderBy(x => x.CategoryId).ToList(); // sort by category ID

                int categoryIDCount = 0;
                int categoryItemCount = 0;
                int avgCount = 0;
                decimal totalRevenue = 0;

                for (int i = 0; i < combinedItemList.Count(); i++)
                {
                    Report r = new Report();

                    if (combinedItemList[i].CategoryId == categoryIDCount)
                    {
                        avgCount += combinedItemList[i].Quantity;
                        totalRevenue += (combinedItemList[i].Price * combinedItemList[i].Quantity);
                        categoryItemCount++;

                        if (combinedItemList.Count() == (i + 1))
                        {
                            r.ID = combinedItemList[i].ID;
                            r.CategoryId = combinedItemList[i].CategoryId;
                            r.Quantity = avgCount;
                            r.TotalRevenue = totalRevenue;
                            r.AvgRevenue = Math.Round((totalRevenue / avgCount), 2);
                            categoryList.Add(r);
                        }
                    }
                    else
                    {
                        try
                        {
                            r.ID = combinedItemList[i - 1].ID;
                            r.CategoryId = combinedItemList[i - 1].CategoryId;
                        }
                        catch
                        {
                            r.ID = combinedItemList[i].ID;
                            r.CategoryId = combinedItemList[i].CategoryId;
                        }

                        r.Quantity = avgCount;
                        r.TotalRevenue = totalRevenue;
                        r.AvgRevenue = Math.Round((totalRevenue / avgCount), 2);
                        categoryList.Add(r);

                        categoryIDCount++;
                        categoryItemCount = 0;
                        avgCount = 0;
                        totalRevenue = 0;
                        i--;
                    }
                }

                categoryList = categoryList.OrderByDescending(x => x.AvgRevenue).ToList(); // sort by highest avg revenue
            }

            var viewModel = new ReportViewModel
            {
                ReportList = categoryList,
            };

            return View("CategoryRevenueReport", viewModel);
        }

        //[HttpPost]
        //public ActionResult AddImage(Product model, HttpPostedFileBase image)
        //{
        //    model.Name = "ImageFill";
        //    model.Price = 1;
        //    model.Size = "test";
        //    model.CategoryId = 1;
        //    model.NumberInStock = 0;
        //    model.Viewable = false;
        //    model.ParentID = 0;

        //    if (image != null)
        //    {
        //        model.ImageMimeType = image.ContentType;
        //        model.ImageUploadBytes = new byte[image.ContentLength];
        //        image.InputStream.Read(model.ImageUploadBytes, 0, image.ContentLength);
        //    }
        //    _context.Products.Add(model);
        //    _context.SaveChanges();


        //    return View(model);
        //}

        [AllowAnonymous]
        public FileContentResult GetImage(int id)
        {
            Product p = new Product();
            p = _context.Products.FirstOrDefault(x => x.ID == id);

            if (p.ImageUploadBytes != null)
            {
                return File(p.ImageUploadBytes, p.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}