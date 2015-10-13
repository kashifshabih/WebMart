using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WebMart.Models
{
    public class Card
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        public BigInteger CreditCardNumber { get; set; }
        [Required]
        [Display(Name = "Security Code")]
        public int SecurityCode { get; set; }
        [Required]
        [Display(Name = "Expiry Date")]
        public DateTime ValidTill_DateTime { get; set; }

        public virtual User User { get; set; }
    }
}