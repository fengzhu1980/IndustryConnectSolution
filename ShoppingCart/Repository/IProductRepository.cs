using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Model;

namespace ShoppingCart.Repository
{
    public interface IProductRepository
    {
        List<Product> InitializeProduct();
    }
}
