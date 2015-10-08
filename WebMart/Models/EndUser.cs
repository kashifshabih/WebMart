using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    public class EndUser : User
    {
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}