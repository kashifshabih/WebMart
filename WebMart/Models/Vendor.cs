using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    public class Vendor : User
    {
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorUser> VendorUsers { get; set; }
    }
}