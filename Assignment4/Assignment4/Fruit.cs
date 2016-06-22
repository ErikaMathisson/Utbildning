using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Fruit : Product
    {
        /// <summary>
        /// Empty constructor for fruit
        /// </summary>
        public Fruit()
        {

        }

        /// <summary>
        /// Constructor for setting parameters for a fruit
        /// </summary>
        /// <param name="name">name of the fruit</param>
        /// <param name="price">price of the fruit</param>
        /// <param name="id">id for the fruit</param>
        public Fruit(string name, int price, int id)
        {
            this.itemName = name;
            this.itemPrice = price;
            this.itemId = id;
        }

        /// <summary>
        /// Method for examine a fruit
        /// </summary>
        /// <param name="p">the fruit who should be examined</param>
        public override void Examine(Product p)
        {
            Console.WriteLine("Id = {0}, Product = {1}, Price = {2}", p.itemId, p.itemName, p.itemPrice);
        }

        /// <summary>
        /// Method for purchasing a fruit
        /// </summary>
        /// <param name="p">fruit that should be purchased</param>
        public override void Purchase(Product p)
        {
            Console.WriteLine($"You purchased fruit: {p.itemName}");
        }
        /// <summary>
        /// Method for using a fruit
        /// </summary>
        /// <param name="p">the fruit that should be used</param>
        public override void Use(Product p)
        {
            Console.WriteLine($"Eat the fruit, {p.itemName}");

        }
    }

}
