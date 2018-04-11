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
        public ActionResult SubmitInfo(Customer currentUser)
        {
            if (!ModelState.IsValid)
            {
                var view = new Customer
                {
                    PhoneNumber = currentUser.PhoneNumber,
                    BillName = currentUser.BillName,
                    BillAddress = currentUser.BillAddress,
                    BillCity = currentUser.BillCity,
                    BillState = currentUser.BillState,
                    BillZip = currentUser.BillZip,
                    ShipName = currentUser.ShipName,
                    ShipAddress = currentUser.ShipAddress,
                    ShipCity = currentUser.ShipCity,
                    ShipState = currentUser.ShipState,
                    ShipZip = currentUser.ShipZip,
                    CardNumber = currentUser.CardNumber,
                    CardName = currentUser.CardName,
                    CardExpirartion = currentUser.CardExpirartion,
                    CardCVV = currentUser.CardCVV
                };

                return View("CustomerInfoForm", view);
            }
            else
            {
                currentUser.Email = System.Web.HttpContext.Current.User.Identity.Name;
                _context.Customer.Add(currentUser);

                Cart cart = new Cart();
                cart = _context.Cart.First(x => x.User == System.Web.HttpContext.Current.User.Identity.Name);
                cart.Contents = null;
                _context.Cart.Attach(cart);
                var entry = _context.Entry(cart);
                entry.Property(e => e.Contents).IsModified = true;

                _context.SaveChanges();
            }

            return View("OrderPlaced");
        }
    }
}