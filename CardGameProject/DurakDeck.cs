/**
 * The following class creates a deck for the card game Durak
 * AUTHOR: Scott Jenkins
 * Date: 2020-02-10
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    public class DurakDeck : Deck
    {
        /// <summary>
        /// Default constructor. By default, Durak is played with a 36 card deck
        /// </summary>
        public DurakDeck() :  base(36)
        {
            Card.isAceHigh = true;
            Card.useTrumps = true;
        }

        /// <summary>
        /// Parameterized Constructor. Durak can be played with a 52 card deck, or a 20 card deck
        /// </summary>
        /// <param name="deckSize"></param>
        public DurakDeck(int deckSize) :base(deckSize)
        {
            Card.isAceHigh = true;
            Card.useTrumps = true;
        }
    }
}
