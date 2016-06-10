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

            Console.WriteLine("Write a message");
            string message = Console.ReadLine();


            Logger logger = new Logger();
            Writer writer = new Writer(logger.WriteMessage);
            writer(message);
            Console.ReadKey();




        }


    }
}
