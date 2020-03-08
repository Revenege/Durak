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
        /// Determines if a player has won. In a game of Durak this is when there are no cards in the deck, and a player has no cards remaining
        /// after there turn has ended. 
        /// TODO: Make work
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            return false;
        }

        /**
         * TODO: Add IsAI() property which will be used in the future in the gameplay logic
         * to check if a human will be making decisions in the Player's turn, or if an AI 
         * will automatically perform that Player's turn
         */
    }
}
