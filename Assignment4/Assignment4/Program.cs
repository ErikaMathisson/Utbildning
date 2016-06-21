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
                   
            List<Product> products = new List<Product>();

            Product product = new Drinks("Water", 14, products.Count + 1);
            products.Add(product);
            product = new Drinks("Juice", 18, products.Count + 1);
            products.Add(product);
            product = new Fruit("Banana", 8, products.Count + 1);
            products.Add(product);
            product = new Fruit("Apple", 7, products.Count + 1);
            products.Add(product);
            product = new Snacks("Chips", 28, products.Count + 1);
            products.Add(product);
            product = new Snacks("Chocolate", 26, products.Count + 1);
            products.Add(product);

            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine("\nWELCOME TO THE VENDING MACHINE\n");
                Console.WriteLine($"Your credit is: {user.MoneyPool}\n");
                Console.WriteLine("Adding money------------------------ (a)");
          //      Console.WriteLine("Information about product ---------- (i)");
                Console.WriteLine("Buy product ------------------------ (b)");
                Console.WriteLine("Finished --------------------------- (f)\n");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":                          
                        user.AddMoney(vendingMachine);                        
                        break;
                    //case "i":
                    //    Console.WriteLine("case information");
                    //    vendingMachine.ExamineProduct(products);
                    //    Console.ReadKey();
                    //    break;
                    case "b":
                        Console.WriteLine("case buy");
                        vendingMachine.BuyProduct(products, user);

                   //     vendingMachine.ExamineProduct(products);
                        break;
                    case "f":
                        vendingMachine.ReturnMoney(user);                        
                        keepAlive = false;
                        Console.WriteLine("\nThank you for using the vending machine!");
                        Console.WriteLine("\nPress any key...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Not a valid option, press any key... ");
                        Console.ReadKey();
                        break;
                }
            }            

        }

    }
}
