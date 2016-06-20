using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepAlive = true;
            User user = new User();
            VendingMachine vendingMachine = new VendingMachine();

            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine("\nWELCOME TO THE VENDING MACHINE\n");
                Console.WriteLine($"Your credit is: {user.MoneyPool}\n");
                Console.WriteLine("Adding money------------------------ (a)");
                Console.WriteLine("Information about product ---------- (i)");
                Console.WriteLine("Buy product ------------------------ (b)");
                Console.WriteLine("Finished --------------------------- (f)");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":                          
                        user.AddMoney(vendingMachine);                        
                        break;
                    case "i":
                        Console.WriteLine("case information");
                        break;
                    case "b":
                        Console.WriteLine("case buy");
                        break;
                    case "f":
                        vendingMachine.ReturnMoney(user);                        
                        keepAlive = false;
                        Console.WriteLine("\nThank you for using the vending machine!");
                        Console.WriteLine("\nPress any key...");
                        break;
                    default:
                        Console.WriteLine("Not a valid option, press any key... ");
                        Console.ReadKey();
                        break;
                }
            }

            Console.ReadKey();

        }

    }
}
