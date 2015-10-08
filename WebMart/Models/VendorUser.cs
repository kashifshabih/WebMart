using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    public class VendorUser : User
    {
        public virtual Vendor Vendor { get; set; }
    }
}