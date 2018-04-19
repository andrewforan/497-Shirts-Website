using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class OrdersViewModel
    {
        public List<Report> productsOrdered { get; set; }
    }
}