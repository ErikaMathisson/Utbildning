using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                //initialize random number
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 100);

                bool keepAlive = true;

                //initialise counter
                int tried = 0;

                while (keepAlive)
                {

                    // ask to enter a number
                    Console.Write("Please guess a number between 1 and 100: ");
                    string numberFromUser = Console.ReadLine();

                    //check if given text can be converted to integer
                    if (validateNumber(numberFromUser))
                    {
                        //convert given text to integer
                        int number = convertStringToNumber(numberFromUser);
                        tried++;

                        if (number == randomNumber)
                        {
                            Console.WriteLine("Congratulations! You found the random number in {0} times", tried);
                            keepAlive = false;
                            Console.Write("Do you want to restart? press (y) to restart or (n) to exit: ");
                            if (Console.ReadLine() == "n")
                            {
                                alive = false;

                            }
                           
                        }
                        else if (number > randomNumber)
                        {
                            Console.WriteLine("Try with lower number.. ");
                        }
                        else
                        {
                            Console.WriteLine("Try with higher number.. ");
                        }


                    }
                    else
                    {
                        Console.WriteLine("Please use digits only ");
                    }

                }
            }
        }

        /// <summary>
        /// Use this method to check if given text can be converted to int
        /// </summary>
        /// <param name="numberToValidate">text from user</param>
        /// <returns>bool</returns>
        static bool validateNumber(string numberToValidate)
        {
            int number = 0;
            if (int.TryParse(numberToValidate, out number))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Use this method to convert given text from user to a valid number
        /// </summary>
        /// <param name="numberToConvert">Text from user to convert to integer</param>
        /// <returns>int</returns>
        static int convertStringToNumber(string numberToConvert)
        {
            int number = int.Parse(numberToConvert);
            return number;
        }
    }
}