/*
 * the following program represnets the interface for the game Durak. 
 * date: 2020-01-23
 * Since: 2020-02-10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameProject;


namespace GameClient
{
    class Program
    {

        static void Main(string[] args)
        {

            /**
             * TO DO: ADD A MENU 
             * MENU SHOULD ALLOW FOR SELECTION OF DECK SIZE
             * CHOOSE NUMBER OF PLAYERS
             * SETS THE NUMBER OF PLAYERS
             * SETS THE NAMES FOR EACH PLAYER
             * WHEN THE GAME IS OVER DISPLAY THE WINNER
             */

            //Decksize for durak. must be 20,36, or 52
            int deckSize = 20;
            //Creates a new game of durak, with a given deckSize
            Durak newGame = new Durak(deckSize);
            //Creates an array of players. Can be between 2 and 7
            Player[] players;


            bool ready = false;
            List<Player> playerList = new List<Player>();

            Console.WriteLine("Enter the name of a new player, or enter \"ready\" to start the game: ");

            //  obtain player names
            while (!ready)
            {
                Console.Write("Player {0}: " , (playerList.Count + 1));
                string input = Console.ReadLine();

                //  if name is not empty
                if (input != string.Empty)
                {
                    //  if a new player is added
                    if (input != "ready")
                    {
                        playerList.Add(new Player(input));

                        //  if maximum player count has been reached
                        if (playerList.Count == Durak.GetMaxPlayers())
                        {
                            //  ready to begin
                            ready = true;
                        }
                    }
                    //  if players want to start game
                    else
                    {
                        //  if minimum player count has been reached
                        if (playerList.Count >= Durak.GetMinPlayers())
                        {
                            //  ready to begin
                            ready = true;
                        }
                        //  if too few players
                        else
                        {
                            Console.WriteLine("you must have at least {0} players to begin.", Durak.GetMinPlayers());
                        }
                    }
                }
                //  if name was empty
                else
                {
                    Console.WriteLine("You must enter a player name, please try again.");
                }
            }

            //Sets each player in the arary. 
            players = playerList.ToArray();

            //Setting the players. Must be done before starting the game.
            newGame.SetPlayers(players);
            //Starts the game
            newGame.PlayGame();
            Console.ReadKey();
        }
    }
}
