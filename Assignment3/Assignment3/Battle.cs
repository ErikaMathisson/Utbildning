using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Battle
    {

        /// <summary>
        /// Battle constructor with a list of rounds
        /// </summary>
        private Battle()
        {
            rounds = new List<Round>();

        }

        /// <summary>
        /// The player in the battle
        /// </summary>
        public Character Player { get; set; }

        /// <summary>
        /// The opponent in the battle
        /// </summary>
        public Character Opponent { get; set; }
              
        /// <summary>
        /// For keeping track of which round it is in the battle
        /// </summary>
        public int roundNumber { get; set; }
        
        /// <summary>
        /// A list of all rounds in the battle
        /// </summary>
        public List<Round> rounds { get; set; }

        /// <summary>
        /// Main constructor for battle
        /// </summary>
        /// <param name="player">the player of type character</param>
        /// <param name="opponent">the opponent of type character</param>
        public Battle(Character player, Character opponent):this()
        {
            this.Player = player;
            this.Opponent = opponent;            
        }
    }
}
