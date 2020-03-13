/**
 * Represents a deck obect containg cards
 * Author: Scott Jenkins
 * Date: 2020-02-06
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    public class Deck : ICloneable
    {
        /// <summary>
        /// The cards the deck is made up of
        /// </summary>
        private Cards cards = new Cards();

        /// <summary>
        /// Handles when the last card in the deck is drawn
        /// </summary>
        public event EventHandler LastCardDrawn;

        /// <summary>
        /// The size of the deck
        /// </summary>
        public int deckSize;
        
        /// <summary>
        /// Clones a copy of the deck
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        /// <summary>
        /// constructor that takes a Cards object
        /// </summary>
        /// <param name="newCards">Cards object to insert into deck</param>
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        /// <summary>
        /// Constructor for a Default deck of 52 cards
        /// </summary>
        public Deck()
        {
            deckSize = 52;
            //looping over the suit, and than the rank
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal, false));
                }
            }
        }

        /// <summary>
        /// Deck with variable decksize for the purposes of the card game Durak
        /// </summary>
        /// <param name="deckSize">Desired deck size</param>
        public Deck(int deckSize) 
        {
            //Start of the deck. Corresponds to the literal value of the card.
            //Example: deuce = 2.
            int start = 0;

            //If the deck is a valid decksize, set the start value to a correct value.
            if (deckSize == 52 || deckSize == 36 || deckSize == 20)
            {
                if (deckSize == 52)
                {
                    start = 2;
                }
                else if (deckSize == 36)
                {
                    start = 6;
                }
                else if (deckSize == 20)
                {
                    start = 10;
                }
                //set the deckSize correctly
                this.deckSize = deckSize;

                //Setting the cards, starting at the value determined by the deckSize
                //Looping over the suits
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    //looping over the rank cards.
                    for (int rankVal = start; rankVal <= 13; rankVal++)
                    {
                        //Adding the card
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal, false));
                        //if the cardVal is 13, additionally add an Ace
                        if (rankVal == 13)
                        {
                            //adding the ace
                            cards.Add(new Card((Suit)suitVal, (Rank)1, false ));
                        }
                    }
                }
            }
            else
            {
                //throw error if invalid deckSize
                throw new InvalidDeckSizeException("Given deck size is invalid. Only 52, 36, and 20 are Valid");
            }
        }

        /// <summary>
        /// Nondefault constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        /// <summary>
        /// Nondefault constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public void RemoveCard(int cardNum)
        {
            cards.Remove(GetCard(cardNum));
            deckSize = cards.Count();
        }

        /// <summary>
        /// Returns the card at the given number
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            //If there are cards in the deck, and the deck isn't too big 
            if (cardNum >= 0 && cardNum < deckSize)
            {
                //check if its the last card, and that the last card hasn't already been drawn
                if ((cardNum == deckSize-1) && (LastCardDrawn != null))
                {
                    //event for when last card is drawn
                    LastCardDrawn(this, EventArgs.Empty);
                }
                //returning the correct card
                return cards[cardNum];
            }
            else//otherwise, the card requested is outside the bounds of the deck
                throw new CardOutOfRangeException(cards.Clone() as Cards, deckSize);
        }


        public void SendToBottom(int cardNum)
        {
            Card swap = cards[deckSize - 1];
            Card toSwitch = cards[cardNum];
            cards[deckSize - 1] = toSwitch;
            cards[cardNum] = swap;
        }


        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            //Creates a new collection of cards
            Cards newDeck = new Cards();
            //Contains whether the card has changed positions or not
            bool[] assigned = new bool[deckSize];
            //random number generator
            Random sourceGen = new Random();

            //For each card in  the deck, randomize it
            for (int i = 0; i < deckSize; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(deckSize);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            //copy the cards to our deck
            newDeck.CopyTo(cards);
        }

        /// <summary>
        /// Returns the number of cards remaining in the deck
        /// </summary>
        /// <returns>Number of cards in deck</returns>
        public int RemainingCardCount()
        {
            return cards.Count;
        }

    }
}