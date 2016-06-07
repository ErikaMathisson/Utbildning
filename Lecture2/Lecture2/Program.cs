using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2
{
    class Program
    {
        static void Main(string[] args)
        {

            //    int[] myArray = new int[4];

            //    myArray[0] = 1;
            //    myArray[1] = 2;
            ////    myArray[2] = 3; //when an array position isn't declared the value will be 0 for int, null for string
            //    myArray[3] = 4;
            //    Array.Resize(ref myArray, 5);
            //    myArray[4] = 342;


            //two dimensional array. The comma indicates how many dimensions
            int[,] myArray = new int[2, 2];

            myArray[0, 0] = 100;
            myArray[0, 1] = 101;
            myArray[1, 0] = 200;
            myArray[1, 1] = 201;

            //myArray.length will in this case be 4. 
            //so for the for-loop below to work, the length needs to be divided by number of dimensions, that is if you only wants to print the first dimension


            for (int i = 0; i < myArray.Length/2; i++)
            {
                Console.WriteLine(myArray[i,0]);

            }



            List<int> firstList = new List<int>();
            firstList.Add(23);
            firstList.Add(12);
            firstList.Add(56);

            firstList.RemoveAt(1); //will remove the element at position 1 that is 12

            // firstList.Remove(12); //will remove element 12 that is at position 12


          

            Console.ReadKey();

            //for (int i = 0; i < myArray.length; i++)
            //{
            //    Console.WriteLine(myArray[i]);

            //}

        }
    }
}
