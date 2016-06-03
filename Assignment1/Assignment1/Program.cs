using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for looping the calculator
            bool keepAlive = true;

            while (keepAlive)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green; //the main menu is presented in green

                //Creating a menu for the calculator

                Console.WriteLine("\n**** Calculator main menu - please enter an option ****\n");
                //      Console.WriteLine("----------------------------------------");
                Console.WriteLine("Addition \t (1)");
                Console.WriteLine("Subtraction \t (2) ");
                Console.WriteLine("Multiplication \t (3) ");
                Console.WriteLine("Division \t (4) ");
                Console.WriteLine("Quit \t\t (9)");
                Console.WriteLine("----------------------------------------");
                //input from user what action to make
                string choice = Console.ReadLine();

                //validate if text from user can be converted to integer
                if (ValidateNumber(choice))
                {
                    //convert text from user to integer
                    int number = ConvertTextToInteger(choice);

                    switch (number)
                    {
                        case 1:
                            Addition();
                            break;
                        case 2:
                            Subtraction();
                            break;
                        case 3:
                            Multiplication();
                            break;
                        case 4:
                            Division();
                            break;
                        case 9:
                            keepAlive = false; //shouldn't loop anymore...
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red; //error message presented in red
                            Console.WriteLine("Not a valid choise, please try again, press any key to continue! ");
                            Console.ReadKey();
                            break;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; //Error message presented in red
                    Console.WriteLine("Please enter only valid digits, press any key to continue!");
                    Console.ReadKey();
                }

            }

        }



        /// <summary>
        /// Method for adding numbers together, handles any numbers of parameters from user and print the sum of them
        /// </summary>
        private static void Addition()
        {

            bool alive = true;
            while (alive) //loop the addition menu as long as the user wants otherwise return to main menu
            {
                Console.Clear(); //start with a clear screen
                Console.ForegroundColor = ConsoleColor.Yellow; //addition menu in yellow
                Console.WriteLine(" ******** Addition *********\n");
                Console.WriteLine("Adds entered numbers together, for printing the sum and exit (q)! \n");

                double sum = 0;  //parameter for handling sum of any number of parameters          
                double number = 0;  //number to be added, converted from text input from user
                string inputFromUser; // text entered from user
                string allAddedNumbers = ""; //string for holdning all numbers entered by the user, will be used in presenting the sum

                bool keepAlive = true; //parameter for looping
                                       //loop for adding as many parameters as the user wants in one addition
                while (keepAlive)
                {

                    Console.Write("Enter a number or (q): ");
                    inputFromUser = Console.ReadLine();  //get the input from user in text format, number or q for quit

                    //the user don't want to quit that is didn't print q
                    if (inputFromUser != "q")
                    {
                        //validate if the input text from user can be converted to double
                        if (ValidateDouble(inputFromUser))
                        {

                            number = ConvertTextToDouble(inputFromUser);   //convert the text input from user to an int

                            //adding all numbers, in textformat, added by user in a string for presenting the numbers entered in the final sum
                            if (allAddedNumbers == "")
                            {
                                allAddedNumbers = inputFromUser; //the first added number shouldn't have the + character in the beginning
                            }
                            else
                            {
                                allAddedNumbers = allAddedNumbers + " + " + inputFromUser; //adding all parameters for presenting, plus character inbetween

                            }

                            sum = sum + number; //the current sum

                        }
                        else
                        {
                            //the user didn't entar a valid option that is a number or q
                            Console.ForegroundColor = ConsoleColor.Red; //change the color to red when presenting the error message
                            Console.WriteLine("Not a valid number, please try again! Press any key to continue... ");
                            Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.Yellow; //reset the console color to yellow

                        }
                    }
                    else
                    {
                        //the user wants to quit the addition, the sum of all added numbers are presented
                        if (allAddedNumbers == "")
                        {
                            Console.WriteLine("\nYou haven't entered any numbers..."); //no numbers where entered, no sum to be presented

                        }
                        else
                        {
                            Console.WriteLine("\nThe sum of the numbers: " + allAddedNumbers + " = " + sum); //present the sum of all numbers
                        }


                        keepAlive = false; //should't loop anymore since the user added all wanted parameters for this addition...

                        //Do the user want to make another addition?
                        Console.Write("\nDo you want to make another addition? press (y) to restart and (n) to exit: ");
                        String restart = Console.ReadLine();

                        //the user didn't enter a valid option, that is y or n
                        while (restart != "y" && restart != "n") //as long as the user enters an non valid option
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //error message in red
                            Console.WriteLine("Not a valid option. Please enter (y) for restart and (n) for exit to main menu! ");
                            restart = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        //the user don't want to make another addition, the outer loop will be false and exit to main menu
                        if (restart == "n")
                        {
                            Console.WriteLine("\nPress any key to continue to main menu...");
                            Console.ReadKey();
                            alive = false;

                        }

                        Console.Clear();
                    }



                }
            }

        }

        /// <summary>
        /// Method for subtracting numbers together, handles any numbers of parameters
        /// </summary>
        private static void Subtraction()
        {
            bool alive = true;
            while (alive) //loop the subtraction menu as long as alive is true otherwise return to main menu
            {


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White; //subtraction menu in white
                Console.WriteLine(" ******** Subtraction *********\n");
                Console.WriteLine("Subtracts entered numbers from first entered number, for printing the sum and exit (q)! \n");


                double sum = 0;  //parameter for handling sum of any number of parameters          
                double number = 0;  //number to be added, converted from text input from user
                string inputFromUser; // text entered from user
                string allAddedNumbers = ""; //string for holdning all numbers entered by the user, will be used in presenting the sum

                bool keepAlive = true; //parameter for looping the subtracting numbers
                //loop for adding as many parameters as the user wants
                while (keepAlive)
                {

                    Console.Write("Enter a number or (q): ");
                    inputFromUser = Console.ReadLine();  //get the input from user

                    //the user doesn't want to quit that is didn't print q
                    if (inputFromUser != "q")
                    {
                        //validate if the input text, except from q that is quit, from user can be converted to integer
                        if (ValidateDouble(inputFromUser))
                        {
                            number = ConvertTextToDouble(inputFromUser);   //convert the text input from user to an double

                            //adding all numbers, in textformat, added by user in a string for presenting the final sum 
                            //the first entered number will be handled different since all other number will be subtracted from this one
                            if (allAddedNumbers == "")
                            {
                                allAddedNumbers = inputFromUser; //the first added number shouldn't have the - character in the beginning, for presenting
                                sum = number;

                            }
                            else
                            {
                                allAddedNumbers = allAddedNumbers + " - " + inputFromUser; //adding all parameters for presenting, minus character inbetween
                                sum = sum - number; //the current sum

                            }

                        }
                        else
                        {
                            //the user didn't entar a valid option that is a number or q
                            Console.ForegroundColor = ConsoleColor.Red; //change the color to red when presenting the error message
                            Console.WriteLine("Not a valid number, please try again! Press any key to continue... ");
                            Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White; //change back color to "subtraction menu color"

                        }
                    }
                    else
                    {
                        //the user wants to quit the addition, so the sum of all added numbers are presented
                        if (allAddedNumbers == "")
                        {
                            Console.WriteLine("\nYou haven't entered any numbers...");

                        }
                        else
                        {
                            Console.WriteLine("\nThe sum of the numbers: " + allAddedNumbers + " = " + sum);

                        }

                        keepAlive = false; //should't loop anymore since the user wanted the total sum...

                        //Does the user want to make another subtraction?
                        Console.Write("\nDo you want to make another subtraction? press (y) to restart and (n) to exit: ");
                        String restart = Console.ReadLine();

                        //the user didn't enter a valid option, that is y or n
                        while (restart != "y" && restart != "n")
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //error message in red
                            Console.Write("Not a valid option. Please enter (y) for restart and (n) for exit to main menu! ");
                            restart = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White; //change back to subtraction menu color
                        }

                        //the user don't want to make another subtraction, the outer loop false and exit to main menu
                        if (restart == "n")
                        {
                            Console.WriteLine("\nPress any key to continue to main menu...");
                            Console.ReadKey();

                            alive = false;

                        }

                        Console.Clear();
                    }

                }
            }


        }
        /// <summary>
        /// Method for multipicate numbers togheter
        /// </summary>
        private static void Multiplication()
        {
            bool keepAlive = true;

            while (keepAlive) // loop so that the user can make as many multiplications as wanted
            {
                Console.Clear(); // clear the screen
                Console.ForegroundColor = ConsoleColor.Magenta; //setting color for multiplication menu
                Console.WriteLine(" ******** Multiplication *********\n");
                Console.WriteLine("Multiplicates two integers together! \n");

                double firstNumber; //the first number to be multiplicated
                double secondNumber; //the second number to be multiplicated
                double sum; //sum of multiplications

                Console.Write("Enter the first number: ");
                string inputOne = Console.ReadLine();

                while (!ValidateDouble(inputOne)) //validate if the first number can be converted to a double
                {
                    Console.ForegroundColor = ConsoleColor.Red; //error text in red
                    Console.WriteLine("Not a valid number, please try again with an integer! ");
                    Console.ForegroundColor = ConsoleColor.Magenta; //reset the color
                    Console.Write("Enter the first number: "); //ask user for another try at first number
                    inputOne = Console.ReadLine();
                }

                firstNumber = ConvertTextToDouble(inputOne); //convert the first number

                Console.Write("Enter the second number: ");
                string inputTwo = Console.ReadLine(); //the second number from the user
                while (!ValidateDouble(inputTwo)) //validate the second number
                {
                    Console.ForegroundColor = ConsoleColor.Red; //error text in red
                    Console.WriteLine("Not a valid number, please try again with an integer! ");
                    Console.ForegroundColor = ConsoleColor.Magenta; //reset the color
                    Console.Write("Enter the second number: "); //ask user for another try at second number
                    inputTwo = Console.ReadLine();
                }

                secondNumber = ConvertTextToDouble(inputTwo); //convert the second number

                sum = firstNumber * secondNumber; //multiplicate the first and the second number

                Console.Write("The sum is: " + firstNumber + " * " + secondNumber + " = " + sum);

                //Does the user want to make another multiplication?
                Console.Write("\nDo you want to make another multiplication? press (y) to restart and (n) to exit: ");
                String restart = Console.ReadLine();

                //the user didn't enter a valid option, that is y or n
                while (restart != "y" && restart != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red; //error message in red
                    Console.Write("Not a valid option. Please enter (y) for restart and (n) for exit to main menu! ");
                    restart = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta; //change back to multiplication menu color
                }

                //the user don't want to make another multiplication, the loop false and exit to main menu
                if (restart == "n")
                {
                    Console.WriteLine("\nPress any key to continue to main menu...");
                    Console.ReadKey();

                    keepAlive = false;

                }

                Console.Clear();
            }

        }

        /// <summary>
        /// Method for division between numbers
        /// </summary>
        private static void Division()
        {
            bool keepAlive = true;

            while (keepAlive) // loop so that the user can make as many divisions as wanted
            {
                Console.Clear(); // clear the screen
                Console.ForegroundColor = ConsoleColor.Cyan; //setting color for division menu
                Console.WriteLine(" ******** Division *********\n");
                Console.WriteLine("Division between two numbers! \n");

                double firstNumber = 0; //the first number to be divided
                double secondNumber = 0; //the second number to be divided
                double sum; //sum of division

                Console.Write("Enter the first number: ");
                string inputOne = Console.ReadLine();

                while (!ValidateDouble(inputOne)) //validate if the first number can be converted to double
                {
                    Console.ForegroundColor = ConsoleColor.Red; //error text in red
                    Console.WriteLine("Not a valid number, please try again! ");
                    Console.ForegroundColor = ConsoleColor.Cyan; //reset the color
                    Console.Write("Enter the first number: "); //ask user for another try at first number
                    inputOne = Console.ReadLine();
                }

                firstNumber = ConvertTextToDouble(inputOne); //convert the first number

                bool secondNumberNotOk = true; 

                while (secondNumberNotOk) //make sure the second number isn't 0
                {

                    Console.Write("Enter the second number, can't be 0: ");
                    string inputTwo = Console.ReadLine(); //the second number from the user
                    
                    while (!ValidateDouble(inputTwo)) //validate the second number so it can be converted to double
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //error text in red
                        Console.WriteLine("Not a valid number, please try again! ");
                        Console.ForegroundColor = ConsoleColor.Cyan; //reset the color
                        Console.Write("Enter the second number, can't be 0: ");
                        inputTwo = Console.ReadLine();
                    }

                    secondNumber = ConvertTextToDouble(inputTwo); //convert the second number

                    if (secondNumber == 0) //error if the second number is 0
                    {
                        Console.ForegroundColor = ConsoleColor.Red;  //error text in red
                        Console.WriteLine("Second number can't be 0, try again! ");
                        Console.ForegroundColor = ConsoleColor.Cyan; //reset the color
                        secondNumberNotOk = true; 
                    }
                    else
                    {
                        secondNumberNotOk = false;
                    }

                }

                sum = firstNumber / secondNumber; //multiplicate the first and the second number

                Console.Write("The sum is: " + firstNumber + " / " + secondNumber + " = " + sum);

                //Does the user want to make another division?
                Console.Write("\nDo you want to make another division? press (y) to restart and (n) to exit: ");
                String restart = Console.ReadLine();

                //the user didn't enter a valid option, that is y or n
                while (restart != "y" && restart != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red; //error message in red
                    Console.Write("Not a valid option. Please enter (y) for restart and (n) for exit to main menu! ");
                    restart = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan; //change back to division menu color
                }

                //the user don't want to make another division, the loop false and exit to main menu
                if (restart == "n")
                {
                    Console.WriteLine("\nPress any key to continue to main menu...");
                    Console.ReadKey();

                    keepAlive = false;

                }

                Console.Clear();
            }

        }


        /// <summary>
        /// Method for validating if the user entered a text that can be converted to int
        /// </summary>
        /// <param name="choice">Text entered by user</param>
        /// <returns>bool</returns>
        private static bool ValidateNumber(string choice)
        {
            int number = 0;
            if (int.TryParse(choice, out number))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for converting text from user to integer
        /// </summary>
        /// <param name="choice">Text entered from user</param>
        /// <returns>int</returns>
        private static int ConvertTextToInteger(string choice)
        {
            int number = int.Parse(choice);
            return number;
        }

    

        /// <summary>
        /// Method for validating if the user entered a text that can be converted to double
        /// </summary>
        /// <param name="choice">Text entered by user</param>
        /// <returns>bool</returns>
        private static bool ValidateDouble(string choice)
        {
            double number = 0.0;
            if (double.TryParse(choice, out number))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for converting text from user to double
        /// </summary>
        /// <param name="choice">Text entered from user</param>
        /// <returns>int</returns>
        private static double ConvertTextToDouble(string choice)
        {
            double number = double.Parse(choice);
            return number;
        }


    }


}
