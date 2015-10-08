using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMart.Models
{
    public class Address
    {        
        public int ID { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}