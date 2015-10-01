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


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(row - 1) && PrevIsValid(col - 1))
            {
                fieldPositions[row - 2, col - 2] = CellFactory.GetCell(CellType.Detonated);
            }
            if (PrevIsValid(row - 1) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row - 2, col + 2] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row + 1, currentFieldSize) && PrevIsValid(col - 1))
            {
                fieldPositions[row + 2, col - 2] = CellFactory.GetCell(CellType.Detonated);
            }
            if (NextIsValid(row + 1, currentFieldSize) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row + 2, col + 2] = CellFactory.GetCell(CellType.Detonated);
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

