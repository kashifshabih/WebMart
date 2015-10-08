using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMart.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual EndUser EndUser { get; set; }
    }
}