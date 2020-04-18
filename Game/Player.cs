/**
 * The following class represents a player, and there hand
 * Author: Scott Jenkins, Thomas Sinka
 * Date: 2020-02-10
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameProject;

namespace GameClient
{
    public class Player
    {
        /// <summary>
        /// The players Name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The cards currently in the players hand
        /// </summary>
        public Cards PlayHand { get; private set; }

        /// <summary>
        /// Determines if the player has won
        /// </summary>
        public bool WinStatus { get; set; }

        /// <summary>
        /// Determines if the player is an AI
        /// </summary>
        public bool IsAi { get; set; }

        /// <summary>
        /// Name used for default constructor
        /// </summary>
        private const string DEFAULT_NAME = "Undefined_Name";

        /// <summary>
        /// Default Constructor, calls parameterized 
        /// constructor and passes default player name
        /// </summary>
        public Player() : this(DEFAULT_NAME){}

        /// <summary>
        /// Setting a player name with a default hand
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }

        /// <summary>
        /// Get player information
        /// </summary>
        /// <returns>Player's name</returns>
        public override string ToString() {
            return this.Name;
        }

    }
}
