namespace BattleField2.Models.Mines
{
    using Cells;

    internal class MineLevelFiveUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 5 ";

        public MineLevelFiveUpgrade(Explosive mine)
            : base(mine)
        {
            this.Coordinates = mine.Coordinates;
        }


        public override Cell[,] Detonate(Cell[,] fieldPositions, CellFactory currentCellFactory)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;
            int currentFieldSize = fieldPositions.GetLength(0);

            fieldPositions = base.Detonate(fieldPositions, currentCellFactory);

            if (PrevIsValid(row - 1) && PrevIsValid(col - 1))
            {
                fieldPositions[row - 2, col - 2] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (PrevIsValid(row - 1) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row - 2, col + 2] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row + 1, currentFieldSize) && PrevIsValid(col - 1))
            {
                fieldPositions[row + 2, col - 2] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row + 1, currentFieldSize) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row + 2, col + 2] = currentCellFactory.GetCell(CellType.Detonated);
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get
            {
                return this.stringRepresentation;
            }
        }
    }
}

