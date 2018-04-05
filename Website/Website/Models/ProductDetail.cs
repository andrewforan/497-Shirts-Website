using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ProductDetail
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string Size { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}