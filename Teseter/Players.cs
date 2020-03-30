/**
 * The following class handles the logic behind player turn order
 * AUTHOR: Thomas Sinka
 * Date: 2020-02-16
 */

using System;
using System.Collections.Generic;
using Teseter;

namespace GameClient
{
    /// <summary>
    /// A container class which handles the logic behind player turn order
    /// </summary>
    public static class Players
    {
        /// <summary>
        /// Index of current player
        /// </summary>
        private static int CurrentPlayerNumber;

        /// <summary>
        /// Minimum amount of players for the game to continue
        /// </summary>
        private static int MINIMUM_PLAYER_COUNT = 2;

        /// <summary>
        /// A list of players who are still in the game.
        /// Players who are defeated are removed from this list.
        /// </summary>
        private static List<Player> PlayerList = new List<Player>();

        public static int PlayerCount;

 

        /// <summary>
        /// Set up the conditions for a new round of a card game.
        /// </summary>
        /// <param name="players">Array of Player objects</param>
        /// <param name="randomizeOrder">Should player turn order be randomized?</param>
        public static void InitializeGame(Player[] players, bool randomizeOrder)
        {
            try
            {
                PlayerList = new List<Player>(players);
            }catch (Exception e)
            {
                throw e;
            }
            //Setting one player to be human, and the rest ai
            for (int i = 0; i < players.Length; i++)
            {
                if (i == 0)
                {
                    players[i].IsAi = false;
                }
                else
                {
                    players[i].IsAi = true;
                }
            }


            //  Determine player turn order
            //  If player turn order is suppose to be random, randomize player list
            if (randomizeOrder)
            {
                PlayerList.Shuffle();
            }
            //  Otherwise player order is the order they initially appear in the array

            CurrentPlayerNumber = 0;    //  Current player number is set to beginning of list
            PlayerCount = PlayerList.Count;
        }

        /// <summary>
        /// Set up the conditions for a new round of a card game.
        /// </summary>
        /// <param name="players">Array of Player objects</param>
        public static void InitializeGame(Player[] players)
        { 
            //  Player order is not randomizeed
            InitializeGame(players, false);
        }

        /// <summary>
        /// Shuffles a list of objects using the Fisher-Yates shuffle algorithm
        /// Reference: https://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        /// <typeparam name="T">Object type of List</typeparam>
        /// <param name="list">List of objects to be shuffled</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Returns the Player who goes next
        /// Throws exception if there are less than the minimum allowable Player objects in collection
        /// /// </summary>
        /// <returns>Player Object</returns>
        public static Player GetNextPlayer()
        {
            if (PlayerList.Count < MINIMUM_PLAYER_COUNT)
            {
                throw new InvalidPlayerCount("\nThere must be at least " + MINIMUM_PLAYER_COUNT + " players for the game to continue.");
            }

            if (CurrentPlayerNumber == (PlayerList.Count-1))
            {
                CurrentPlayerNumber = 0;
            }
            else
            {
                CurrentPlayerNumber++;
            }
            return PlayerList[CurrentPlayerNumber];
        }

        public static void SkipTurn()
        {
            if (CurrentPlayerNumber == (PlayerList.Count - 1))
            {
                CurrentPlayerNumber = 0;
            }
            else
            {
                CurrentPlayerNumber++;
            }
        }

        /// <summary>
        /// Determines the next Player without ending current Player's turn
        /// Throws exception if there are less than the minimum allowable Player objects in collection
        /// </summary>
        /// <returns>Player Object</returns>
        public static Player PeakNextPlayer()
        {
            int playerNumber = CurrentPlayerNumber;

            if (PlayerList.Count < MINIMUM_PLAYER_COUNT)
            {
                throw new InvalidPlayerCount("\nThere must be at least " + MINIMUM_PLAYER_COUNT + " players for the game to continue.");
            }

            if (CurrentPlayerNumber == (PlayerList.Count - 1))
            {
                playerNumber = 0;
            }
            else
            {
                playerNumber++;
            }

            return PlayerList[playerNumber];
        }

        /// <summary>
        /// Ends the current player's turn
        /// Throws exception if there are less than the minimum allowable Player objects in collection
        /// </summary>
        public static void EndTurn()
        {
            if (PlayerList.Count < MINIMUM_PLAYER_COUNT)
            {
                throw new InvalidPlayerCount("\nThere must be at least " + MINIMUM_PLAYER_COUNT + " players for the game to continue.");
            }

            if (CurrentPlayerNumber == (PlayerList.Count - 1))
            {
                CurrentPlayerNumber = 0;
            }
            else
            {
                CurrentPlayerNumber++;
            }
        }

        /// <summary>
        /// Return the current Player
        /// Throws exception if there are less than the minimum allowable Player objects in collection
        /// </summary>
        /// <returns>Player Object</returns>
        public static Player GetCurrentPlayer()
        {
            if (PlayerList.Count < MINIMUM_PLAYER_COUNT)
            {
                throw new InvalidPlayerCount("\nThere must be at least " + MINIMUM_PLAYER_COUNT + " players for the game to continue.");
            }

            return PlayerList[CurrentPlayerNumber];
        }

        public static Player GetPlayer(int playerNum)
        {
            if (PlayerList.Count < MINIMUM_PLAYER_COUNT)
            {
                throw new InvalidPlayerCount("\nThere must be at least " + MINIMUM_PLAYER_COUNT + " players for the game to continue.");
            }

            return PlayerList[playerNum];
        }
    }
}
