using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    abstract class Product
    {
        //price of the product
        public int itemPrice;
        //name of the product
        public string itemName;
        //id of the product
        public int itemId;
        //abstract method for purchasing a product
        public abstract void Purchase(Product p);              
        //abstract method for examine a product
        public abstract void Examine(Product p);
        //abstract method for using a product
        public abstract void Use(Product p);  

    }
}
