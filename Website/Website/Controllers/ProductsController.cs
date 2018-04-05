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
                return View("List");

            return View("ReadOnlyList", viewModel);
        }
    }
}