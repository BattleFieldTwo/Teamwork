namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    public class MineOne : Mine
    {
        private readonly string stringRepresentation = " 1 ";
        
        public MineOne(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }
        
        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions[row, col] = CellFactory.GetCell(CellType.Detonated);

            if (PrevIsValid(row) && PrevIsValid(col))
            {
                fieldPositions[row - 1, col - 1] = CellFactory.GetCell(CellType.Detonated);
            }
            if (PrevIsValid(row) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row - 1, col + 1] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row, currentFieldSize) && PrevIsValid(col))
            {
                fieldPositions[row + 1, col - 1] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row, currentFieldSize) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row + 1, col + 1] = CellFactory.GetCell(CellType.Detonated); 
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
