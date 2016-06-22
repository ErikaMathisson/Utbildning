using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Drinks : Product
    {
     
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Drinks()
        {
 
        }
        /// <summary>
        /// Constructor for setting parameters to a drink
        /// </summary>
        /// <param name="name">the name of the drink</param>
        /// <param name="price">the price of the drink</param>
        /// <param name="id">the id of the drink</param>
        public Drinks(string name, int price, int id)
        {
           
            this.itemName = name;
            this.itemPrice = price;
            this.itemId = id;          
        }
        
        /// <summary>
        /// Overriden method for examining a drink
        /// </summary>
        /// <param name="p">product who should be examined</param>
        public override void Examine(Product p)
        {   
            //Print information about the drink         
            Console.WriteLine("Id = {0}, Product = {1}, Price = {2}", p.itemId, p.itemName, p.itemPrice);            
        }
        /// <summary>
        /// Method for showing that a drink is purchased
        /// </summary>
        /// <param name="p">the product who should be purchased</param>
        public override void Purchase(Product p)
        {
            //Information that a drink is purchased
            Console.WriteLine($"You purchased drink: {p.itemName}");     

        }

        /// <summary>
        /// Method for using a drink
        /// </summary>
        /// <param name="p">the product that should be used</param>
        public override void Use(Product p)
        {          
            Console.WriteLine($"Drink the drink, {p.itemName}");         
        }
    }
}
