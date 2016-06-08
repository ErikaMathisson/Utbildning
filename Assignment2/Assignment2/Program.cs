using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
       static void Main(string[] args)
        {
           
            
            double gravity = 9.8;
            double angleInRadians;
            double distance = 0;
      //      int numberOfSwings = 0;
            //List<int> swingDistance = new List<int>();
                      

            //int distanceToCup = SetDistanceToCup(); //set the distance to the cup
            //int maxNumberOfSwings = SetMaximumNumberOfSwings(distanceToCup); //determine how many swings that are maximum
            //int maximumDistance = distanceToCup + 200;

            //Console.WriteLine("****** Golf game *******");
            //Console.WriteLine("\nInitial distance to cup is: " + distanceToCup + " m");
            //Console.WriteLine("Maximum number of swings are: " + maxNumberOfSwings);


            bool keepAlive = true;
            bool alive = true;

            while (alive)
            {

                List<int> swingDistance = new List<int>();
                int numberOfSwings = 0;


                //     int distanceToCup = SetDistanceToCup(); //set the distance to the cup

                int distanceToCup = 640;
                int maxNumberOfSwings = SetMaximumNumberOfSwings(distanceToCup); //determine how many swings that are maximum
                int maximumDistance = distanceToCup + 200;

                Console.WriteLine("****** Golf game *******");
                Console.WriteLine("\nInitial distance to cup is: " + distanceToCup + " m");
                Console.WriteLine("Maximum number of swings are: " + maxNumberOfSwings);



                try
                {
                    while (keepAlive)
                    {

                        Console.Write("Please enter an angle: ");
                        int angle = int.Parse(Console.ReadLine());
                        Console.Write("Please enter velocity: ");
                        int velocity = int.Parse(Console.ReadLine());
                        angleInRadians = Math.PI / 180 * angle;
                        //how long distance for the swing based on the inputdata angle and velocity from user
                        distance = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angleInRadians);

                        if (distance > maximumDistance)
                        {
                            throw new CustomException("The length of you swing extended maximumlength! ");
                        }

                        swingDistance.Add((int)distance); //add the distance of the swing to the list for later presentation

                        if ((int)distance > distanceToCup) //the users swing was to long, look at the distance as an integer
                        {
                            //the distance to the cup can't be negative, the absolut of the distance will give how much to long the users swing was
                            distance = Math.Abs(distance);
                            Console.WriteLine("\nDistance of your swing was: " + distance + " m");

                            //the new distance to cup will be distance minus the old distanceToCup since the users swing were longer than the target
                            distanceToCup = (int)distance - distanceToCup; //convert to integer, don't want to guess all the decimals in an double...

                        }
                        else
                        {
                            //calculate how long it's to the target after the users swing
                            Console.WriteLine("\nDistance of your swing was: " + distance + " m");
                            distanceToCup = distanceToCup - (int)distance;

                        }


                        //the user has hit the target, the game will end
                        if (distanceToCup == 0)
                        {
                            keepAlive = false; //no need to swing anymore target reached
                        }
                        else
                        {
                            Console.WriteLine("\nNew distance to cup is: " + distanceToCup + " m\n"); //write the new distance to cup for the user


                        }

                        numberOfSwings++;  //increment the number of swings needed
                        Console.WriteLine("Number of swings: " + numberOfSwings);

                        if (numberOfSwings == maxNumberOfSwings)
                        {

                            throw new CustomException("Maximum number of swings reached! ");

                        }

                    }


                    Console.WriteLine("\nCongratulations, the ball is in the cup! ");  //the ball is in the cup
                    Console.WriteLine("Number of swings: " + numberOfSwings); //total number of swings needed
                    foreach (var item in swingDistance)
                    {
                        Console.WriteLine("Distance of swings: " + item); //print out the distans of all swings needed
                    }
                    Console.ReadKey();

                }
                catch (CustomException e)
                {

                    Console.WriteLine(e.Message); //print the exception message to the user
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                Console.Write("Do yo want to play again? (y) for yes and (n) for no: ");
                if(Console.ReadLine() == "n")
                {
                    alive = false;
                }
                else
                {
                    swingDistance.Clear();
                    Console.Clear();
                }

            }


        }

        /// <summary>
        /// Sets the maximum number of swings depending on the distanceToCup
        /// </summary>
        /// <param name="distanceToCup"></param>
        /// <returns>int</returns>
        private static int SetMaximumNumberOfSwings(int distanceToCup)
        {
            return distanceToCup / 100 + 1;
        }

        /// <summary>
        /// Method for setting the distance to cup
        /// </summary>
        /// <returns>int</returns>
        private static int SetDistanceToCup()
        {
            int distanceToCup;
            Random rand = new Random();
            distanceToCup = rand.Next(400, 600); //genereate a random distance between 400 and 600.
            return distanceToCup;
        }

        /// <summary>
        /// Method for determine if the input text from user can be converted to a double
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns>bool</returns>
        private static bool CanBeConverted(string inputText)
        {

            double convertTo = 0.0;

            if (double.TryParse(inputText, out convertTo))
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for converting the input text from user to a double.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns>double</returns>
        private static double ConvertToDouble(string inputText)
        {
            double convertedDouble = double.Parse(inputText);
            return convertedDouble;
        }
    }
}


