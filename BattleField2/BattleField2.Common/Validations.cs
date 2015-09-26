namespace BattleField2.Common
{
    using System;

    public static class Validations
    {
        public static bool IsValidInputFieldSize(string inputFieldSize)
        {
            int fieldSize;

            if (!(Int32.TryParse(inputFieldSize, out fieldSize)))
            {
                return false;
            }
            else if (fieldSize < Constants.MinFieldSize || fieldSize > Constants.MaxFieldSize)
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
            else if (row < Constants.MinFieldSize || row >= fieldSize)
            {
                return false;
            }
            else if (col < Constants.MinFieldSize || col >= fieldSize)
            {
                return false;
            }

            return true;
        }
    }
}