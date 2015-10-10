using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    public class TestOrder
    {
        public int Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardPin { get; set; }
    }
}