using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

/// <summary>
/// Represent Card Object
/// Author: Scott Jenkins
/// Date: 2020-02-06
/// </summary>
namespace CardGameProject
{
    public class Card : ICloneable
    {
        #region MEMBER VARIABLES
        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = false;

        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;

        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        /// <summary>
        /// Flag that determines whether the card is face up or face down.
        /// </summary>
        public bool isFaceUp;

        /// <summary>
        /// Stores the suit of the card
        /// </summary>
        public Suit suit;

        /// <summary>
        /// Stores the rank of the card
        /// </summary>
        public Rank rank;

        /// <summary>
        /// Stores a shortform of the card consisting of the first letter of the suit, and the number or first letter of the rank
        /// </summary>
        public string shortForm = "";
        #endregion VARIABLES


        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Card()
        {
            suit = Suit.Club;
            rank = Rank.Ace;
            isFaceUp = false;
            makeShortForm();
        }


        /// <summary>
        /// Creates a card based on passed values
        /// </summary>
        /// <param name="newSuit">Desired suit</param>
        /// <param name="newRank">Desired rank</param>
        public Card(Suit newSuit, Rank newRank, Boolean faceUp)
        {
            suit = newSuit;
            rank = newRank;
            isFaceUp = faceUp;
            makeShortForm();
        }
        #endregion

        #region OPERATOR OVERLOADS


        /// <summary>
        /// Overrides the equality operator, checking if there rank and suit are the same
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if equal, False if not</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        /// <summary>
        /// Overides the NOT operator.
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if not equal, False if cards are equal</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// Overrides the Equals method, checking if the passed object is equal to the current card
        /// </summary>
        /// <param name="card">Card being checked against the current card</param>
        /// <returns>True if equal, false if not</returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// Creates a hashcode, equal to its suit times its rank.
        /// </summary>
        /// <returns>Calculated hash value</returns>
        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        /// <summary>
        /// Checks if a card is greater than the other
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if left side is greater than right side, False otherwise</returns>
        public static bool operator >(Card card1, Card card2)
        {
            //If the suits are the same
            if (card1.suit == card2.suit)
            {
                //Check if ace is high
                if (isAceHigh)
                {
                    //If ace is high, and the first card is an ace
                    if (card1.rank == Rank.Ace)
                    {
                        //check if the second card is also an ace.
                        //If it is, return false. Otherwise return true
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else //otherwiseha
                    {
                        //check if second card is an ace. If it is, return false.
                        //Otherwise, check if the rank of the first card is higher than the second
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else//otherwise if neither is an ace, check if the first card is greater than the second
                {
                    return (card1.rank > card2.rank);
                }
            }
            else//otherwise,
            {
                if (useTrumps == true)
                {
                    //check if the second card is a trump, and if the second card is a trump.
                    if (card2.suit == Card.trump)
                        return false;
                    //check if the first card is a trump, if the second isn't.
                    else if (card1.suit == Card.trump)
                        return true;
                    else //neither card is trumps and thus the play was illegal
                    {
                        return false;
                    }
                }
                else //otherwise if trumps aren't being used the play was illegal
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Operator override for less than symbol for card.
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if second card is higher, False otherwise </returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        /// <summary>
        /// Operator override for the greater than or equal to symbol
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if the cards are equal, or the First card is greater. False otherwise</returns>
        public static bool operator >=(Card card1, Card card2)
        {
            //check if the suits are the same
            if (card1.suit == card2.suit)
            {
                //if they are, check if ace is high
                if (isAceHigh)
                {
                    //if ace is high, check if either card is an ace
                    //if it is, return appropriately
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        //if neither is an ace, actually check the rank
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else//if aces aren't high, check the rank
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else//otherwise,
            {
                if (useTrumps == true)
                {
                    //check if the second card is a trump, and if the second card is a trump.
                    if (card2.suit == Card.trump)
                        return false;
                    //check if the first card is a trump, if the second isn't.
                    else if (card1.suit == Card.trump)
                        return true;
                    else //neither card is trumps and thus the play was illegal
                    {
                        return false;
                    }
                }
                else //otherwise if trumps aren't being used the play was illegal
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Override of the less than or equal to operator.
        /// Checks if the first card is less than or equal to the second.
        /// </summary>
        /// <param name="card1">First card to check</param>
        /// <param name="card2">Second card to check</param>
        /// <returns>True if the first card is greater than or equal to the second, false otherwise</returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }
        #endregion

        #region OTHER METHODS
        /// <summary>
        /// Clones the Card
        /// </summary>
        /// <returns>The cloned card</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// override default ToString() to output the current card
        /// </summary>
        /// <returns>Formatted string with card info</returns>
        public override string ToString()
        {
            if (isFaceUp)
            {
                return "The " + rank + " of " + suit + "s";
            }
            else
            {
                return "Face Down";
            }
        }

        public void flip()
        {
            isFaceUp = !isFaceUp;
        }

        private void makeShortForm()
        {
            int value = (int)rank;
            string shortSuit = "";
            shortSuit = suit.ToString();
            string rankName = "";

            if (value > 10)
            {
                switch (value)
                {
                    case 11:
                        rankName = "J";
                        break;
                    case 12:
                        rankName = "Q";
                        break;
                    case 13:
                        rankName = "K";
                        break;
                }
            }
            else if ( value == 1)
            {
                rankName = "A";
            }
            else
            {
                rankName = value.ToString();
            }
            shortForm = rankName + shortSuit[0];
        }
        public bool Facing
        {
            set 
            {
                isFaceUp = value;
            }
        }

        public Image GetCardImage()
        {
            string imageName;
            Image cardImage = null;

            if (isFaceUp == false)
            {
                imageName = "Back";
            }
            else
            {
                makeShortForm();
                imageName = shortForm;
            }

            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            return cardImage;

        }
        #endregion
    }
}