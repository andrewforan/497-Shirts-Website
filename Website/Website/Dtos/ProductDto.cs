using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }

        public byte GroupId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Size { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public string ImageLink { get; set; }
    }
}