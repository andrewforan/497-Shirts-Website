using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageLink { get; set; }

        public string Size { get; set; }

        public byte CategoryId { get; set; }

        public int NumberInStock { get; set; }

        public int quantity { get; set; }

        public bool Viewable { get; set; }

        public int ParentID { get; set; }
    }
}