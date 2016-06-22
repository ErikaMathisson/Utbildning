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
            //bool value for using the vending machine more than once
            bool keepAlive = true;
            //user who will use the vending machine
            User user = new User();
            VendingMachine vendingMachine = new VendingMachine();
            //list of products       
            List<Product> products = new List<Product>();
            //add products to the vending machine
            products = vendingMachine.AddProducts(products);         
            //keep the vending machine alive as long as the user wants to
            while (keepAlive)
            {
                //clear the screen and print the menu
                Console.Clear();
                Console.WriteLine("\nWELCOME TO THE VENDING MACHINE\n");
                Console.WriteLine($"Your credit is: {user.MoneyPool}\n");
                Console.WriteLine("Adding money------------------------ (a)");         
                Console.WriteLine("Buy product ------------------------ (b)");
                Console.WriteLine("Finished --------------------------- (f)\n");
                Console.Write("Please enter your choice: ");
                //what the user wants to do
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "a":   
                        //the user wants to add money                       
                        user.AddMoney(vendingMachine);                        
                        break;                    
                    case "b":   
                        //the user wants to buy products                    
                        vendingMachine.BuyProduct(products, user);
                        break;
                    case "f":
                        //the user wants to stop buying and get money back (if exists)
                        vendingMachine.ReturnMoney(user);    
                        //don't need to loop the menu anymore                     
                        keepAlive = false;
                        Console.WriteLine("\nThank you for using the vending machine!");
                        Console.WriteLine("\nPress any key...");
                        Console.ReadKey();
                        break;
                    default:
                        //error message for not entering a valid option
                        Console.WriteLine("Not a valid option, press any key... ");
                        Console.ReadKey();
                        break;
                }
            }            

        }

    }
}
