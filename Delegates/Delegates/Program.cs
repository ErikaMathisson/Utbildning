using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void Writer(string message);


        static void Main(string[] args)
        {

            //Console.WriteLine("Write a message");
            //string message = Console.ReadLine();


            //Logger logger = new Logger();
            //Writer writer = new Writer(logger.WriteMessage);
            //writer(message);
            //Console.ReadKey();


            Del handler = DelegateMethod;
            handler("Hello World!");

            Console.ReadKey();

        }


        public delegate void Del(string message);

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
           
        }         

    }
}
