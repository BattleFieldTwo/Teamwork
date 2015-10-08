namespace BattleField2.Common
{
    using System;
    using System.Text.RegularExpressions;

    public static class Validator
    {
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

        public static bool isValidPlayerScore(int score)
        {
            if(score < 0)
            {
                return false;
            }
            return true;
        }

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
