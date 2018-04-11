using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext _context;

        public CheckoutController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult OrderPlaced()
        {
            return View("OrderPlaced");
        }

        // GET: Checkout
        public ViewResult Index()
        {
            return View("CustomerInfoForm");
        }

        [HttpPost]
        public ActionResult SubmitInfo(Order currentOrder)
        {
            if (!ModelState.IsValid)
            {
                var view = new Order
                {
                    PhoneNumber = currentOrder.PhoneNumber,
                    BillName = currentOrder.BillName,
                    BillAddress = currentOrder.BillAddress,
                    BillCity = currentOrder.BillCity,
                    BillState = currentOrder.BillState,
                    BillZip = currentOrder.BillZip,
                    ShipName = currentOrder.ShipName,
                    ShipAddress = currentOrder.ShipAddress,
                    ShipCity = currentOrder.ShipCity,
                    ShipState = currentOrder.ShipState,
                    ShipZip = currentOrder.ShipZip,
                    CardNumber = currentOrder.CardNumber,
                    CardName = currentOrder.CardName,
                    CardExpirartion = currentOrder.CardExpirartion,
                    CardCVV = currentOrder.CardCVV
                };

                return View("CustomerInfoForm", view);
            }
            else
            {
                Cart cart = new Cart();
                cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);

                currentOrder.Email = System.Web.HttpContext.Current.User.Identity.Name;
                currentOrder.ItemsOrdered = cart.Contents;
                currentOrder.OrderTime = DateTime.Now;
                _context.Order.Add(currentOrder);

                cart.Contents = null;
                _context.Cart.Attach(cart);
                var entry = _context.Entry(cart);
                entry.Property(e => e.Contents).IsModified = true;

                string[] items = currentOrder.ItemsOrdered.Split(',');
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
                        p.NumberInStock = p.NumberInStock - quantity;

                        _context.Products.Attach(p);
                        var entryP = _context.Entry(p);
                        entryP.Property(e => e.NumberInStock).IsModified = true;
                    }
                    catch
                    {
                        //
                    }
                }

                _context.SaveChanges();
            }

            return View("OrderPlaced");
        }
    }
}