using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {

            var KeepAlive = true;

            while (KeepAlive)
            {
                try
                {
                    Console.Write("Enter assignment number (or -1 to exit): ");
                    //why do you need this syntax: ?? ""
                    var assigmentChoise = int.Parse(Console.ReadLine() ?? "");
                    Console.ForegroundColor = ConsoleColor.Green;

                    switch (assigmentChoise)
                    {
                        case 1:
                            RunExerciseOne();
                            break;
                        case 2:
                            RunExerciseTwo();
                            break;
                        case 3:
                            RunExerciseThree();
                            break;
                        case 4:
                            RunExcerciseFour();
                            break;
                        case 5:
                            RunExcerciseFive();
                            break;
                        case 6:
                            RunExcerciseSix();
                            break;
                        case 7:
                            RunExcerciseSeven();
                            break;
                        case 8:
                            RunExcerciseEight();
                            break;
                        case 9:
                            RunExcerciseNine();
                            break;
                        case 10:
                            RunExcerciseTen();
                            break;
                        case 11:
                            RunExcerciseEleven();
                            break;
                        case 12:
                            RunExcerciseTwelve();
                            break;
                        case 13:
                            RunExcerciseThirteen();
                            break;
                        case 14:
                            RunExcerciseFourteen();
                            break;
                        case 18:
                            RunExcerciseEightteen();
                            break;
                        case 19:
                            RunExcerciseNineteen();
                            break;
                        case 21:
                            RunExcerciseTwentyOne();
                            break;
                        case 27:
                            RunExcerciseTwentyseven();
                            break;
                        case -1:
                            KeepAlive = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is not a valid assigment number!");
                            break;
                    }
                    Console.ResetColor();
                    Console.WriteLine("Hit any key to continue!");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This is not a valid assigment number!");
                    Console.ResetColor();

                }
            }
        }


        private static void RunExerciseOne()
        {
            String firstName = "Erika";
            String lastName = "Mathisson";

            Console.WriteLine("Hello " + firstName + " " + lastName + " I'm glad to inform you that you are the test subject for my first assignment!");

        }

        private static void RunExerciseTwo()
        {
            DateTime todayDate = DateTime.Now.Date;
            DateTime tomorrowDate = todayDate.AddDays(1);
            DateTime yesterdayDate = todayDate.AddDays(-1);
            //Just testing subtracting to dates
            // TimeSpan subtract = tomorrowDate - todayDate;

            Console.WriteLine("Todays date is: " + todayDate);
            Console.WriteLine("Tomorrows date is: " + tomorrowDate);
            Console.WriteLine("Yesterdays date is: " + yesterdayDate);
            // output of the subtracting dates
            //   Console.WriteLine("subtract: " + subtract);

        }

        private static void RunExerciseThree()
        {

            String firstName;
            String lastName;

            Console.Write("Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();

            Console.WriteLine(firstName + " " + lastName);

        }

        private static void RunExcerciseFour()
        {
            String str = "The quick fox Jumped Over the DOG";

            str = str.Replace("quick", "brown");
            str = str.Replace("DOG", "dog");
            str = str.Replace("J", "j");
            str = str.Replace("O", "o");
            str = str.Insert(30, "lazy ");

            Console.WriteLine(str);

        }

        private static void RunExcerciseFive()
        {

            String str = "Arrays are very common in programming, they look something like [1,2,3,4,5]";
            //     Console.ReadLine(); why are this suppose to be there?
            Console.WriteLine(str);
            // the text [1,2,3,4,5] are stored in variable newStr
            String newStr = str.Substring(64);
            //remove string "2,3,"
            newStr = newStr.Remove(3, 4);
            newStr = newStr.Insert(6, ",6,7,8,9,10");

            Console.WriteLine(newStr);

        }

        private static void RunExcerciseSix()
        {
            int firstNumber;
            int secondNumber;

            Console.Write("Please enter a first integer: ");
            firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Please enter a second integer: ");
            secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                Console.WriteLine("The first integer " + firstNumber + " is the biggest number");
                Console.WriteLine("The second integer " + secondNumber + " is the smallest number");
            }
            else if (firstNumber < secondNumber)
            {
                Console.WriteLine("The first integer " + firstNumber + " is the smallest number");
                Console.WriteLine("The second integer " + secondNumber + " is the biggest number");

            }
            else
            {
                Console.WriteLine("The first integer " + firstNumber + " and the second integer " + secondNumber + " are equal");
            }

            int differance = firstNumber - secondNumber;
            Console.WriteLine("The differance between the integers are: " + differance);

            int sum = firstNumber + secondNumber;
            Console.WriteLine("The sum between the integers are: " + sum);

            int product = firstNumber * secondNumber;
            Console.WriteLine("The product between the integers are: " + product);

            double ratio = firstNumber / (double)secondNumber;
            Console.WriteLine("The ratio between the integers are: " + ratio);


        }

        private static void RunExcerciseSeven()
        {
            double radius;
            Console.Write("Please enter a radius: ");
            radius = double.Parse(Console.ReadLine());

            double area = 2 * Math.PI * radius * radius;

            Console.WriteLine("The area is: " + area);

            double volume = (4 * Math.PI * radius * radius * radius) / 3;
            Console.WriteLine("The volume is: " + volume);

        }

        private static void RunExcerciseEight()
        {
            double decimalNumber;
            double squareRoot;
            double timesTwo;
            double timesTen;

            Console.Write("Please enter a decimal number: ");

            decimalNumber = double.Parse(Console.ReadLine());

            squareRoot = Math.Sqrt(decimalNumber);
            Console.WriteLine("The squareroot of " + decimalNumber + " is: " + squareRoot);

            timesTwo = Math.Pow(decimalNumber, 2);
            Console.WriteLine("The decimalnumber " + decimalNumber + " raised to the power of 2 is: " + timesTwo);

            timesTen = Math.Pow(decimalNumber, 10);
            Console.WriteLine("The decimalnumber " + decimalNumber + " raised to the power of 10 is: " + timesTen);

        }

        private static void RunExcerciseNine()
        {
            String name;
            int birthYear;
            int age;
            String orderBeer;
            String orderCoke;

            Console.Write("Please enter your name: ");
            name = Console.ReadLine();

            Console.Write("Hello, " + name + " what year where you born (YYYY)? ");
            birthYear = int.Parse(Console.ReadLine());

            age = DateTime.Now.Year - birthYear;
            Console.WriteLine("You are " + age + " years old");

            if (age > 18)
            {
                Console.Write("Do you want to order a beer, y for yes and n for no? ");
                orderBeer = Console.ReadLine();
                if (orderBeer == "y")
                {
                    Console.WriteLine("The beer has been ordered! ");
                }
                else if (orderBeer == "n")
                {
                    Console.Write("Do you want to order a coke, y for yes and n for no? ");
                    orderCoke = Console.ReadLine();
                    if (orderCoke == "y")
                    {
                        Console.WriteLine("The coke has been ordered! ");

                    }
                    else
                    {
                        Console.WriteLine("No other options available. ");

                    }

                }
                else
                {
                    Console.WriteLine("Please enter only y or n ");
                }

            }
            else
            {
                Console.Write("Do you want to order a coke, y for yes and n for no? ");
                orderCoke = Console.ReadLine();
                if (orderCoke == "y")
                {
                    Console.WriteLine("The coke has been ordered ");

                }
                else
                {
                    Console.WriteLine("No other options available. ");

                }


            }

        }

        private static void RunExcerciseTen()
        {

            bool keepAlive = true;

            while (keepAlive)
            {
                int choice;
                Console.Write("Please enter an option 1, 2, 3 or -1 for exit: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InputTwoNumbers();
                        break;

                    case 2:
                        RunExcerciseFour();
                        break;

                    case 3:

                        Console.WriteLine(Console.ForegroundColor);
                        if (Console.ForegroundColor == ConsoleColor.Green)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        break;

                    case -1:
                        keepAlive = false;
                        break;

                    default:
                        Console.WriteLine("Not a valid number, please try again");
                        break;
                }
            }


        }


        private static void InputTwoNumbers()
        {
            int a;
            int b;
            double product;

            Console.Write("Please enter a number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Please enter a second number: ");
            b = int.Parse(Console.ReadLine());

            if (b != 0)
            {
                product = a / (double)b;
                Console.WriteLine("The product between " + a + " and " + b + " is " + product);

            }
            else
            {
                Console.WriteLine("The second number can't be zero! ");
            }

        }

        private static void RunExcerciseEleven()
        {
            int number;
            int dividedByTwo;

            Console.Write("Please enter an integer above zero: ");
            number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("The number zero is not a valid number");
            }
            else
            {

                for (int i = 0; i <= number; i++)
                {
                    dividedByTwo = i % 2;

                    if (dividedByTwo == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    Console.WriteLine(i);

                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("----------------------------------------");

                for (int j = number; j >= 0; j--)
                {
                    dividedByTwo = j % 2;
                    if (dividedByTwo == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    Console.WriteLine(j);

                }


            }


        }

        private static void RunExcerciseTwelve()
        {
            int k;
            Console.WriteLine("The tenth multiplication table:  ");

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    k = i * j;

                    Console.Write(k + "\t");

                }
                Console.Write("\n");
            }

        }

        private static void RunExcerciseThirteen()
        {
            int number;
            int numberOfGuesses = 1;
            var keepAlive = true;

            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 500);

            Console.Write("Please guess a number between 1 and 500: ");
            number = int.Parse(Console.ReadLine());

            while (keepAlive)
            {

                if (number == randomNumber)
                {
                    Console.WriteLine("Your guess is correct! The random number is: " + randomNumber);
                    Console.Write("The number of guesses needed: " + numberOfGuesses);
                    keepAlive = false;

                }
                else
                {
                    if (number > randomNumber)
                    {
                        Console.WriteLine("Your guess was to big ");
                        Console.Write("Please enter a new number: ");
                        number = int.Parse(Console.ReadLine());

                    }
                    else
                    {
                        Console.WriteLine("Your guess was to small ");
                        Console.Write("Please enter a new number: ");
                        number = int.Parse(Console.ReadLine());
                    }

                }

                numberOfGuesses++;

            }

        }


        private static void RunExcerciseFourteen()
        {

            int number = 0;
            int amountOfNumbers = 0;
            int sum = 0;
            double average = 0.0;

            while (number != -1)
            {
                Console.Write("Please enter a number, if -1 is entered the method will stop: ");
                number = int.Parse(Console.ReadLine());

                if (number != -1)
                {
                    sum = number + sum;
                    amountOfNumbers++;

                }

            }

            if (sum != 0)
            {
                average = sum / (double)amountOfNumbers;
            }


            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);

        }

        /// <summary>
        /// Create an array of ten integers and assign every element with a new random number
        /// Create an array of ten doubles and assign every element with the value of 1/the integer from the first array
        /// Loop through both arrays and print out the values, use a foreach loop
        /// </summary>
        private static void RunExcerciseEightteen()
        {
            //create an array of integers with ten elements
            int[] intArray = new int[10];
            //create an array of doules with ten elements
            double[] doubleArray = new double[10];
            Random rand = new Random(); //generating a random integer

            //assign the intArray with random integer value on each element
            for (int i = 0; i < intArray.Length; i++)
            {
                int rnd = rand.Next(100); //creates a new random value of type int with maximum value of 100
                intArray[i] = rnd; //store the randominteger in the array
            }

            //assign the values to the doublearray
            for (int j = 0; j < doubleArray.Length; j++)
            {
                //the value for the doubleArray is 1/the value from the intArray
                doubleArray[j] = 1 / (double)intArray[j];

            }

            //print out all the elements in the array of integers
            foreach (int item in intArray)
            {
                Console.WriteLine("Value of array of integers: " + item);

            }
            //print out all the elements in the array of doubles
            foreach (double item in doubleArray)
            {
                Console.WriteLine("Value of array of doubles: " + item);

            }


            Console.ReadKey();

        }

        /// <summary>
        /// Create a program that outputs a price that the customer (user) needs to pay. 
        /// This should be an integer value. 
        /// Then let the user input the sum he hands the cashier.  
        /// Let your program then calculate the change that the customer should get back in different coin unit.
        /// For example, if the user hands the cashier 500 kr and the price is 376 kr, the change will be 124. 
        /// This can be divided up into 100x1 kr. + 20x1 kr. + 4x1 kr. 
        /// The goal here is to get as few coins as possible.
        /// Tip: Use an array to store the different coin units, like 100, 50, 20 etc.
        /// When you have calculated the change, go through the coin units from larges to smallest and 
        /// calculate how many of each type the customer should get back.Here is a perfect scenario when integer division and modulus is viable to use.
        /// </summary>
        private static void RunExcerciseNineteen()
        {

            int[] changeValues = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 1 }; //add all possible values for change in an array

            Random rand = new Random(); 
            int price = rand.Next(100, 1000); //price a random number between 100 and 1000
            int sumEntered; //how much sum did the user enter

            int change; //how much change should the user get back

            Console.WriteLine("You need to pay: " + price);
            Console.WriteLine("Please enter sum entered: ");
            sumEntered = int.Parse(Console.ReadLine());
            change = sumEntered - price;
            Console.WriteLine("You should get " + change + " back");
            Console.WriteLine("Coins distribution: ");

            foreach (int item in changeValues)
            {
                int changeBack = change / item;  //how much of each value should the user get

                Console.WriteLine(item + " coins = " + changeBack);

                if (changeBack != 0)
                {
                    change = change - item;
                }


            }
            Console.ReadKey();
            
        }

        /// <summary>
        /// Let the user input a string with numbers comma separated like “1,2,34,83,19,45”.  
        /// Create the code to separate the numbers in the string into an array and find the min, max and average value.
        /// Print these out to the screen.
        /// Tip: use the Split-function on the String-object. 
        /// Keep in mind that the Split-method returns an array of Strings, so you have to convert each value to an integer 
        /// before you can do the calculations.
        /// </summary>
        private static void RunExcerciseTwentyOne()
        {
            string enteredNumbers;
            int maxValue;
            int minValue;
            int sum=0;
            double averageValue;


            Console.WriteLine("Please enter a string with numbers commasepareted");
            enteredNumbers = Console.ReadLine();
            char separator = ',';

            string[] values = enteredNumbers.Split(separator);
            int[] numbers = new int[values.Length];

            maxValue = numbers[0];
            minValue = numbers[0];
            

            for (int i = 0; i < values.Length; i++)
            {
               
                numbers[i] = int.Parse(values[i]);

                if(numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                
                }
                if (numbers[i]< minValue)
                {
                    Console.WriteLine("Min value 1: " + minValue);
                    minValue = numbers[i];

                }

                sum = sum + numbers[i];


            }

            averageValue = sum / (double)numbers.Length;
            Console.WriteLine("Max value: "+maxValue);
            Console.WriteLine("Min value: " +minValue);
            Console.WriteLine("Average value: " +averageValue);
            

        }
        private static void RunExcerciseTwentyseven()
        {

            StreamReader str = new StreamReader("TextFile1.txt");

            while (!str.EndOfStream)
            {
                Console.WriteLine("From file: " + str.ReadLine());

            }
          


        }

       


    }
}
