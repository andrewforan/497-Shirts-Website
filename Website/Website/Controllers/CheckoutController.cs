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
        // GET: Checkout
        public ViewResult Index()
        {
            return View("CustomerInfoForm");
        }

        [HttpPost]
        public ActionResult SubmitInfo(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var view = new Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                };

                return View("Index", view);
            }
            else
            {
                //if (contact.FileUpload.InputStream.Length > 0)
                //{
                //    byte[] uploadedFileBytes = new byte[contact.FileUpload.InputStream.Length];
                //    contact.FileUpload.InputStream.Read(uploadedFileBytes, 0, uploadedFileBytes.Length);
                //    contact.FileUploadBytes = uploadedFileBytes;
                //}

                //_context.Contacts.Add(contact);
                //TempData["status"] = "Message Successfully Sent";
            }




            return View("CustomerInfoForm");
        }
    }
}