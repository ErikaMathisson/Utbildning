using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class VendingMachine
    {
        /// <summary>
        /// Empty constructor for the vending machine
        /// </summary>
        public VendingMachine()
        {

        }
        /// <summary>
        /// Returning all possible money denominations
        /// </summary>
        public int[] MoneyDenominations
        {
            get
            {
                return new int[] { 1000, 500, 100, 50, 20, 10, 5, 1 };
            }
        }

        /// <summary>
        /// Method for adding products to the vending machine. Right now only hard coded products.
        /// </summary>
        /// <param name="products">List of products that should be added to the vending machine</param>
        /// <returns>List of products</returns>
        internal List<Product> AddProducts(List<Product> products)
        {
            //adding different types of products to the list of products; drinks, fruits and snacks.
            //All different types of products has tha information about: name of product, price of product and an id (based on how many products that exist)
            Product product = new Drinks("Water", 14, products.Count + 1);
            products.Add(product);
            product = new Drinks("Juice", 18, products.Count + 1);
            products.Add(product);
            product = new Fruit("Banana", 8, products.Count + 1);
            products.Add(product);
            product = new Fruit("Apple", 7, products.Count + 1);
            products.Add(product);
            product = new Snacks("Chips", 28, products.Count + 1);
            products.Add(product);
            product = new Snacks("Chocolate", 26, products.Count + 1);
            products.Add(product);
            return products;

        }

        /// <summary>
        /// Return money to the user if the user has any left, divided based on the money denominations
        /// </summary>
        /// <param name="user">The user who should get money back</param>
        public void ReturnMoney(User user)
        {
            //the user has money left, should be returned in stated denominations                
            if (user.MoneyPool != 0)
            {
                Console.WriteLine("\nYou should get " + user.MoneyPool + " back with distribution: \n");
                //loop for determine what denominations that the money should be returned in
                foreach (int item in this.MoneyDenominations)
                {
                    //how many of each denomination
                    int changeBack = user.MoneyPool / item;
                    //print out to the user how many of the denomination should be payed back
                    if (changeBack != 0)
                    {
                        //subtraction from the moneypool after each denomination
                        user.MoneyPool = user.MoneyPool - (item * changeBack);
                        //print the result to the user
                        Console.WriteLine($"{changeBack} of {item } = {changeBack * item}");
                    }
                }
            }
            //no money should be returned to the user, print the info to the user
            else
            {
                Console.WriteLine("\nNo money should be returned!");
            }
        }

        /// <summary>
        /// Method for buying products
        /// </summary>
        /// <param name="products">existing products in the vending machine</param>
        /// <param name="user">The user who wants to buy products</param>
        internal void BuyProduct(List<Product> products, User user)
        {
            //bool value for letting the user buy as many products that the user wants to
            bool keepAlive = true;
            //loop for letting the user buy many products
            while (keepAlive)
            {
                //clear the screen, print the menu and show what credit the user have
                Console.Clear();
                Console.WriteLine("BUY PRODUCT\n");
                Console.WriteLine($"Your credit is: {user.MoneyPool}\n");
                this.ExamineProduct(products);
                Console.Write("\nPlease enter id for wanted product or (q) for quit: ");
                //what does the user want to do?
                string choice = Console.ReadLine();
                int id;
                // does entered id exist in the list of products?
                bool productExist = false;
                //the user don't want to quit
                if (choice != "q")
                {
                    //check if input from user can be converted to integer
                    if(ValidatationConversion.CanBeConverted(choice))
                    {
                        //convert the string input to integer
                        id = ValidatationConversion.ConvertToInt(choice);
                       
                        //loop through the list to see if wanted product exist
                        foreach (Product p in products.ToList())
                        {
                            //the wanted product is found
                            if (p.itemId == id)
                            {
                                //the product exist in the list
                                productExist = true;
                                //the user have enough money to buy the product
                                if (user.MoneyPool >= p.itemPrice)
                                {
                                    //buy the product; depending on what type of product different classes are invoked
                                    p.Purchase(p);
                                    //take money (price of product) from the users moneypool 
                                    user.MoneyPool = user.MoneyPool - p.itemPrice;
                                    //use the product
                                    p.Use(p);        
                                    //remove the product from the list, the user has already bought it                                                                                    
                                    products.Remove(p);

                                }
                                else  //the user don't have enough money, print information about this
                                {
                                    Console.WriteLine("Sorry you don't have enough money, please add some... ");
                                    Console.WriteLine("Press any key...");

                                }                             
                            }
                        }
                    }
                    else
                    {
                        //the user input can't be converted to integer, print information about this
                        Console.WriteLine("Not a valid input...");
                    }
                    //the product doesn't exist, print information about this to the user
                    if (productExist == false)
                    {
                        Console.WriteLine("No product with that id exists!\n");
                    }

                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else //the user doesn't want to buy anymore products (choose q in the menu), no need to loop anymore
                {
                    keepAlive = false;
                }

            }
        }

        /// <summary>
        /// Method for examining the different products in the vending machine. Depending on type of product different examine methods is invoked
        /// </summary>
        /// <param name="products">the product that should be examined</param>
        internal void ExamineProduct(List<Product> products)
        {
            Console.WriteLine("Current products in the vending machine\n");
            //loop through all products in the vending machine and print information about them
            //depending of what type of product (fruit, drink or snacks), different methods are invoked 
            foreach (Product p in products)
            {
                p.Examine(p);
            }
        }        
    }
}

