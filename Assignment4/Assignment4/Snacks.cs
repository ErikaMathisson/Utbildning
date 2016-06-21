using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Snacks : Product
    {

        public Snacks()
        {

        }

        public Snacks(string name, int price, int id)
        {

            this.itemName = name;
            Console.WriteLine("Name: " + name);
            this.itemPrice = price;
            Console.WriteLine("Price: " + price);
            this.itemId = id;
            Console.WriteLine("Id: " + id);

        }

        public override void Examine(Product p)
        {

     //       Console.WriteLine("Examine snacks");

            Console.WriteLine("Id = {0}, Product = {1}, Price = {2}", p.itemId, p.itemName, p.itemPrice);


        }

        public override void Purchase()
        {
            Console.WriteLine("Purchase snacks");
            Console.ReadKey();

        }

        public override void Use(Product p)
        {
            Console.WriteLine($"Eat the snacks, {p.itemName}");
            Console.WriteLine("Use");
            Console.ReadKey();
        }
    }

}

