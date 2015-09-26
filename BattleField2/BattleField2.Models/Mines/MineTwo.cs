namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    class MineTwo : MineOne
    {
        private readonly string stringRepresentation = " 2 ";
        
        public MineTwo(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col; 
            
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(row))
            {
                fieldPositions[row - 1, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (PrevIsValid(col))
            {
                fieldPositions[row, col - 1] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row, currentFieldSize))
            {
                fieldPositions[row + 1, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row, col + 1] = CellFactory.GetCell(CellType.Detonated);
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
