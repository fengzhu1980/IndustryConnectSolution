using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_1_Exercise_ShoppingCart.Model;
using Week_1_Exercise_ShoppingCart.Repository;

namespace Week_1_Exercise_ShoppingCart.Service
{
    public class ProductService : IProductRepository
    {
        public List<Product> InitializeProduct()
        {
            List<Product> products = new List<Product>()
            {
                new Car
                {
                    Id =1,
                    Name = "Civici",
                    Color = "White",
                    Model = "Honda",
                    Year = "2002",
                    Price = 20000,
                    Numbers = 10
                },
                new Furniture
                {
                    Id = 2,
                    Name = "Bed",
                    Material = "Iron",
                    Price = 500,
                    Numbers = 10
                },
                new SportsEquipment
                {
                    Id = 3,
                    Name = "Hat",
                    UsedFor = "Block sunlight",
                    Price = 20,
                    Numbers = 50
                }
            };
            return products;
        }
    }
}
