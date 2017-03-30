using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Model;
using ShoppingCart.Repository;

namespace ShoppingCart.Service
{
    public class ProductService : IProductRepository
    {
        public List<Product> InitializeProduct()
        {
            List<Product> products = new List<Product>()
            {
                new Lawnmower()
                {
                    IdGuid = 1,
                    Brand = "Masport",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Masport",
                    Price = 120,
                    Numbers = 5
                },
                new Lawnmower()
                {
                    IdGuid = 2,
                    Brand = "Morrison",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Morrison",
                    Price = 50,
                    Numbers = 6
                },
                new Lawnmower()
                {
                    IdGuid = 3,
                    Brand = "Flymo",
                    FuelEfficiency = "Very Effective",
                    IsVehicle = false,
                    Name = "Lawnmower Flymo",
                    Price = 40,
                    Numbers = 7
                },

                new Computer()
                {
                    IdGuid = 4,
                    Name = "HP ProBook 450",
                    Price = 450,
                    HardDrive = "1TB",
                    Memory = "16Gb",
                    Numbers = 8
                },
                new Computer()
                {
                    IdGuid = 5,
                    HardDrive = "SSD 512Mb",
                    Memory = "16Gb",
                    Name = "Macbook Pro",
                    Price = 3440,
                    Numbers = 9
                }
            };
            return products;
        }
    }
}
