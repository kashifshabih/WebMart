using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Web;

namespace WebMart.Models
{
    public class CardLookup
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

        public bool IsValidCard(CreditCard card)
        {
            return (this.Name==card.Name && this.CreditCardNumber==card.CreditCardNumber 
                && this.SecurityCode==card.SecurityCode && this.ValidTill_DateTime==card.ValidTill_DateTime);
        }
    }
}