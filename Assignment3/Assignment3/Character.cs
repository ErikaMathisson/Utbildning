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
        /// Constructor for Character with new list of battles
        /// </summary>
        private Character()
        {
            battles = new List<Battle>();

        }

        /// <summary>
        /// Main constructor for the character
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <param name="strength">The strength of the character(random value)</param>
        /// <param name="health">The health of the character (random value)</param>
        /// <param name="isOpponent">Bool parameter if the user is the opponent or not</param>
        public Character(string name, int strength, int health, bool isOpponent):this()
        {
            this.Name = name;
            this.Strength = strength;
            this.Health = health;
            this.Damage = strength / 2;
            this.isAlive = true;
            this.IsOpponent = isOpponent;
        }

        /// <summary>
        /// The score a player gets for every win
        /// </summary>
        public const int ScoreWin = 3;

        /// <summary>
        /// A list of all battles performed by the player
        /// </summary>
        public List<Battle> battles { get; set; }

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
        /// Is the character an opponent or not
        /// </summary>
        public bool IsOpponent { get; set; }

        /// <summary>
        /// The  player gets a score for every win
        /// </summary>
        public int Score { get; set; }

    }
}
