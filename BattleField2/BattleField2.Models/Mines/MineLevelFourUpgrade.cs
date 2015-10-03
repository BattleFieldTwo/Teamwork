namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    internal class MineLevelFourUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 4 ";

        public MineLevelFourUpgrade(Explosive mine)
            : base(mine)
        {
        }


        public override Cell[,] Detonate(Cell[,] fieldPositions, CellFactory currentCellFactory, Coordinates currentCoordinates)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;
            int currentFieldSize = fieldPositions.GetLength(0);


            fieldPositions = base.Detonate(fieldPositions, currentCellFactory, currentCoordinates);

            if (PrevIsValid(row - 1))
            {
                if (PrevIsValid(col))
                {
                    fieldPositions[row - 2, col - 1] = currentCellFactory.GetCell(CellType.Detonated);
                }
                if (NextIsValid(col, currentFieldSize))
                {
                    fieldPositions[row - 2, col + 1] = currentCellFactory.GetCell(CellType.Detonated);
                }
            }

            if (PrevIsValid(col - 1))
            {
                if (PrevIsValid(row))
                {
                    fieldPositions[row - 1, col - 2] = currentCellFactory.GetCell(CellType.Detonated);
                }
                if (NextIsValid(row, currentFieldSize))
                {
                    fieldPositions[row + 1, col - 2] = currentCellFactory.GetCell(CellType.Detonated);
                }
            }

            if (NextIsValid(row + 1, currentFieldSize))
            {
                if (PrevIsValid(col))
                {
                    fieldPositions[row + 2, col - 1] = currentCellFactory.GetCell(CellType.Detonated);
                }
                if (NextIsValid(col, currentFieldSize))
                {
                    fieldPositions[row + 2, col + 1] = currentCellFactory.GetCell(CellType.Detonated);
                }
            }

            if (NextIsValid(col + 1, currentFieldSize))
            {
                if (PrevIsValid(row))
                {
                    fieldPositions[row - 1, col + 2] = currentCellFactory.GetCell(CellType.Detonated);
                }
                if (NextIsValid(row, currentFieldSize))
                {
                    fieldPositions[row + 1, col + 2] = currentCellFactory.GetCell(CellType.Detonated);
                }
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

