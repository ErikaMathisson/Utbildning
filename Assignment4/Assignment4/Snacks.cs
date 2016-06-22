using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Snacks : Product
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Snacks()
        {

        }
        /// <summary>
        /// Constructor for setting information about snacks
        /// </summary>
        /// <param name="name">name of the snacks</param>
        /// <param name="price">price of the snacks</param>
        /// <param name="id">id of the snacks</param>
        public Snacks(string name, int price, int id)
        {
            this.itemName = name;           
            this.itemPrice = price;          
            this.itemId = id;  
        }

        /// <summary>
        /// Method for examine snacks
        /// </summary>
        /// <param name="p">the snacks who should be examined</param>
        public override void Examine(Product p)
        {
            Console.WriteLine("Id = {0}, Product = {1}, Price = {2}", p.itemId, p.itemName, p.itemPrice);
        }

        /// <summary>
        /// Method for informaiton about purchasing snacks
        /// </summary>
        /// <param name="p">the snacks who should be purchased</param>
        public override void Purchase(Product p)
        {
            Console.WriteLine($"You purchased snacks: {p.itemName}");      
        }

        /// <summary>
        /// Method for using snacks
        /// </summary>
        /// <param name="p">the snacks who should be used</param>
        public override void Use(Product p)
        {
            Console.WriteLine($"Eat the snacks, {p.itemName}");
           
        }
    }

}

