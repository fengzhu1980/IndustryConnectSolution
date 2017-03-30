using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Cart:Product
    {
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
