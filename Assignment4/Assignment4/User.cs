using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class User
    {
        /// <summary>
        /// Constructor for the user, setting the moneypool to 0 at the beginning
        /// </summary>
        public User()
        {
            this.MoneyPool = 0;
        }

        /// <summary>
        /// Property for how much money the user has
        /// </summary>
        public int MoneyPool { get; set; }
        
        /// <summary>
        /// Check if added money from the user can be converted to integer and is a valid value
        /// Add money to the users moneypool
        /// </summary>
        internal void AddMoney(VendingMachine vm)
        {
            bool keepAlive = true; //bool for letting the user add as much money as wanted        
            //loop as long as the user wants to add more money
            while (keepAlive)
            {                
                Console.Write("\nHow much money do you want to add? Valid values:(1), (5), (10), (20), (50), (100), (500), (1000) or (q) for exit:");
                //input in string format how much money the user wants to add
                string inputMoney = Console.ReadLine();
                int money; //int for conversion from string           
                //end the loop if the user wants to quit
                if (inputMoney == "q")
                {
                    keepAlive = false;
                }
                else
                {
                    //check if input from user can be converted to integer
                    if (CanBeConverted(inputMoney))
                    {
                        //convert the string input to integer
                        money = ConvertToInt(inputMoney);
                        //check if entered value is valid value, that is exists in the denominations array
                        if (vm.MoneyDenominations.Contains(money))
                        {
                            //add the money input to the moneypool
                            this.MoneyPool += money;
                            Console.WriteLine("\nCurrent credit: " +this.MoneyPool);
                        }
                        else
                        {
                            Console.WriteLine("Not a valid input, press any key...");
                        }
                    }
                    else
                    {
                        //the user input can't be converted to integer, print error message and take another input from the user
                        Console.WriteLine("Not a valid input, press any key...");
                    }
                }
            }
        }


        /// <summary>
        /// Method for checking if the input text from user can be converted to an integer
        /// </summary>
        /// <param name="inputMoney">String input from user</param>
        /// <returns>bool</returns>
        private bool CanBeConverted(string inputMoney)
        {
            int result;
            if (int.TryParse(inputMoney, out result))
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
        /// <param name="inputMoney">The text input from the user</param>
        /// <returns>int</returns>
        private int ConvertToInt(string inputMoney)
        {
            return int.Parse(inputMoney);
        }
    }
}
