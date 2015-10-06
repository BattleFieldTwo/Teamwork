
namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    public abstract class Explosive : Cell
    {
        public abstract Cell[,] Detonate(Cell[,] fieldPositions, CellFactory CurrentCellFactory, Coordinates currentCoordinates);

        //Checking if entered coordinates are valid
        public bool PrevIsValid(int coord)
        {
            bool result = (coord - 1) >= 0;
            return result;
        }

        public bool NextIsValid(int coord, int size)
        {
            bool result = (coord + 1) < size;
            return result;
        }

    }
}
