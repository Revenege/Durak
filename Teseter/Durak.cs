/**
 * The following class handles the game logic for the game Durak
 * AUTHOR: Scott Jenkins, Thomas Sinka
 * Date: 2020-02-10
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameProject;

namespace GameClient
{
    public class Durak
    {
        /// <summary>
        /// Current card position in the deck
        /// </summary>
        private int currentCard;
        /// <summary>
        /// The deck being played
        /// </summary>
        private DurakDeck playDeck;

        /// <summary>
        /// The players in the game
        /// </summary>
        private Player[] players;

        /// <summary>
        /// Cards in the discard pile
        /// </summary>
        private Cards discardedCards;

        /// <summary>
        /// Cards in play and in discard go here
        /// </summary>
        public DurakTable Table = new DurakTable();

        /// <summary>
        /// Max hand size is a standard game of durak
        /// </summary>
        private const int DEFAULT_MAX_HAND_SIZE = 6;

        /// <summary>
        /// Ac max hand size in a small deck, large player game
        /// </summary>
        private int maxHandSize;

        /// <summary>
        /// Max players in a Durak Game 
        /// </summary>
        private const int MAX_PLAYERS = 7; 
        /// <summary>
        /// Minimium number of players in a Durak Game
        /// </summary>
        private const int MIN_PLAYERS = 2;

        /// <summary>
        /// The trump card
        /// </summary>
        private Card trumpCard;

        /// <summary>
        /// Default Constructor
        /// Creates and shuffles a 36 card durak deck
        /// </summary>
        public Durak()
        {
            currentCard = 0;
            playDeck = new DurakDeck();
            playDeck.Shuffle();
            //Sets the trump card to be the top card of the deck
            trumpCard = playDeck.GetCard(currentCard);
            Card.trump = trumpCard.suit;
            //Moves the trump card to the bottom of the deck, per Durak rules
            playDeck.SendToBottom(currentCard);
        }

        /// <summary>
        /// Parameterized Constructor
        /// Creates and shuffles a custom sized durak deck. Can be 20, 36, or 52
        /// </summary>
        /// <param name="deckSize">Desired decksize</param>
        public Durak(int deckSize)
        {
            currentCard = 0;
            playDeck = new DurakDeck(deckSize);
            playDeck.Shuffle();
            //Sets the trump card to be the top card of the deck
            trumpCard = playDeck.GetCard(currentCard);
            Card.trump = trumpCard.suit;
            //Moves the trump card to the bottom of the deck, per Durak rules
            playDeck.SendToBottom(currentCard);
        }

        /// <summary>
        /// Get the suit that is the trump
        /// </summary>
        /// <returns></returns>
        public String TrumpSuit()
        {
            return Card.trump.ToString();
        }

        /// <summary>
        /// Sets the number of players in the game
        /// </summary>
        /// <param name="newPlayers">A new player object sized to the number of desired players</param>
        public void SetPlayers(Player[] newPlayers)
        {
            //If not enough players, throw an error
            if (newPlayers.Length < MIN_PLAYERS)
                throw new ArgumentException(
                   "A minimum of "+MIN_PLAYERS+" players may play this game.");

            //if too many players, throw an error
            if (newPlayers.Length > MAX_PLAYERS)
                throw new ArgumentException(
                    "A maximum of " + MAX_PLAYERS + " players may play in a 20 card game.");

            players = newPlayers;
        }

        public bool DrawCard(Player currentHand)
        {
            if (playDeck.RemainingCardCount() > 0)
            {
                Card draw = playDeck.GetCard(0);
                if (currentHand.PlayHand.Count < maxHandSize)
                {
                    currentHand.PlayHand.Add(draw);
                    playDeck.RemoveCard(0);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deals a hand to each player
        /// </summary>
        public void DealHands()
        {
            int handSize = 0;
            //Used to determine the max hand size for small deck games with many players
            //For example, in a 36 card game with 7 players, in order to keep the starting hand sizes the same we divide 36/7 and round down, to 5.
            int remainingCardsInDeck = playDeck.deckSize % players.Length;
            handSize = (playDeck.deckSize-remainingCardsInDeck) / players.Length;
            //If the hand size is greater than the max, we simply set it to the max allowable hand size
            if (handSize > DEFAULT_MAX_HAND_SIZE)
            {
                handSize = DEFAULT_MAX_HAND_SIZE;
            }

            maxHandSize = handSize;

            //For each player in the array,
            for (int p = 0; p < players.Length; p++)
            {
                //Generate cards until the max hand size is reached
                for (int c = 0; c < maxHandSize; c++)
                {
                    DrawCard(players[p]);
                }
            }
        }

        public void Attack(Player attacker, Card selectedCard)
        {
            Cards playHand = attacker.PlayHand;
            playHand.Remove(selectedCard);
            Table.InPlay.Add(selectedCard);
        }

        /// <summary>
        /// A Player defending against the cards on the table
        /// </summary>
        /// <param name="Defender">Defending Player</param>
        public bool Defend(Player defender, Card selectedCard)
        {
            //variable declarations
            Cards playHand = defender.PlayHand;
            Card attackingCard = Table.LastPlayed();
            bool successfulDefend = false;

            if (selectedCard > attackingCard)
            {
                successfulDefend = true;
                playHand.Remove(selectedCard);
                Table.InPlay.Clear();
            }
            return successfulDefend;
        }

        /// <summary>
        /// Allows attacker to attack with another card after defender defends
        /// Not used in this version
        /// </summary>
        /// <param name="attacker"></param>
        public void ThrowIn(Player attacker)
        {


        }
        /// <summary>
        /// Draws cards until hand is equal to the max hand size. The max hand size is based on the starting handsize
        /// Required to be called at the end of each turn
        /// </summary>
        public void DrawToMax()
        {
            if (playDeck.RemainingCardCount() > 0)
            {
                foreach (Player player in players)
                {
                    bool atMax = false;
                    while (atMax == false)
                    {
                        if (player.PlayHand.Count() < maxHandSize)
                        {
                            if(DrawCard(player) == false)
                            {
                                atMax = true;
                            }
                        }
                        else
                        {
                            atMax = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The defender can choose to not defend, and take the cards on the table instead
        /// </summary>
        public void TakeCards(Player defender) {
            defender.PlayHand.AddRange(Table.InPlay);
            Table.InPlay.Clear();
        }

        /// <summary>
        /// Determines if a player has won. In a game of Durak this is when there are no cards in the deck, and a player has no cards remaining
        /// after there turn has ended. 
        /// TODO: Make work
        /// </summary>
        /// <returns></returns>
        public void DetermineWinner(Player player)
        {
            if (playDeck.RemainingCardCount() == 0)
            {
                if (player.PlayHand.Count() == 0)
                {
                    player.WinStatus = true;
                }
            }
            else
            {
                player.WinStatus = false;
            }
        }

        /// <summary>
        /// Show the cards in a Player's hand. For testing purposes
        /// </summary>
        public String ShowHand(Player player) 
        {
            String output = (player.Name + "'s hand: \n");
            for (int cardIndex = 0; cardIndex < player.PlayHand.Count; cardIndex++)
            {
                output +=("\n"+cardIndex+" "+player.PlayHand[cardIndex]);
            }
            return output;
        }

        /// <summary>
        /// Returns minimum possible players
        /// </summary>
        /// <returns></returns>
        public static int GetMinPlayers()
        {
            return MIN_PLAYERS;
        }

        /// <summary>
        /// Returns maxmum possible players
        /// </summary>
        /// <returns></returns>
        public static int GetMaxPlayers()
        {
            return MAX_PLAYERS;
        }

        public int GetCardsRemaining()
        {
            return playDeck.RemainingCardCount();
        }
    }
}
