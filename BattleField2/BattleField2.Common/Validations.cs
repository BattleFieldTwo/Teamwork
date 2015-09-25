using System;

namespace BattleField2.Common
{
    public static class Validations
    {
        public static bool InputFieldSizeIsValid(string inputFieldSize)
        {
            int fieldSize;
            if (!(Int32.TryParse(inputFieldSize, out fieldSize)))
            {
                return false;
            }
            else if (fieldSize < 0)
            {
                return false;
            }
            else if (fieldSize > 11)
            {
                return false;
            }

            return true;
        }
    }
}
