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
            int distanceToCup = 500;
            int maximumDistance = 750;
            int maxNumberOfSwings = 10;
            double gravity = 9.8;
            int angle;
            double angleInRadians;
            double distance;
            int velocity;



            Console.WriteLine("****** Golf game *******\n");
            Console.WriteLine("Distance to cup is: "+distanceToCup);
            Console.Write("Please enter an angle: ");
            angle = int.Parse(Console.ReadLine());
            angleInRadians = Math.PI / 180 * angle;

            Console.Write("Please enter velocity: ");
            velocity = int.Parse(Console.ReadLine());
            distance = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angleInRadians);


            Console.WriteLine("Number of meters: "+distance);





            Console.ReadKey();




       // Algorithms:         ○ Angle In Radians: (Math.PI / 180) * angle
       // Distance: Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * angleInRadians)
       //Gravity is equal to 9.8
       //         Example: At 45 Degrees and 56 m / s, the ball should travel 320 meters.




        }
    }
}
