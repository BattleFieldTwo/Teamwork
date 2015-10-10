
namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;
    using System.Collections.Generic;

    public abstract class Mine : Cell, IExplosive
    {
        public abstract Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates);

        //Checking if entered coordinates are valid
        public bool IsValid(int i, int j, int size)
        {
            bool result = (0 <= i && i < size) &&
                          (0 <= j && j < size);
            return result;
        }

        public void DetonateMineBase(Cell[,] fieldPositions, Coordinates currentCoordinates, int mineSpan, List<Coordinates> toEmpty = null)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;
            int currentfieldsize = fieldPositions.GetLength(0);

            for (int i = row - mineSpan; i <= row + mineSpan; i++)
            {
                for (int j = col - mineSpan; j <= col + mineSpan; j++)
                {
                    bool noEmpty = (toEmpty == null) || (toEmpty.IndexOf(new Coordinates(i, j)) == -1);
                    bool isValid = IsValid(i, j, currentfieldsize);

                    if (isValid && noEmpty)
                    {
                        fieldPositions[i, j] = new DetonatedCell();
                    }
                }
            }
        }

        //public bool PrevIsValid(int coord)
        //{
        //    bool result = (coord - 1) >= 0;
        //    return result;
        //}

        //public bool NextIsValid(int coord, int size)
        //{
        //    bool result = (coord + 1) < size;
        //    return result;
        //}

    }
}
