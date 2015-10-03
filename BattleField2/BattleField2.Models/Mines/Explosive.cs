
namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    public abstract class Explosive : Cell
    {
        private Coordinates coordinates;

        public Coordinates Coordinates
        {
            get { return coordinates; }

            // TODO: Checks!
            set { coordinates = value; }
        }

        public abstract Cell[,] Detonate(Cell[,] fieldPositions, CellFactory CurrentCellFactory);

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
