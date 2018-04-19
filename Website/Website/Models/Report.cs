using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Report
    {
        public int TotalQuantitySold { get; set; }
        public int TotalQuantityInStock { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int NumberInStock { get; set; }
        public int Year { get; set; }
        public decimal TotalRevenue { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }
    }
}