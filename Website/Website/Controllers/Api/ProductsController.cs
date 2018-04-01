using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;
using Website.Dtos;
using Website.Models;

namespace Website.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        /*// GET /api/products
        public IHttpActionResult GetProducts(string query = null)
        {
            var productsQuery = _context.Products
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                productsQuery = productsQuery.Where(c => c.Name.Contains(query));

            var productsDtos = productsQuery
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productsDtos);
        }*/
    }
}
