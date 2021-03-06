﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Round
    {

        /// <summary>
        /// Empty constructor for round
        /// </summary>
        public Round()
        {
                
        }

        /// <summary>
        /// The roll for the player
        /// </summary>
        public int PlayerRoll { get; set; }

        /// <summary>
        /// The roll for the opponent
        /// </summary>
        public int OpponentRoll { get; set; }

        /// <summary>
        /// The total score for the player each round
        /// </summary>
        public int PlayerTotal { get; set; }

        /// <summary>
        /// The total score for the opponent each round
        /// </summary>
        public int OpponentTotal { get; set; }
        
        /// <summary>
        /// Name of the winner each round, can be player name, opponent name or draw
        /// </summary>
        public string NameOfWinner { get; set; }

    }
}
