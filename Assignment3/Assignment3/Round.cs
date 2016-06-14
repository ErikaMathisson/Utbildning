using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Round
    {

        public Round()
        {
                
        }

        /// <summary>
        /// The roll for the character
        /// </summary>
        public int CharacterRoll { get; set; }

        /// <summary>
        /// The roll for the opponent
        /// </summary>
        public int OpponentRoll { get; set; }

        /// <summary>
        /// For keeping track of who won this round
        /// </summary>
        public bool CharacterWon { get; set; }


    }
}
