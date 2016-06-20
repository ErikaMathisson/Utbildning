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
            if(user.MoneyPool !=0)
            {
                Console.WriteLine("\nYou should get " + user.MoneyPool + " back with distribution: \n");
                //loop for determine what denominations that the money should be returned in
                foreach (int item in this.MoneyDenominations)
                {
                    //how many of each denomination
                    int changeBack = user.MoneyPool/item;                   
                    //print out to the user how many of the denomination should be payed back
                    if (changeBack != 0)
                    {
                        //subtraction from the moneypool after each denomination
                        user.MoneyPool = user.MoneyPool - (item*changeBack);
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
    }
}
