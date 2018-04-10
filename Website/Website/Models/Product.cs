using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageLink { get; set; }

        [StringLength(255)]
        public string Size { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public bool Viewable { get; set; }

        public int ParentID { get; set; }
    }
}