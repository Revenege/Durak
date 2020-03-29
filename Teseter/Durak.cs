/**
 * The following class handles the game logic for the game Durak
 * AUTHOR: Scott Jenkins, Thomas Sinka
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
        DurakTable table = new DurakTable();

        /// <summary>
        /// Max hand size is a standard game of durak
        /// </summary>
        private const int MAX_HAND_SIZE = 6;

        /// <summary>
        /// Max players in a Durak Game 
        /// </summary>
        private const int MAX_PLAYERS = 7; 
        /// <summary>
        /// Minimium number of players in a Durak Game
        /// </summary>
        private const int MIN_PLAYERS = 2; 

        /// <summary>
        /// Default Constructor
        /// Creates and shuffles a 36 card durak deck
        /// </summary>
        public Durak()
        {
            currentCard = 0;
            playDeck = new DurakDeck();
            playDeck.Shuffle();
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

        public void DrawCard(Player currentHand)
        {
            if (playDeck.RemainingCardCount() > 0)
            {
                Card draw = playDeck.GetCard(0);
                if (currentHand.PlayHand.Count < MAX_HAND_SIZE)
                {
                        currentHand.PlayHand.Add(draw);
                        //Console.WriteLine(draw);
                        playDeck.RemoveCard(0);
                        //Console.WriteLine(playDeck.RemainingCardCount());
                        //Console.WriteLine(playDeck.GetCard(0));
                }
            }
        }

        /// <summary>
        /// Deals a hand to each player
        /// </summary>
        private void DealHands()
        {
            int handSize = 0;
            //Divide the decksize by the number of players. Used to determine the max hand size for small deck games with many players
            //For example, in a 36 card game with 7 players, in order to keep the starting hand sizes the same we divide 36/7 and round down, to 5.
            handSize = playDeck.deckSize / players.Length;
            //If the hand size is greater than the max, we simply set it to the max allowable hand size
            if (handSize > MAX_HAND_SIZE)
            {
                handSize = MAX_HAND_SIZE;
            }

            //For each player in the array,
            for (int p = 0; p < players.Length; p++)
            {
                //Generate cards until the max hand size is reached
                for (int c = 0; c < handSize; c++)
                {
                    DrawCard(players[p]);
                }
            }
        }
        /// <summary>
        /// Performs AI's turn
        /// </summary>
        private void AILogic(Player player)
        {

            bool attackFinished = false;
            bool successfulDefend = false;
            char userInput = ' ';
            //Check to see if current AI player is attacking or defending
            //Attacking
            if (player.Name == Players.GetCurrentPlayer().Name)
            {

                Attack(player);
                //loop until attacker ends turn or defender ends turn
                while (!attackFinished)
                {
                    //Defender defend?
                    while (userInput != 'd' && userInput != 'D' && userInput != 't' && userInput != 'T')
                    {
                        ShowHand(Players.PeakNextPlayer());
                        Console.WriteLine(Players.PeakNextPlayer().Name + ": Press \'d\' to defend, or \'t\' to take cards: ");
                        userInput = Console.ReadKey().KeyChar;
                    }
                    //yes
                    if (userInput == 'd' || userInput == 'D')
                    {
                        bool correctInput = false;
                        //ensure valid play. NOTE: if the play CAN'T actually defend, this will trap them in a hellish infinite loop
                        //However since this text game is purely for testing, we wont be fixing it as it wont exist in the main game.
                        while (correctInput == false)
                        {
                            correctInput = Defend(Players.PeakNextPlayer());
                        }
                        successfulDefend = true;
                        attackFinished = true;

                    }
                    //no
                    else
                    {
                        //defender takes cards
                        TakeCards(Players.PeakNextPlayer());
                        attackFinished = true;
                        successfulDefend = false;
                    }
                }//attack ends here

            }
            //defending
            else
            {

            }


        }

        /// <summary>
        /// Gameplay logic for the game Durak
        /// </summary>
        /// <returns></returns>
        public int PlayGame()
        {
            bool gameRunning = true;

            //Sets the trump card to be the top card of the deck
            Card trumpCard = playDeck.GetCard(currentCard);
            Card.trump = trumpCard.suit;

            Players.InitializeGame(players, true);    //  Initialize game, randomize player turn order

            //Moves the trump card to the bottom of the deck, per Durak rules
            playDeck.SendToBottom(currentCard);
            
            //Deals a hand to each player
            DealHands();


            /**
             * TODO: ADD GAME LOGIC
             * DETERMINE WHO GOES FIRST RANDOMLY
             * SHOULD LOOP OVER ALL PLAYERS IN TURN ORDER (top to bottom). FOR NOW ONLY ADD LOGIC FOR 2 PLAYERS
             * DISPLAY THAT PLAYERS HAND
             * LET THE CURRENT TURNS PLAYER PLAY A CARD
             * LET NEXT PLAYER PLAY A CARD TO FIGHT IT
             * IF THE PLAYER HAS NO LEGAL PLAYS, THEY PICK UP THE PLAYED CARD
             * IF THE PLAYER DOES NOT WISH TO BEAT THE CARD, THEY MAY ALSO PICK UP THE CARD
             * IF THE DEFENDING PLAYER LOSES, THERE ATTACK IS SKIPPED
             * IF THE PLAYER SUCCESSFULLY DEFENDS THE ATTACK, ALL CARDS PLAYED ARE DISCARDED
             * AT END OF TURN, EACH PLAYER DRAWS UP TO THERE STARTING HNAD SIZE
             * IF THEY ARE UNABLE TO DRAW, THE DRAW IS SKIPPED
             * IF THE DECK IS EMPTY, AND A PLAYERS HAND IS EMPTY WHEN THEY GO TO DRAW, THEY WIN
             */

            /**
            currentPlayer = Players.GetCurrentPlayer();
            Cards playHand = currentPlayer.PlayHand;
            
            //  Display player's hand
            Console.WriteLine(currentPlayer.Name + "'s hand: \n");
            for (int cardIndex = 0; cardIndex < playHand.Count; cardIndex++)
            {
                Console.WriteLine("[{0}]: {1}", cardIndex, playHand[cardIndex]);
            }

            char input = ' ';
            Console.WriteLine("Enter \"a\" to attack, or \"s\" to skip turn");
            while (input != 'a' && input != 'A' && input != 's' && input != 'S')
            {
                input = Console.ReadKey().KeyChar;
            }

            if (input == 'a')
            {
                Attack(currentPlayer);
                Players.EndTurn();    //  It is now the next player's turn
            }
            else if (input == 's')
            {
                Players.EndTurn();
            }
            **/

            /*
            //  The gameplay logic:

            //loop until one player has no more cards
                //Next player in turn order becomes the attacker
                //Attacker Attack?
                //yes
                    //loop until attacker ends turn or defender ends turn
                        //Defender defend?
                        //yes
                            //successful defend?
                            //yes
                                //attacker throw in?
                                //yes
                                    //play another card
                                //no
                                    //player ends attack
                            //no
                                //defender loses
                        //no
                            //defender takes cards
                    //if defender failed to defend
                        //defender skips next turn
                //no
                    //attacker ends turn
            */

            Player attacker = Players.GetCurrentPlayer();   //  Determine attacker
            Player defender = Players.PeakNextPlayer();     //  Determine defender
            bool attackFinished = false;
            bool successfulDefend = false;
            char userInput = ' ';
            Console.WriteLine("\n\n" + attacker.Name + " goes first.");
            Player theDurak = new Player();

            //loop until one player has no more cards
            while (gameRunning) {
                //Next player in turn order becomes the attacker
                attacker = Players.GetCurrentPlayer();
                //determines if the game has ended
                int winnerCount = 0;
                attackFinished = false;

                Console.WriteLine("The Trump Suit is: " + trumpCard.suit + "\n");
                Console.WriteLine("There are " + playDeck.RemainingCardCount()+ " remaining");
                if (attacker.IsAi == false)
                {
                    //Attacker Attack?
                    while (userInput != 'a' && userInput != 'A' && userInput != 's' && userInput != 'S')
                    {
                        ShowHand(attacker);
                        Console.WriteLine(attacker.Name + ": Press \'a\' to attack, or \'s\' to skip: ");
                        userInput = Console.ReadKey().KeyChar;
                    }
                    //yes
                    if (userInput == 'a' || userInput == 'A')
                    {
                        Attack(attacker);
                        //loop until attacker ends turn or defender ends turn
                        while (!attackFinished)
                        {
                            //Defender defend?
                            while (userInput != 'd' && userInput != 'D' && userInput != 't' && userInput != 'T')
                            {
                                ShowHand(defender);
                                Console.WriteLine(defender.Name + ": Press \'d\' to defend, or \'t\' to take cards: ");
                                userInput = Console.ReadKey().KeyChar;
                            }
                            //yes
                            if (userInput == 'd' || userInput == 'D')
                            {
                                bool correctInput = false;
                                //ensure valid play. NOTE: if the play CAN'T actually defend, this will trap them in a hellish infinite loop
                                //However since this text game is purely for testing, we wont be fixing it as it wont exist in the main game.
                                while (correctInput == false)
                                {
                                    correctInput = Defend(defender);
                                }
                                successfulDefend = true;
                                attackFinished = true;
                                ////attacker throw in? Commented out until further clarification.
                                //while (userInput != 't' && userInput != 'T' && userInput != 'e' && userInput != 'E')
                                //{
                                //    Console.WriteLine(attacker.Name + ": Press \'t\' to throw in, or \'e\' to end attack: ");
                                //    userInput = Console.ReadKey().KeyChar;
                                //}
                                ////yes
                                //if(userInput == 't' || userInput == 'T')
                                //{
                                //    //attacker play another card
                                //    ThrowIn(attacker);
                                //}
                                ////no
                                //else
                                //{
                                //    //player ends attack
                                //    attackFinished = true;
                                //}

                            }
                            //no
                            else
                            {
                                //defender takes cards
                                TakeCards(defender);
                                attackFinished = true;
                                successfulDefend = false;
                            }
                        }//attack ends here

                        //draw up to 7
                        DrawToMax(players);
                        //if the player defended succesfully, process as normal
                        if (successfulDefend)
                        {
                            attacker = Players.GetNextPlayer();
                            defender = Players.PeakNextPlayer();
                        }
                        else //Skip the next players turn first
                        {
                            Players.SkipTurn();
                            attacker = Players.GetNextPlayer();
                            defender = Players.PeakNextPlayer();
                        }

                    }
                    //no
                    else
                    {
                        //attacker ends turn
                        attackFinished = true;
                    }
                }
                else
                {
                    AILogic(Players.GetCurrentPlayer());
                }
                //Count the number of players out of the game
                foreach (Player player in players)
                {
                    DetermineWinner(player);
                    //if the player has won, add to the count
                    if (player.WinStatus == true)
                    {
                        winnerCount++;
                    }
                }
                //if there is only one player remaining, declare them the durak
                if (winnerCount== players.Count() -1)
                {
                    foreach (Player player in players)
                    {
                        if (player.WinStatus == false)
                        {
                            theDurak = player;
                        }
                    }
                    gameRunning = false;
                }

            }

            Console.Out.WriteLine(theDurak.Name +" is the Durak! Better luck next Time");

            /**
             * OPTIONAL: TRANSFERS
             * A TRANSFER OCCURS WHEN A DEFENDING PLAYER MATCHES THE RANK OF THE CURRENTLY PLAYED CARD
             * WHEN A TRANSFER OCCURS, THE NEXT PLAYER IN TURN ORDER MUST BEAT ALL CARDS THAT HAVE NOT BEEN DEFENDED
             * IF A TRANSER IS BEATEN, THE ATTACKER MAY TRANSFER AGAIN, TRANSFERING WITH ANY CARD PLAYED IN THE CURRENT BOUT
             * EXAMPLE: PLAYER 1 PLAYS A 9 OF SPADES. PLAYER 2 PLAYS A 9 OF HEARTS. PLAYER 1 PLAYS A JACK OF SPADES AND A 10 OF HEARTS. 
             * PLAYER 2 MAY TRANSFER WITH A 9, A 10 OR A JACK.
             * IN MULTIPLAYER, ALL PLAYERS EXCEPT THE DEFENDING PLAYER MAY JOIN IN THE ATTACK BY TRANSFERRING. THIS OCCURS IN TURN ORDER
             * IF THE DEFENDER RUNS OUT OF CARDS, OR IF THE NUMBER OF ATTACKS EQUAL THE NUMBER OF CARDS PLAYERS STARTED WITH, THE ATTACK CONCLUDES AND ALL CARDS ARE BURNED
             * THE DEFENDER THAN GETS TO ATTACk
             * DUE TO RELATIVE COMPLEXITY, EITHER MULTIPLE PLAYERS OR TRANSERS SHOULD BE IMPLEMENTED, BUT NOT BOTH.
             */

            return 0;
        }

        public void Attack(Player attacker)
        {
            Cards playHand = attacker.PlayHand;
            Card selectedCard;

            //  If player has 1 or more cards, ask them which one to play
            Console.Write("\n{0}: Select a card between [0] and [{1}]: ", attacker.Name, playHand.Count - 1);
            int selection = ValidateIntSelection(0, playHand.Count - 1);
            selectedCard = playHand[selection];
            playHand.Remove(selectedCard);
            table.InPlay.Add(selectedCard);
            Console.WriteLine("{0} played {1}", attacker.Name, selectedCard.ToString());
        }

        /// <summary>
        /// A Player defending against the cards on the table
        /// </summary>
        /// <param name="Defender">Defending Player</param>
        public bool Defend(Player defender)
        {
            //variable declarations
            Cards playHand = defender.PlayHand;
            Card selectedCard;
            Card attackingCard = table.LastPlayed();
            bool successfulDefend = false;

            Console.Write("\n{0}: Select a card between [0] and [{1}]", defender.Name, playHand.Count - 1);
            int selection = ValidateIntSelection(0, playHand.Count - 1);

            selectedCard = playHand[selection];
            if (selectedCard > attackingCard)
            {
                Console.WriteLine("Success\n");
                successfulDefend = true;
                playHand.Remove(selectedCard);
                table.InPlay.Add(selectedCard);
                Console.WriteLine("{0} played {1}", defender.Name, selectedCard.ToString());
            }
            else
            {
                Console.WriteLine("{0} does not beat {1}. Please try again",selectedCard.ToString(), attackingCard.ToString());
                ShowHand(defender);
            }



            return successfulDefend;
        }

        /// <summary>
        /// Allows attacker to attack with another card after defender defends
        /// </summary>
        /// <param name="attacker"></param>
        public void ThrowIn(Player attacker)
        {


        }
        public void DrawToMax(Player[] players)
        {
            if (playDeck.RemainingCardCount() > 0)
            {
                foreach (Player player in players)
                {
                    bool atMax = false;
                    while (atMax == false)
                    {
                        if (player.PlayHand.Count() < MAX_HAND_SIZE)
                        {
                            DrawCard(player);
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
            Console.WriteLine("Picking up...\n");
            defender.PlayHand.AddRange(table.InPlay);
            table.InPlay.Clear();
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
        /// Show the cards in a Player's hand
        /// </summary>
        private void ShowHand(Player player) 
        {
            Console.WriteLine(player.Name + "'s hand: \n");
            for (int cardIndex = 0; cardIndex < player.PlayHand.Count; cardIndex++)
            {
                Console.WriteLine("[{0}]: {1}", cardIndex, player.PlayHand[cardIndex]);
            }
        }

        /// <summary>
        /// Prompts user for an int input and validates it within a range.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns></returns>
        private int ValidateIntSelection(int min, int max)
        {
            string inputString = string.Empty;
            int inputParsed = 0;
            bool success = false;
            while (!success)
            {
                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out inputParsed))
                {
                    if (inputParsed < min || inputParsed > max)
                    {
                        Console.WriteLine("The selection must be between {0} and {1}: ", min, max);
                    }
                    else
                    {
                        success = true;
                    }
                }
                else
                {
                    Console.WriteLine("You must enter a number between {0} and {1}: ", min, max);
                }
            }
            return inputParsed;
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
    }
}
