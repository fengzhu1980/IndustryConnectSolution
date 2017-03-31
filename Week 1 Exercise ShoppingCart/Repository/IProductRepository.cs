using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_1_Exercise_ShoppingCart.Model;

namespace Week_1_Exercise_ShoppingCart.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Initialize products
        /// </summary>
        /// <returns>List</returns>
        List<Product> InitializeProduct();
    }
}
