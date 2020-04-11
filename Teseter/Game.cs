using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGameProject;
using GameClient;
using GameWindow;

namespace Main_Menu
{
    public partial class frmGameWindow : Form
    {

        private Player attacker;
        private Player defender;
        static Random seed = new Random();

        private Player player; //  The human player

        

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 25;

        Durak game;

        //Current Gamestate. A is for attack, D for defend.
        char playState = ' ';
        //strictly for inheritance, default constructor 
        private frmGameWindow()
        {
            InitializeComponent();
        }
        //obtains the premade game object, begin the game
        public frmGameWindow(Player[] players, int deckSize)
        {
            InitializeComponent();
            //create the deck
            game = new Durak(deckSize);
            //shuffling the deck, setting the players and AIs

            Players.InitializeGame(players, true);
            game.SetPlayers(players);

            lblTrump.Text = game.TrumpSuit();

            //Dealing the hands
            game.DealHands();
            attacker = Players.GetCurrentPlayer();   //  Determine attacker
            defender = Players.PeakNextPlayer();     //  Determine defender

            player = Players.GetHumanPlayer();
            player.PlayHand.CardsChanged += hand_CardChanged;

            lblDeckSize.Text = game.GetCardsRemaining().ToString();
            UpdatePlayerHand();
            RealignCards(pnlPlayerHand);


            //If the AI is going first, then  set the player to defend, and the AI takes its turn
            if (Players.GetCurrentPlayer().IsAi)
            {
                playState = 'D';
                AiTurn('A');
            }
            else
            {
                playState = 'A';
                lblTempOutput.Text = game.ShowHand(attacker);
            }
        }

        /// <summary>
        /// Ends the Current turn, checks for winners
        /// </summary>
        private void EndTurn()
        {
            //Determine if the Player has lost
            int hasPlayerLost = 0;
            for (int i = 0; i < Players.PlayerCount; i++)
            {
                if (Players.GetPlayer(i).WinStatus == true)
                {
                    hasPlayerLost++;
                }
            }
            //If there is only one player remaining, the player has lost
            if (hasPlayerLost == Players.PlayerCount - 1)
            {
                MessageBox.Show("Too bad, you are the Durak!");
                this.Close();
            }

            //Begin the next Turn by advancing the turn
            attacker = Players.GetNextPlayer();
            defender = Players.PeakNextPlayer();
            //Drawing to the max number of cards possilbe
            game.DrawToMax();

            //Set the deck size
            lblDeckSize.Text = game.GetCardsRemaining().ToString();
            //If the next player is an AI, post which one
            if (attacker.IsAi == true)
            {
                lblCardPlayed.Text += "\nIt is now "+Players.GetCurrentPlayer().Name +" Turn";
                //Advance the turn
                AiTurn('A');
            }
            else
            {
                //Advance the turn ater setting the playState
                btnAccept.Enabled = true;
                lblCardPlayed.Text += "\nIt is now your turn";
                lblTempOutput.Text = game.ShowHand(attacker);
                playState = 'A';
            }
        }


        /// <summary>
        /// AI gameplay logic
        /// </summary>
        /// <param name="AiPlayState"> Wether the AI attacks or defends</param>
        private void AiTurn(char AiPlayState)
        {
            btnAccept.Enabled = false;
            if (AiPlayState == 'D')
            {
                if (defender.WinStatus == false)
                {

                    //Check if the AI is able to play
                    int playableCards = 0;
                    int selected = 0;

                    for (int i = 0; i < defender.PlayHand.Count; i++)
                    {
                        if (defender.PlayHand[i] > game.Table.LastPlayed())
                        {
                            playableCards++;
                            selected = i;
                        }
                    }
                    //If they are, defend
                    if (playableCards > 0)
                    {
                        lblCardPlayed.Text += "\n" + defender.Name + " Defends with " + defender.PlayHand[selected].ToString();

                        game.Defend(defender, defender.PlayHand[selected]);

                    }
                    else//Else pick up
                    {
                        lblCardPlayed.Text += "\n" + defender.Name + " Was unable to defend";
                        game.TakeCards(defender);
                        Players.SkipTurn();
                    }
                    //Determine if someone won
                    game.DetermineWinner(attacker);
                    game.DetermineWinner(defender);
                    //Determine if the defender has won. Defender is always an AI
                    if (defender.WinStatus == true)
                    {
                        MessageBox.Show(defender.Name+" is Not the durak");
                    }
                    //Determine if the attacker has won. 
                    if (attacker.WinStatus == true)
                    {
                        //If the Defender is an AI, display message. Otherwise, end the game
                        if (attacker.IsAi)
                        {
                            MessageBox.Show(attacker.Name + " is Not the durak");
                        }
                        else
                        {
                            MessageBox.Show("Congratulations, you are not the durak");
                            this.Close();
                        }
                    }
                    //End the turn
                    EndTurn();
                }
                else//If the current player has already won
                {
                    //Move to the next defender
                    defender = Players.GetNextPlayer();
                    //If the defender is an AI, recursively call the program
                    if (defender.IsAi)
                    {
                        AiTurn('D');
                    }
                    else//Otherwise, Player defends
                    {
                        btnAccept.Enabled = true;
                        lblCardPlayed.Text += "\nYou must Defend";
                        lblTempOutput.Text = game.ShowHand(defender);
                        playState = 'D';
                    }
                }

            }
            else if (AiPlayState =='A')//IF the Ai is attacking
            {
                //Check if they've won
                if (attacker.WinStatus == false)
                {
                    //If they haven't won, Play a card at random
                    int attackingCard = seed.Next(0, attacker.PlayHand.Count);
                    lblCardPlayed.Text += "\n" + attacker.Name + " Plays " + attacker.PlayHand[attackingCard].ToString();
                    game.Attack(attacker, attacker.PlayHand[attackingCard]);
                    //advance the turn based on if its an Ai next
                    if (defender.IsAi)
                    {
                        AiTurn('D');
                    }
                    else
                    {
                        playState = 'D';
                        lblCardPlayed.Text += "\n You must Defend";
                        lblTempOutput.Text = game.ShowHand(defender);
                        btnAccept.Enabled = true;
                    }

                    
                }
                else
                {
                    //If the attacker has already won, Advance the turn.
                    attacker = Players.GetNextPlayer();
                    defender = Players.PeakNextPlayer();
                    //Advance turn based on if its an Ai next
                    if (attacker.IsAi)
                    {
                        AiTurn('A');
                    }
                    else
                    {
                        btnAccept.Enabled = true;
                        lblCardPlayed.Text += "\nIt is now your turn";
                        lblTempOutput.Text = game.ShowHand(attacker);
                        playState = 'A';
                    }
                }
            }
        }


        /// <summary>
        /// On clicking the button, preform players turn action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            PlayerTurn();
        }

        /// <summary>
        /// What occurs during the players turn. Uses a playstate variable to determine what to do
        /// </summary>
        private void PlayerTurn()
        {


            //get user input
            String input = txtTest.Text;
            //check for validity of input
            bool valid = Int32.TryParse(input, out int selected);

            if (valid)
            {
                //If player is attacking
                if (playState == 'A')
                {

                    //Preform the attack
                    if (selected >= 0 && selected < attacker.PlayHand.Count)
                    {
                        lblCardPlayed.Text = "\nYou play " + attacker.PlayHand[selected].ToString();
                        game.Attack(attacker, attacker.PlayHand[selected]);
                        AiTurn('D');
                    }
                }
                else if (playState == 'D')//If the player is defedning
                {
                    //Check if the player is able to play
                    int playableCards = 0;
                    for (int i = 0; i < defender.PlayHand.Count; i++)
                    {
                        if (defender.PlayHand[i] > game.Table.LastPlayed())
                        {
                            playableCards++;
                        }
                    }
                    //If they are, defend
                    if (playableCards > 0 && selected >= 0 && selected < defender.PlayHand.Count)
                    {
                        if (defender.PlayHand[selected] > game.Table.LastPlayed())
                        {
                            lblCardPlayed.Text += "\n" + defender.Name + " Defends with " + defender.PlayHand[selected].ToString();
                            game.Defend(defender, defender.PlayHand[selected]);
                        }
                    }
                    else//ignore input, pick up the card and skip the turn
                    {
                        lblCardPlayed.Text = "\n" + defender.Name + " Was unable to defend";
                        game.TakeCards(defender);
                        Players.SkipTurn();
                    }
                    //Check for winners
                    game.DetermineWinner(attacker);
                    game.DetermineWinner(defender);

                    //Determine if he AI attacker has won
                    if (attacker.WinStatus == true)
                    {
                        MessageBox.Show(attacker.Name + " is Not the durak");
                    }
                    //Determine if the defender has won
                    if (defender.WinStatus == true)
                    {
                        MessageBox.Show("Congratulation, you are not the Durak!");
                        this.Close();
                    }
                    EndTurn();
                }
            }
        }

        private void frmGameWindow_Shown(object sender, EventArgs e)
        {

        }

        private void frmGameWindow_Load(object sender, EventArgs e)
        {

        }

        /*
        * btnHelp_Click - Displays the help information on how to play Durak
        */
        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            #region Help information about Durak (Very big open at your own risk)
            string Help = "The Basics\n\n " +
                "In the game of Durak, the order, regardless of the suit, is as follows: " +
                "6,7,8,9,10, Jack, Queen, King, and Ace. A trump card beats any card regardless of its color and value."
                + "The goal of the game is very simple – be the first player not to have any cards left in their hand. " +
                "As soon as a player discards their last card, the opponent loses and becomes a Durak.\n\n"
                + "The Setup\n\n " +
                "Each player is dealt a hand of six cards in total. After the dealing is done, a single " +
                "card is chosen. This card will serve for the purposes of assigning a trump card suit. So, if a Jack of Spades " +
                "end up face up, then all Clubs cards are trumps, and become the strongest assets in the game.\n\n" +
                "The Game\n\n" +
                "The game takes many turns, each turn is played out as an “attack.” Over the course of the entire game, you will see" +
                " multiple attacks taking place.\n\n" +
                "Phase 1\n\n " +
                "The attacking player must have a card in their hand.\n\n" +
                "If a player wants to counter a card, they need to produce a stronger card. So, if a player puts a 6 of Hearts," +
                " in order to stop the player, a defender would need to place a higher-value card or use a trump card instead\n\n" +
                "When and if a defender manages to fend off an attack, a new phase of the game begins\n\n" +
                "Phase 2\n\n" +
                "An attack may only continue – as in the 2nd phase – only in the instances when the attacking player is placing a " +
                "card of the same value as a card that has already been played. So, if you had a 6 and a 9 played in the 1st phase, " +
                "the 2nd phase must either open with a 6 or a 9.\n\n" +
                "How a turn ends\n\n" +
                "If a defender cannot prevent an attacker from defeating him in the round, the defender will collect all cards that " +
                "were just played in the turn and add them to his or her hand\n\n" +
                "Should the defender beat the attack, then the cards will go to the discard pile and the “end of turn” will take place.\n\n" +
                "End of the game\n\n" +
                "The game continues with players continuing to play and adding a card each turn they attack. When an attacker completes a turn – they " +
                "need to draw one card from the pile so that they have six cards again. If a player is already holding six cards, then they shouldn't " +
                "draw any additional cards.\n\n" +
                "Thank you for reading, I hope you win!";

            #endregion
            MessageBox.Show(Help, "How to play Durak.");
        }


        /// <summary>
        /// Update the CardBoxes in the player's hand
        /// </summary>
        private void UpdatePlayerHand()
        {
            //  Retrieve human player's hand
            Cards playerHand = Players.GetHumanPlayer().PlayHand;

            //  Clear the existing CardBox controls from play area
            pnlPlayerHand.Controls.Clear();

            //  Add each card to play area.
            foreach (Card card in playerHand)
            {
                pnlPlayerHand.Controls.Add(new CardBox(card));
            }
        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {


                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                    {
                        offset = cardWidth;
                    }

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }

                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            }
        }

        /// <summary>
        /// Updates the player's hand when their Cards collection changes.
        /// </summary>
        void hand_CardChanged()
        {
            //MessageBox.Show("a hand was changed");
            UpdatePlayerHand();
            RealignCards(pnlPlayerHand);
        }


    }
}
