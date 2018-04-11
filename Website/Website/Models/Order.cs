using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string ItemsOrdered { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(255)]
        public string BillName { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(255)]
        public string BillAddress { get; set; }

        [Display(Name = "City")]
        [Required]
        [StringLength(255)]
        public string BillCity { get; set; }

        [Display(Name = "State")]
        [Required]
        [StringLength(255)]
        public string BillState { get; set; }


        [Display(Name = "Zip Code")]
        [Required]
        [StringLength(255)]
        public string BillZip { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(255)]
        public string ShipName { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(255)]
        public string ShipAddress { get; set; }

        [Display(Name = "City")]
        [Required]
        [StringLength(255)]
        public string ShipCity { get; set; }

        [Display(Name = "State")]
        [Required]
        [StringLength(255)]
        public string ShipState { get; set; }

        [Display(Name = "Zip")]
        [Required]
        [StringLength(255)]
        public string ShipZip { get; set; }

        [Display(Name = "Card Number")]
        [Required]
        [StringLength(255)]
        public string CardNumber { get; set; }

        [Display(Name = "Name on Card")]
        [Required]
        [StringLength(255)]
        public string CardName { get; set; }

        [Display(Name = "Expiration Date")]
        [Required]
        [StringLength(255)]
        public string CardExpirartion { get; set; }

        [Display(Name = "CVV")]
        [Required]
        [StringLength(255)]
        public string CardCVV { get; set; }

        public DateTime OrderTime { get; set; }
    }
}