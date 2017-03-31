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
            //Initialize products
            List<Product> products = InitializeProducts();
            //Initialize Cart list
            List<Cart> cartList = new List<Cart>();

            Console.WriteLine("Welcome to our shop.");
            //Show products list
            foreach (var product in products)
            {
                Console.WriteLine("Product number: " + product.IdGuid);
                Console.WriteLine("Product name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("==========================");
            }

            //Input product number and purchase
            string strYesOrNo = InputProductNumberLoop(cartList);

            #region purchase
            ////input product number and get it
            //Console.WriteLine("Please enter product number you want to purchase:");
            //string strSelected = Console.ReadLine();

            //int idSelected = int.Parse(strSelected);//need judge is number or not

            ////get product object
            //Product p = GetProductById(idSelected);

            ////Show selected prodcut details by product
            //ShowProductDetailsByProduct(p);


            ////Please enter your quantity you want to purchase
            //Console.WriteLine("Please enter your quantity you want to purchase");
            //string strPurchase = Console.ReadLine();

            //int numPurchase = int.Parse(strPurchase);
            //while (numPurchase > p.Numbers || numPurchase <= 0)
            //{
            //    Console.WriteLine("Please input a correct number");
            //    Console.WriteLine("Please enter your quantity you want to purchase");
            //    numPurchase = int.Parse(Console.ReadLine());
            //}


            ////Create product object
            //Cart sc = new Cart();
            ////Add into shopping cart
            //sc = AddProductIntoCart(p, numPurchase);
            //List<Cart> cartList = new List<Cart>();
            //cartList.Add(sc);
            //Console.WriteLine("You has {0} product in your cart", cartList.Count);

            ////Would you like to add more product to your cart. Press Y to continue or N to Checkout
            ////Please enter product number you want to purchase


            //Console.WriteLine("Would you like to add more product to your cart. Press Y to continue or N to Checkout");
            #endregion
            while (strYesOrNo.ToLower().Equals("y"))
            {
                strYesOrNo = InputProductNumberLoop(cartList);
            }

            //show shopping cart
            Console.WriteLine("Shopping cart list:");
            ShowShoppingCart(cartList);

            Console.WriteLine("Thank you for shopping with us.Bye bye");

            Console.ReadKey();
        }

        private static string InputProductNumberLoop(List<Cart> cartList)
        {
            //input product number and get it
            Console.WriteLine("Please enter product number you want to purchase:");
            string strSelected = Console.ReadLine();

            int idSelected = int.Parse(strSelected);//need judge is number or not

            //get product object
            Product p = GetProductById(idSelected);

            //Show selected prodcut details by product
            ShowProductDetailsByProduct(p);

            //Please enter your quantity you want to purchase
            Console.WriteLine("Please enter quantity you want to purchase");
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
            //List<Cart> cartList = new List<Cart>();
            cartList.Add(sc);
            Console.WriteLine("You has {0} product in your cart", cartList.Count);

            //Would you like to add more product to your cart. Press Y to continue or N to Checkout
            //Please enter product number you want to purchase

            Console.WriteLine("Would you like to add more product to your cart. Press Y to continue or N to Checkout");
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Show selected prodcut details by product
        /// </summary>
        /// <param name="p">Product object</param>
        private static void ShowProductDetailsByProduct(Product p)
        {
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
        }

        /// <summary>
        /// Show the items list of shopping cart
        /// </summary>
        /// <param name="cartList"></param>
        private static void ShowShoppingCart(List<Cart> cartList)
        {
            decimal sum = 0;
            foreach (var item in cartList)
            {
                Console.WriteLine("Product id: " + item.IdGuid);
                Console.WriteLine("Product name: " + item.Name);
                Console.WriteLine("Product price: " + item.Price);
                Console.WriteLine("Purchase quantity: " + item.Quantity);
                Console.WriteLine("Total cost: " + item.TotalCost);
                sum += item.TotalCost;
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("Sum: "+sum);
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
