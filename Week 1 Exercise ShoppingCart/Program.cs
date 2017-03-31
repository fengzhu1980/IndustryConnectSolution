using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_1_Exercise_ShoppingCart.Model;
using Week_1_Exercise_ShoppingCart.Service;

namespace Week_1_Exercise_ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize products
            ProductService productService = new ProductService();
            List<Product> products = productService.InitializeProduct();

            //Create cartList object
            List<ShoppingCart> cartList = new List<ShoppingCart>();

            //Welcome
            Console.WriteLine("Welcome to our shop.");

            //Show products list
            ShowProductList(products);

            //Start shopping
            bool continueShopping = true;

            do
            {
                //Input product number
                Console.WriteLine("Please enter product number you want to purchase:");
                //Get input number
                string strInputNumber = Console.ReadLine();
                //Check if input number is valid
                int productNum;
                if (!int.TryParse(strInputNumber, out productNum))
                {
                    Console.WriteLine("This number does not exist, please try an other one:");
                    continue;
                    //strInputNumber = Console.ReadLine();
                }
                //number is valid
                productNum = int.Parse(strInputNumber);

                //Check if the product number exist
                //Create Product object
                Product product = GetProductByProductNumber(productNum, products);
                if (product == null)
                {
                    Console.WriteLine("This number does not exist, please try an other one.");
                    continue;
                }

                //Show product details by product number
                //get product types
                string pName = product.GetType().Name;
                ShowProductDetailsByProductName(pName, product);

                //Get quantity want to purchase
                //Define bool type for checking if input is valid
                int numPurchase;
                bool isValid = true;
                do
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Please enter quantity you want to purchase");
                    string strPurchase = Console.ReadLine();
                    //Check if input is valid
                    if (!int.TryParse(strPurchase, out numPurchase))
                    {
                        Console.WriteLine("Please input a valid number.");
                        isValid = true;
                    }
                    else//input is valid
                    {
                        numPurchase = int.Parse(strPurchase);
                        //Check if input number larger than in stock
                        if (numPurchase > product.Numbers)
                        {
                            Console.WriteLine("Input number is larger than stock number.");
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                } while (isValid);

                //Add into shopping cart
                AddIntoShoppingCartList(product, cartList, numPurchase);
                //Change in stock number
                ChangeInStockNumber(product, numPurchase);

                //Show how many product in the shopping cart
                Console.WriteLine("You has {0} product in your cart.", cartList.Count);
                Console.WriteLine("Would you like to add more product to your cart. Press Y to continue or N to Checkout");
                string strYesOrNo = Console.ReadLine().ToLower(); ;

                if (strYesOrNo.Equals("y"))
                {

                    //Show products list
                    ShowProductList(products);
                    continue;
                }
                else//print shopping cart and total to pay
                {
                    //Print shopping cart
                    Console.WriteLine("===========================================");
                    decimal sumTotal = PrintShoppingCart(cartList);
                    //Print total to pay
                    Console.WriteLine("Total to pay: {0}", sumTotal);
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Thank you for shopping with us. Bye bye");
                    continueShopping = false;
                }
            } while (continueShopping);

            Console.ReadKey();
        }

        /// <summary>
        /// Change in stock numbers
        /// </summary>
        /// <param name="product">Product object</param>
        /// <param name="numPurchase">purchase number</param>
        private static void ChangeInStockNumber(Product product, int numPurchase)
        {
            product.Numbers -= numPurchase;
        }

        /// <summary>
        /// Show product list
        /// </summary>
        /// <param name="products">Product List</param>
        private static void ShowProductList(List<Product> products)
        {
            Console.WriteLine("List of product:");
            Console.WriteLine("===========================================");
            foreach (var p in products)
            {
                Console.WriteLine("Product id: " + p.Id);
                Console.WriteLine("Product name: " + p.Name);
                Console.WriteLine("Product price: " + p.Price);
                Console.WriteLine("Product quality in stock: " + p.Numbers);
                Console.WriteLine("Product type: " + p.GetType().Name);
                Console.WriteLine("===========================================");
            }
        }

        /// <summary>
        /// Add product details into ShoppingCart list
        /// </summary>
        /// <param name="product">Product ojbect</param>
        /// <param name="cartList">ShoppingCart List object</param>
        /// <param name="number">purchase number</param>
        private static void AddIntoShoppingCartList(Product product, List<ShoppingCart> cartList, int number)
        {
            ShoppingCart sCart = new ShoppingCart()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = number,
                TotalCost = product.Price * number
            };
            cartList.Add(sCart);
        }

        /// <summary>
        /// show product details by product name
        /// </summary>
        /// <param name="pName">product name</param>
        /// <param name="product">Product object</param>
        private static void ShowProductDetailsByProductName(string pName, Product product)
        {
            switch (pName)
            {
                case "Car":
                    Car pCar = (Car)product;
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Produt type: Car");
                    Console.WriteLine("Produt id: {0}", pCar.Id);
                    Console.WriteLine("Produt name: {0}", pCar.Name);
                    Console.WriteLine("Produt model: {0}", pCar.Model);
                    Console.WriteLine("Produt price: {0}", pCar.Price);
                    Console.WriteLine("Produt year: {0}", pCar.Year);
                    Console.WriteLine("Produt quantity in stock: {0}", pCar.Numbers);
                    break;
                case "Furniture":
                    Furniture pFurniture = (Furniture)product;
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Produt type: Furniture");
                    Console.WriteLine("Produt id: {0}", pFurniture.Id);
                    Console.WriteLine("Produt name: {0}", pFurniture.Name);
                    Console.WriteLine("Produt material: {0}", pFurniture.Material);
                    Console.WriteLine("Produt price: {0}", pFurniture.Price);
                    Console.WriteLine("Produt quantity in stock: {0}", pFurniture.Numbers);
                    break;
                case "SportsEquipment":
                    SportsEquipment pSportsEquipment = (SportsEquipment)product;
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Produt type: Sports Equipment");
                    Console.WriteLine("Produt id: {0}", pSportsEquipment.Id);
                    Console.WriteLine("Produt name: {0}", pSportsEquipment.Name);
                    Console.WriteLine("Produt used for: {0}", pSportsEquipment.UsedFor);
                    Console.WriteLine("Produt price: {0}", pSportsEquipment.Price);
                    Console.WriteLine("Produt quantity in stock: {0}", pSportsEquipment.Numbers);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Get product by product number
        /// </summary>
        /// <param name="productNum">product number</param>
        /// <param name="products">product list</param>
        /// <returns></returns>
        private static Product GetProductByProductNumber(int productNum, List<Product> products)
        {
            Product product = null;
            foreach (var p in products)
            {
                if (p.Id == productNum)
                {
                    return product = p;
                }
            }
            return product;
        }

        /// <summary>
        /// Print shopping cart details
        /// </summary>
        /// <param name="listCart">ShoppingCart type List</param>
        /// <returns>decimal total cost</returns>
        private static decimal PrintShoppingCart(List<ShoppingCart> listCart)
        {
            decimal sum = 0;
            foreach (var s in listCart)
            {
                Console.WriteLine("Product number: " + s.Id);
                Console.WriteLine("Product name: " + s.Name);
                Console.WriteLine("Product price: " + s.Price);
                Console.WriteLine("Product quantity: " + s.Quantity);
                Console.WriteLine("Product sum: " + s.TotalCost);
                Console.WriteLine("-------------------------------------------");
                sum += s.TotalCost;
            }
            return sum;
        }
    }
}
