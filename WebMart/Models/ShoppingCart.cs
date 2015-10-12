using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebMart.Models
{
    public class ShoppingCart
    {
        [Key, ForeignKey("EndUser")]
        public int ID { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual EndUser EndUser { get; set; }

        public double ComputePrice()
        {
            double total = 0;
            foreach (OrderLine ol in this.OrderLines)
            {
                total+=(ol.Quantity*ol.Product.Price);
            }
            return total;
        }
    }
}