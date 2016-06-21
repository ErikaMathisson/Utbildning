using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class VendingMachine
    {

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


        internal void BuyProduct(List<Product> products, User user)
        {

            bool keepAlive = true;

            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine("BUY PRODUCT\n");
                Console.WriteLine($"Your credit is: {user.MoneyPool}\n");
                this.ExamineProduct(products);
                Console.WriteLine("\nPlease enter id for wanted product or (q) for quit: ");
                string choice = Console.ReadLine();
                int id;

                if (choice != "q")
                {
                    //check if input from user can be converted to integer
                    if (CanBeConverted(choice))
                    {
                        //convert the string input to integer
                        id = ConvertToInt(choice);
                        Console.WriteLine("Wanted id: " + id);

                        foreach (Product p in products)
                        {

                            if (p.itemId == id)
                            {

                                Console.WriteLine("Wanted product: " + p.itemName);


                                if (user.MoneyPool >= p.itemPrice)
                                {
                                    p.Purchase();

                                    user.MoneyPool = user.MoneyPool - p.itemPrice;
                                    Console.WriteLine("money pool " + user.MoneyPool);

                                    // todo:: how to remove an element from the list without error??
                            //        products.Remove(p);


                                }
                                else
                                {
                                    Console.WriteLine("Sorry you don't have enough money, please add some... ");
                                    Console.WriteLine("Press any key...");

                                }

                                Console.ReadKey();

                               

                            }

                        }
                    }
                    else
                    {
                        //the user input can't be converted to integer, print error message and take another input from the user
                        Console.WriteLine("Not a valid input, press any key...");
                    }
                  
                    Console.ReadKey();
                }
                else
                {
                    keepAlive = false;
                }

            }
        }


        internal void ExamineProduct(List<Product> products)
        {
            Console.WriteLine("Current products in the vending machine\n");
            foreach (Product p in products)
            {
                p.Examine(p);
            }

        }




        /// <summary>
        /// Method for checking if the input text from user can be converted to an integer
        /// </summary>
        /// <param name="input">String input from user</param>
        /// <returns>bool</returns>
        private bool CanBeConverted(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for convering an input string to integer
        /// </summary>
        /// <param name="input">The text input from the user</param>
        /// <returns>int</returns>
        private int ConvertToInt(string input)
        {
            return int.Parse(input);
        }
    }




}

