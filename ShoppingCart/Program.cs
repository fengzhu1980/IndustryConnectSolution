using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Service;
using ShoppingCart.Model;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of all products in system
            //Product number: 1
            //Product name: Lawnmower Masport
            //Product price: 120
            //----------------------
            //Product number: 2
            //Product name: Lawnmower Morrison
            //Product price: 50
            //----------------------
            //Product number: 3
            //Product name: Lawnmower Flymo
            //Product price: 40
            //----------------------
            //Product number: 4
            //Product name: HP ProBook 450
            //Product price: 450
            //----------------------
            //Product number: 5
            //Product name: Macbook Pro
            //Product price: 3440
            //----------------------
            //Please enter product number you want to purchase
            //1
            //Product number: 1
            //Product name: Lawnmower Masport
            //Product price: 120
            //Product brand: Masport
            //Product fuel efficiency: Very Effective
            //----------------------
            //Please enter your quantity you want to purchase
            //10
            //You has 1 product in your cart
            //Would you like to add more product to your cart. Press Y to continue or N to Checkout
            //Y
            //Please enter product number you want to purchase
            //2
            //Product number: 2
            //Product name: Lawnmower Morrison
            //Product price: 50
            //Product brand: Morrison
            //Product fuel efficiency: Very Effective
            //----------------------
            //Please enter your quantity you want to purchase
            //5
            //You has 2 product in your cart
            //Would you like to add more product to your cart. Press Y to continue or N to Checkout
            //N
            //-------------------- -
            //Product number: 1
            //Name: Lawnmower Masport x 10
            //Price: $120 x 10 = $1200
            //-------------------- -
            //---------------------
            //Product number: 2
            //Name: Lawnmower Morrison x 5
            //Price: $50 x 5 = $250
            //-------------------- -
            //Total to pay: $1450
            //Thank you for shopping with us.Bye bye
            //Initialize products
            List<Product> products = InitializeProducts();


            Console.WriteLine("Welcome to our shop.");
            //Show products list
            foreach (var product in products)
            {
                Console.WriteLine("Product number: " + product.IdGuid);
                Console.WriteLine("Product name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("==========================");
            }

            //Select product and get it
            Console.WriteLine("Please enter product number you want to purchase:");
            string strSelected = Console.ReadLine();

            int idSelected = int.Parse(strSelected);//need judge is number or not

            if (!(GetProductById(idSelected) == null))
            {
                //get product object
                Product p = GetProductById(idSelected);

                //Show selected prodcut details by product id
                ShowProductDetails
                var type = p.GetType();

                switch (type.Name)
                {
                    case "Computer":
                        Computer c = (Computer)p;
                        Console.WriteLine("We found {0} items in our system.", c.Numbers);
                        Console.WriteLine("Product id: " + c.IdGuid);
                        Console.WriteLine("Product name: " + c.Name);
                        Console.WriteLine("Product Price: " + c.Price);
                        Console.WriteLine("Product memory: " + c.Memory);
                        Console.WriteLine("Product hardDrive" + c.HardDrive);
                        Console.WriteLine("--------------------------");
                        break;
                    case "Lawnmower":
                        Lawnmower l = (Lawnmower)p;
                        Console.WriteLine("We found {0} items in our system.", l.Numbers);
                        Console.WriteLine("Product id: " + l.IdGuid);
                        Console.WriteLine("Product name: " + l.Name);
                        Console.WriteLine("Product Price: " + l.Price);
                        Console.WriteLine("Product memory: " + l.Brand);
                        Console.WriteLine("Product hardDrive" + l.FuelEfficiency);
                        Console.WriteLine("--------------------------");
                        break;
                    default:
                        break;
                }

                //Please enter your quantity you want to purchase
                Console.WriteLine("Please enter your quantity you want to purchase");
                string strPurchase = Console.ReadLine();

                int numPurchase = int.Parse(strPurchase);
                while (numPurchase > p.Numbers || numPurchase <= 0)
                {
                    Console.WriteLine("Please input a correct number");
                    Console.WriteLine("Please enter your quantity you want to purchase");
                    numPurchase = int.Parse(Console.ReadLine());
                }


                //Create product object
                Cart sc = new Cart();
                //Add into shopping cart
                sc = AddProductIntoCart(p, numPurchase);
                List<Cart> cartList = new List<Cart>();
                cartList.Add(sc);
                Console.WriteLine("You has {0} product in your cart",cartList.Count);

                //Would you like to add more product to your cart. Press Y to continue or N to Checkout
                //Please enter product number you want to purchase


                Console.WriteLine("Would you like to add more product to your cart. Press Y to continue or N to Checkout");

                //Judge if input is Y or not
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    //string strInput = 
                }
                else
                {
                    //show shopping cart
                    ShowShoppingCart(cartList);
                    Console.WriteLine("Thank you for shopping with us.Bye bye");
                }
            }
            else
            {
                Console.WriteLine("We found 0 item in our system.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Show the items list of shopping cart
        /// </summary>
        /// <param name="cartList"></param>
        private static void ShowShoppingCart(List<Cart> cartList)
        {
            foreach (var item in cartList)
            {
                Console.WriteLine("Shopping cart list:");
                Console.WriteLine("Product id: " + item.IdGuid);
                Console.WriteLine("Product name: " + item.Name);
                Console.WriteLine("Product price: " + item.Price);
                Console.WriteLine("Purchase quantity: " + item.Quantity);
                Console.WriteLine("Total cost: " + item.TotalCost);
            }
        }

        /// <summary>
        /// Add selected product and purchased numbers into shopping cart
        /// </summary>
        /// <param name="p">Product type object</param>
        /// <param name="numPurchase">purchase numbers</param>
        private static Cart AddProductIntoCart(Product p, int numPurchase)
        {
            Cart c = new Cart();
            c.IdGuid = p.IdGuid;
            c.Name = p.Name;
            c.Price = p.Price;
            c.Quantity = numPurchase;
            c.TotalCost = p.Price * numPurchase;
            return c;
        }

        /// <summary>
        /// Initialize products
        /// </summary>
        /// <returns></returns>
        private static List<Product> InitializeProducts()
        {
            ProductService productService = new ProductService();
            List<Product> products = productService.InitializeProduct();
            return products;
        }

        /// <summary>
        /// Get product by product id
        /// </summary>
        /// <param name="idSelected"></param>
        /// <returns></returns>
        private static Product GetProductById(int idSelected)
        {
            //Initialize products
            var products = InitializeProducts();
            foreach (var product in products)
            {
                if (product.IdGuid == idSelected)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
