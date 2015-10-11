namespace BattleField2.Models.Player
{
    using Common;
    using System;
    /// <summary>
    /// Player class handles the player in-game details.
    /// </summary>
    public class Player
    {
        private string name;
        private int score;

        internal Player() { }
        /// <summary>
        /// Player constructor method creating a player instance 
        /// with a given name.
        /// </summary>
        /// <param name="name">A player name value to be validated.</param>
        public Player(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// Public player name property that gets/sets the current player name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (Validator.isValidPlayerName(value))
                {
                    this.name = value;
                }
            }
        }
        /// <summary>
        /// Public property that gets/sets the current player score.
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (Validator.isValidPlayerScore(value))
                {
                    this.score = value;
                }
            }
        }
        /// <summary>
        /// Method that calculates the current score of the player.
        /// </summary>
        /// <param name="previousMinesCount">The number of mines before last detonation.</param>
        /// <param name="nextMinesCount">The number of mines after the last detonation.</param>
        /// <returns>The updated player score based on last detonation.</returns>
        public int CalculateScore(int previousMinesCount, int nextMinesCount)
        {
            int differenceInMinesDetonated = previousMinesCount - nextMinesCount;

            if (differenceInMinesDetonated == 1)
            {
                return 1;
            }
            else
            {
                return 1 + (differenceInMinesDetonated - 1) * 2; //can be changed
            }
        }
    }
}
