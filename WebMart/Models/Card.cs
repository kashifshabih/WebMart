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
        public BigInteger CreditCardNumber { get; set; }
        [Required]
        public int SecurityCode { get; set; }
        [Required]
        public DateTime ValidTill_DateTime { get; set; }

        public virtual User User { get; set; }
    }
}