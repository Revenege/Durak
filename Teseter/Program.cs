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
            Player[] players = new Player[7];

            //Sets each player in the arary. Each player MUST have a name. 
            for (int i = 0; i < 7; i++)
            {
                players[i] = new Player("Jimbo Crimbo"+i);
            }
            //Setting the players. Must be done before starting the game.
            newGame.SetPlayers(players);
            //Starts the game
            newGame.PlayGame();
            Console.ReadKey();
        }
    }
}
