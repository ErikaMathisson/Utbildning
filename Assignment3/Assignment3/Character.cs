using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Character
    {

        /// <summary>
        /// Empty constructor for Character
        /// </summary>
        public Character()
        {

        }

        /// <summary>
        /// Main constructor for the character
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <param name="strength">The strength of the character(random value)</param>
        /// <param name="health">The health of the character (random value)</param>
        public Character(string name, int strength, int health)
        {
            //if (name.Length != 0 && name != null)
            //{
            this.Name = name;
            //    Console.WriteLine("Konstruktor: " + name);
            //}
            //else
            //{

            //    //todo needs to be handled or maybe another way...

            //    throw new NotValidNameException();

            //}


            this.Strength = strength;
            this.Health = health;
            this.Damage = strength / 2;
            this.isAlive = true;

            //Console.WriteLine("strength " + this.Strength);
            //Console.WriteLine("helth " + this.Health);
            //Console.WriteLine("damage " + this.Damage);




        }




        /// <summary>
        /// Constructor for character that takes a name as input
        /// </summary>
        /// <param name="name">The name of the character</param>
        public Character(string name)
        {
            //if (name.Length != 0 && name != null)
            //{
            //    this.Name = name;
            //    Console.WriteLine("Konstruktor input name: " + name);
            //}
            //else
            //{

            //    //todo needs to be handled or maybe another way...
            //    throw new NotValidNameException();

            //}


            this.Name = name;
            Random rand = new Random();
            this.Strength = rand.Next(1, 8) + 2;
            this.Health = rand.Next(1, 8) + 2;

            

            //invokes a randomgenerator to get the strength
        //    this.Strength = RandomGenerator();
       //     Console.WriteLine("strengh random " + Strength);
            //invokes a randomgenerator to get the health
         //   this.Health = RandomGenerator();
        //    Console.WriteLine("helth random " +Health);
            this.Damage = Strength / 2;

            Console.WriteLine("strength " + this.Strength);
            Console.WriteLine("helth " + this.Health);
            Console.WriteLine("damage " + this.Damage);




        }




        /// <summary>
        /// The name of the character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The health of the character
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The strength of the character
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// The damage the character can give to the opponent
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Is the character still alive
        /// </summary>
        public bool isAlive { get; set; }


        /// <summary>
        /// The strength of the character
        /// </summary>
        //public int Strength{
        //    //get
        //    //{
        //    //    return Strength;
        //    //}

        //    //set
        //  get  {
        //        Random rand = new Random();
        //        int strength = rand.Next(1, 8) + 2;
        //      //  this.Strength = strength;

        //        Console.WriteLine("strength "+strength);
        //        Console.WriteLine("Strength " + Strength);
        //        return strength;

        //    }


        //}

        /// <summary>
        /// The damage the character can distribute to the opponent
        /// </summary>
        //public int Damage{
        //    get{

        //        return Damage; 


        //    }
        //    set
        //    {
        //        this.Damage = Strength/2;
        //        Console.WriteLine("Damage " + Damage);


        //    }
        //}





        //public static int RandomGenerator()
        //{
        //    Random rand = new Random();
        //    int randomValue = rand.Next(1, 8) + 2;
        //    return randomValue;





        //}

    }
}
