using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    abstract class Product
    {
        public int itemPrice;

        public string itemName;

        public int itemId;

        public abstract void Purchase();              

        public abstract void Examine(Product p);

        public abstract void Use(Product p);  

    }
}
