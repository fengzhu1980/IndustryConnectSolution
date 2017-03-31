using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Exercise_ShoppingCart.Model
{
    public class ShoppingCart:Product
    {
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
