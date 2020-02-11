using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    /// <summary>
    /// Exception for when too many cards are placed in the deck
    /// </summary>
    public class CardOutOfRangeException : Exception
    {
        /// <summary>
        /// Number of cards in the deck
        /// </summary>
        private Cards deckContents;

        /// <summary>
        /// returns the contents of the deck
        /// </summary>
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        /// <summary>
        /// Exception. Displays the max cards allowed in the deck based on the contents and size of the deck
        /// </summary>
        /// <param name="sourceDeckContents"></param>
        /// <param name="deckSize"></param>
        public CardOutOfRangeException(Cards sourceDeckContents,int deckSize)
           : base("The maximium cards allowed in the deck is "+deckSize)
        {
            deckContents = sourceDeckContents;
        }
    }
}
