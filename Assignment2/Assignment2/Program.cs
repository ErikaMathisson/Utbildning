﻿using System;
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
            double distance = 0;
            string userAngle = "";
            string userVelocity = "";
            bool keepAlive = true;
            bool alive = true;

            while (alive)
            {
                List<double> swingDistance = new List<double>(); //list for all swings for later presentation
                int numberOfSwings = 0;


                //double distanceToCup = SetDistanceToCup(); //set the distance to the cup

                double distanceToCup = 640;
                int maxNumberOfSwings = SetMaximumNumberOfSwings(distanceToCup); //determine how many swings that are maximum
                int maximumDistance = (int)distanceToCup + 200; //set the maximum distance the user can swing before exception

                Console.ForegroundColor = ConsoleColor.Green; //print the main menu in green
                Console.WriteLine("****** Golf game *******");
                Console.WriteLine("\nInitial distance to cup is: " + distanceToCup + " m");
                Console.WriteLine("Maximum number of swings are: " + maxNumberOfSwings);
                Console.ForegroundColor = ConsoleColor.White; //set the text in white

                try
                {
                    while (keepAlive)
                    {
                        double angle;
                        double velocity;

                        Console.Write("\nPlease enter an angle: ");
                        userAngle = Console.ReadLine(); //angle input from user in format string
                        // validates if the angle can be converted to double, if it can't be converted, make the user enter a new angle until it can
                        while (!CanBeConverted(userAngle))
                        {
                            Console.WriteLine("Not a valid number entered!");
                            Console.Write("Please enter an angle: ");
                            userAngle = Console.ReadLine();
                        }

                        angle = ConvertToDouble(userAngle); //convert the angle from user from string to double

                        if (angle < 0) // the angle can't be of negative value, convert to abs value instead
                        {
                            Console.WriteLine("The angle can't be negative, will convert it to a positive number!");
                            angle = Math.Abs(angle);
                        }

                        Console.Write("Please enter velocity (m/s): ");
                        userVelocity = Console.ReadLine(); //velocity input from user in format string
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

                        distance = CalculateDistance(angle, velocity, gravity); //calculate the distance for the swing
                        swingDistance.Add(distance); //add the distance of the swing to the list for later presentation

                        //checks if the distance of the swing is longer than maximumdistance
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
                            keepAlive = false; //no need to swing anymore target reached

                            Console.ForegroundColor = ConsoleColor.Yellow; //set the color for victory
                            Console.WriteLine("\nCongratulations, the ball is in the cup! ");  //the ball is in the cup
                            Console.WriteLine("Your total number of swings: " + numberOfSwings); //total number of swings needed
                            Console.WriteLine("Maximum number of swings allowed: " +maxNumberOfSwings); //maximum number of swings

                            for (int i = 0; i < swingDistance.Count; i++)
                            {
                                Console.WriteLine("Swing number: " +$"{i+1}" +" was: " +swingDistance[i] + " m");
                           
                            }


                            Console.ForegroundColor = ConsoleColor.White; //reset the text color
                     //       Console.ReadKey();



                        }
                        else if (numberOfSwings == maxNumberOfSwings)
                        {

                            Console.WriteLine("Distance to cup is: " + distanceToCup + " m");
                            Console.WriteLine("Number of swings: "+numberOfSwings);
                            throw new CustomException("Maximum number of swings reached and you didn't reach the goal! ");

                        }
                        else
                        {
                            distanceToCup = Math.Round(distanceToCup, 2);

                       
                            Console.WriteLine("New distance to cup is: " + distanceToCup + " m"); //write the new distance to cup for the user
                            Console.WriteLine("Number of swings: " + numberOfSwings);


                        }
                                                                   
                      
              //          Console.WriteLine("Number of swings: " + numberOfSwings);                     

                    }


                    //Console.WriteLine("\nCongratulations, the ball is in the cup! ");  //the ball is in the cup
                    //Console.WriteLine("Number of swings: " + numberOfSwings); //total number of swings needed
                    //foreach (var item in swingDistance)
                    //{
                    //    Console.WriteLine("Distance of swings: " + item); //print out the distans of all swings needed
                    //}
               //     Console.ReadKey();

                }
                catch (CustomException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //set the error text to red

                    Console.WriteLine(e.Message); //print the exception message to the user
                    Console.ForegroundColor = ConsoleColor.White; //reset the text color
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                Console.Write("Do yo want to play again? (y) for yes and (n) for no: ");
                if (Console.ReadLine() == "n")
                {
                    alive = false;
                }
                else
                {
                    swingDistance.Clear();
                    keepAlive = true;
                    Console.Clear();
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


    }
}


