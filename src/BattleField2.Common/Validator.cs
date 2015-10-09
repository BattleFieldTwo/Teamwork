namespace BattleField2.Common
{
    using System;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Class that holds various validation methods that are used
    /// throughout the application.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Method that validates the field size value.
        /// </summary>
        /// <param name="inputFieldSize">The field size value input given by the current Player.</param>
        /// <returns>Returns a boolean value representing the validity of the field size.</returns>
        public static bool IsValidInputFieldSize(string inputFieldSize)
        {
            int fieldSize;

            if (!(Int32.TryParse(inputFieldSize, out fieldSize)))
            {
                return false;
            }
            else if (fieldSize < Constants.MIN_FIELDSIZE || fieldSize > Constants.MAX_FIELDSIZE)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method that validates the input coordinates for the current battlefield size.
        /// </summary>
        /// <param name="inputCoordinates">Coordinates input by the user.</param>
        /// <param name="fieldSize">The current battlefield size.</param>
        /// <returns>Returns a boolean value representing the validity of the input coordinates.</returns>
        public static bool IsValidInputCoordinates(string inputCoordinates, int fieldSize)
        {
            string[] cords = inputCoordinates.Split(' ');
            int row, col;

            if (cords.Length != 2)
            {
                return false;
            }
            else if (!(Int32.TryParse(cords[0], out row)) ||
                     !(Int32.TryParse(cords[1], out col)))
            {
                return false;
            }
            else if (row < Constants.MIN_FIELDSIZE - 1 || row >= fieldSize)
            {
                return false;
            }
            else if (col < Constants.MIN_FIELDSIZE - 1 || col >= fieldSize)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method that validates the current player's score.
        /// </summary>
        /// <param name="score">Current score accumulated in the game.</param>
        /// <returns>Returns a boolean value representing the validity of the accumulated score.</returns>
        public static bool isValidPlayerScore(int score)
        {
            if(score < 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method that validates the new Player's name.
        /// </summary>
        /// <param name="name">The value string inputed by the current Player.</param>
        /// <returns>Returns boolean value representing the vaidity of the Player name.</returns>
        public static bool isValidPlayerName(string name)
        {
            Regex RgxUrl = new Regex(Constants.PLAYER_NAME_REGEX_PATTERN);
            
            if (name.Equals(""))
            {
                return false;
            }
            if (RgxUrl.IsMatch(name))
            {
                return false;
            }
            return true;
        }
    }
}
