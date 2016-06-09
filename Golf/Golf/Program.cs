using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            double gravity = 9.8;
            double distance = 0;
            string userAngle = "";
            string userVelocity = "";
            bool innerAlive = true;
            bool outerAlive = true;
            double angle;
            double velocity;

            while (outerAlive) //while for starting a new game after the first game has been run
            {
                List<double> swingDistance = new List<double>(); //list for all swings for later presentation
                int numberOfSwings = 0; //no swings have been made
                double distanceToCup = SetDistanceToCup(); //set the distance to the cup
                int maxNumberOfSwings = SetMaximumNumberOfSwings(distanceToCup); //determine how many swings that are maximum
                int maximumDistance = (int)distanceToCup + 200; //set the maximum distance the user can swing before exception

                Console.ForegroundColor = ConsoleColor.Green; //print the main menu in green
                Console.WriteLine("****** Golf game *******");
                Console.WriteLine("\nInitial distance to cup is: " + distanceToCup + " m");
                Console.WriteLine("Maximum number of swings are: " + maxNumberOfSwings);
                Console.ForegroundColor = ConsoleColor.White; //set the text in white

                try
                {
                    //loop for playing until goal is reached or an exception has occured
                    while (innerAlive)
                    {
                        Console.Write("\nPlease enter an angle: ");
                        userAngle = Console.ReadLine(); //angle input from user in format string
                        //validates the user angle input and converts to double
                        angle = ValidateConvertAngle(userAngle);

                        Console.Write("Please enter velocity (m/s): ");
                        userVelocity = Console.ReadLine(); //velocity input from user in format string  
                        //validates the user velocity input and converts to double               
                        velocity = ValidateConvertVelocity(userVelocity);
                        //calculate the distance for the swing
                        distance = CalculateDistance(angle, velocity, gravity);
                        //add the distance of the swing to the list for later presentation
                        swingDistance.Add(distance);

                        //checks if the distance of the swing is longer than maximum distance
                        if (distance > maximumDistance)
                        {
                            throw new CustomException("The length of you swing extended maximumlength! ");
                        }
                        else if (distance > distanceToCup)
                        {
                            //the distance to the cup can't be negative, the absolut of the distance will give how much to long the users swing was
                            distance = Math.Abs(distance);
                            Console.WriteLine("Distance of your swing was: " + distance + " m");
                            //the new distance to cup will be distance minus the old distanceToCup since the users swing were longer than the target
                            distanceToCup = distance - distanceToCup;
                        }
                        else
                        {
                            //calculate how long it's to the target after the users swing
                            Console.WriteLine("Distance of your swing was: " + distance + " m");
                            distanceToCup = distanceToCup - distance;
                        }

                        numberOfSwings++;  //increment the number of swings used

                        //the distance to cup is smaller than 0.2 (the size of the cup) -> the user has hit the target, the game will end
                        if (distanceToCup < 0.2)
                        {
                            innerAlive = false; //no need to try anymore target reached

                            Console.ForegroundColor = ConsoleColor.Yellow; //set the color for victory
                            Console.WriteLine("\nCongratulations, the ball is in the cup! ");  //the ball is in the cup
                            Console.WriteLine("Your total number of swings: " + numberOfSwings); //total number of swings needed
                            Console.WriteLine("Maximum number of swings allowed: " + maxNumberOfSwings); //maximum number of swings
                            //print how long every swing was
                            for (int i = 0; i < swingDistance.Count; i++)
                            {
                                Console.WriteLine("Swing number: " + $"{i + 1}" + " was: " + swingDistance[i] + " m");
                            }

                            Console.ForegroundColor = ConsoleColor.White; //reset the text color                            
                        }
                        else if (numberOfSwings == maxNumberOfSwings) //the maximum number of swings has been reached
                        {
                            Console.WriteLine("Distance to cup is: " + distanceToCup + " m");
                            Console.WriteLine("Number of swings: " + numberOfSwings);
                            throw new CustomException("Maximum number of swings reached and you didn't reach the goal! ");

                        }
                        else
                        {
                            //set the new distance to cup, round up to two decimals
                            distanceToCup = Math.Round(distanceToCup, 2);
                            Console.WriteLine("New distance to cup is: " + distanceToCup + " m"); //write the new distance to cup for the user
                            Console.WriteLine("Number of swings: " + numberOfSwings); //print out the number of swings
                        }

                    }

                }
                catch (CustomException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //set the error text to red
                    Console.WriteLine(e.Message); //print the exception message to the user
                    Console.ForegroundColor = ConsoleColor.White; //reset the text color
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                finally
                {
                    //another game?
                    Console.Write("Do yo want to play again? (y) for yes and (n) for no: ");
                    //the user don't want to play again, exit the program
                    if (Console.ReadLine() == "n")
                    {
                        outerAlive = false;
                    }
                    else
                    {
                        swingDistance.Clear(); //clears the list for another game
                        innerAlive = true;
                        Console.Clear(); //clear the console
                    }
                }

            }
        }

        /// <summary>
        /// Sets the maximum number of swings depending on the distanceToCup
        /// </summary>
        /// <param name="distanceToCup">The distance to the cup</param>
        /// <returns>int</returns>
        private static int SetMaximumNumberOfSwings(double distanceToCup)
        {
            return (int)distanceToCup / 100 + 1;
        }

        /// <summary>
        /// Method for setting the distance to cup
        /// </summary>
        /// <returns>int</returns>
        private static int SetDistanceToCup()
        {
            Random rand = new Random();
            int distanceToCup = rand.Next(400, 600); //genereate a random distance between 400 and 600.
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
        /// <param name="inputText">Text entered from user</param>
        /// <returns>double</returns>
        private static double ConvertToDouble(string inputText)
        {
            double convertedDouble = double.Parse(inputText);
            return convertedDouble;
        }

        /// <summary>
        /// Method for calculating the swing distance
        /// </summary>
        /// <param name="angle">Angle, input from user</param>
        /// <param name="velocity">Velocity input from user</param>
        /// <param name="gravity">Constant for gravity</param>
        /// <returns>double</returns>
        private static double CalculateDistance(double angle, double velocity, double gravity)
        {
            double angleInRadians = Math.PI / 180 * angle; //calculate the angle in radians based on input from user
            //how long distance for the swing based on the inputdata angle and velocity from user
            double distance = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angleInRadians);
            distance = Math.Round(distance, 2); //sets the distance to have two decimals

            return distance;
        }

        /// <summary>
        /// Validates the user input for angle and convert it to double
        /// </summary>
        /// <param name="userAngle">Input from user in format string</param>
        /// <returns>double</returns>
        private static double ValidateConvertAngle(string userAngle)
        {
            // validates if the angle can be converted to double, if it can't be converted, make the user enter a new angle until it can
            while (!CanBeConverted(userAngle))
            {
                Console.WriteLine("Not a valid number entered!");
                Console.Write("Please enter an angle: ");
                userAngle = Console.ReadLine();
            }

            double angle = ConvertToDouble(userAngle); //convert the angle from user from string to double
            // the angle can't be of negative value, convert to abs value instead
            if (angle < 0)
            {
                Console.WriteLine("The angle can't be negative, will convert it to a positive number!");
                angle = Math.Abs(angle);
            }

            return angle;
        }

        /// <summary>
        /// Validates the user input for velocity and convert it to double
        /// </summary>
        /// <param name="userVelocity">Input from user in format string</param>
        /// <returns>double</returns>
        private static double ValidateConvertVelocity(string userVelocity)
        {
            double velocity;
            //validates if the velocity can be converted to double, if it can't be converted, make the user enter a new velocity until it can
            while (!CanBeConverted(userVelocity))
            {
                Console.WriteLine("Not a valid number entered!");
                Console.Write("Please enter a velocity (m/s): ");
                userVelocity = Console.ReadLine();
            }

            velocity = ConvertToDouble(userVelocity); //convert the velocity from string to double

            if (velocity < 0) //the velocity can't be negative, convert to abs value instead
            {
                Console.WriteLine("The velocity can't be negative, will convert it to a positive number!");
                velocity = Math.Abs(velocity);
            }

            return velocity;

        }


    }
}



