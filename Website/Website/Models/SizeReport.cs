using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class SizeReport
    {
        public int TotalQuantitySold { get; set; }
        public int TotalQuantityInStock { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int NumberInStock { get; set; }
    }
}