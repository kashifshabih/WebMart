using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMart.Models
{
    public class Address
    {        
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string City { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string State { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Country { get; set; }
    }
}