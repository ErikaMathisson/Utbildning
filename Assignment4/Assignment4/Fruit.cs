using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Fruit : Product
    {
        public Fruit()
        {
           
        }

        public Fruit(string name, int price, int id)
        {
            this.itemName = name;
            this.itemPrice = price;
           this.itemId = id;         

        }

        public override void Examine(Product p)
        {

        //    Console.WriteLine("Examine fruit");

            Console.WriteLine("Id = {0}, Product = {1}, Price = {2}", p.itemId, p.itemName, p.itemPrice);

        }

        public override void Purchase()
        {
            Console.WriteLine("Purchase fruit");
            Console.ReadKey();

        }

        public override void Use(Product p)
        {
            Console.WriteLine("Use");
            Console.WriteLine($"Eat the fruit, {p.itemName}");
            Console.ReadKey();
        }
    }

}
