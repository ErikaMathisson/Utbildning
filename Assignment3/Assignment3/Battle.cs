using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Battle
    {


        private Battle()
        {
            rounds = new List<Round>();

        }

        /// <summary>
        /// The character of the battle
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// The opponent of the battle
        /// </summary>
        public Character Opponent { get; set; }


        /// <summary>
        /// For keeping track of which round it is in the battle
        /// </summary>
        public int roundNumber { get; set; }


        /// <summary>
        /// A list of all rounds taken for a battle
        /// </summary>
        public List<Round> rounds { get; set; }

        public Battle(Character character, Character opponent):this()
        {

            this.Character = character;
            this.Opponent = opponent;
            
        }






    }
}
