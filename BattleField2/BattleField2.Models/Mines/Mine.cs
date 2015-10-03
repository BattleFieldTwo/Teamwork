namespace BattleField2.Models.Mines
{
    using Coordinates;
    using Cells;

    public class Mine : Explosive
    {

        private readonly string stringRepresentation = " 1 ";

        public Mine(Coordinates currentCoordinates)
        {
            this.Coordinates = currentCoordinates;
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions, CellFactory currentCellFactory)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions[row, col] = currentCellFactory.GetCell(CellType.Detonated);

            if (PrevIsValid(row) && PrevIsValid(col))
            {
                fieldPositions[row - 1, col - 1] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (PrevIsValid(row) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row - 1, col + 1] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row, currentFieldSize) && PrevIsValid(col))
            {
                fieldPositions[row + 1, col - 1] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row, currentFieldSize) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row + 1, col + 1] = currentCellFactory.GetCell(CellType.Detonated);
            }

            return fieldPositions;
        }

        ////Checking if entered coordinates are valid
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

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }


    }
    //public abstract class Mine : Cell
    //{
    //    private Coordinates coordinates;

    //    public Mine(Coordinates currentCoordinates)
    //    {
    //        this.Coordinates = currentCoordinates;
    //    }

    //    public Coordinates Coordinates
    //    {
    //        get { return coordinates; }

    //        // TODO: Checks!
    //        set { coordinates = value; }
    //    }

    //    public abstract Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions);

    //    //Checking if entered coordinates are valid
    //    public bool PrevIsValid(int coord)
    //    {
    //        bool result = (coord - 1) >= 0;
    //        return result;
    //    }

    //    public bool NextIsValid(int coord, int size)
    //    {
    //        bool result = (coord + 1) < size;
    //        return result;
    //    }
    //}
}
