/**
 * Collection of card objects using a generic collections class
 * Author: Scott Jenkins
 * Date: 2020-06-02
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    public delegate void CardsChangedHandler();

    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Clones a cards object as a soft copy
        /// </summary>
        /// <returns> Cloned Cards collections</returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// Returns the rank and suit of each card in a collection
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            string newString = "";
            foreach (Card sourceCard in this)
            {
                newString += sourceCard.ToString() + "\n";
            }
            return newString;
        }

        //  Events
        public event CardsChangedHandler CardsChanged;

        /// <summary>
        /// Adds a Card to the collection and fires CardsChanged event
        /// </summary>
        /// <param name="card"></param>
        public new void Add(Card card)
        {
            if (CardsChanged != null)
            {
                CardsChanged();
            }

            base.Add(card);
        }

        /// <summary>
        /// Removes a Card to the collection and fires CardsChanged event
        /// </summary>
        /// <param name="card"></param>
        public new void Remove(Card card)
        {
            if (CardsChanged != null)
            {
                CardsChanged();
            }

            base.Remove(card);
        }
    }
}
