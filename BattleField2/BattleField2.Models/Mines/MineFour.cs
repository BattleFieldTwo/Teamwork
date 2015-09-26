namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    class MineFour : MineThree
    {
        private readonly string stringRepresentation = " 4 ";

        public MineFour(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col; 
            
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(row - 1))
            {
                if (PrevIsValid(col))
                {
                    fieldPositions = fieldPositions[row - 2, col - 1].Detonate(currentFieldSize, fieldPositions);
                }
                if (NextIsValid(col, currentFieldSize))
                {
                    fieldPositions = fieldPositions[row - 2, col + 1].Detonate(currentFieldSize, fieldPositions);
                }
            }

            if (PrevIsValid(col - 1))
            {
                if (PrevIsValid(row))
                {
                    fieldPositions = fieldPositions[row - 1, col - 2].Detonate(currentFieldSize, fieldPositions);
                }
                if (NextIsValid(row, currentFieldSize))
                {
                    fieldPositions = fieldPositions[row + 1, col - 2].Detonate(currentFieldSize, fieldPositions);
                }
            }

            if (NextIsValid(row + 1, currentFieldSize))
            {
                if (PrevIsValid(col))
                {
                    fieldPositions = fieldPositions[row + 2, col - 1].Detonate(currentFieldSize, fieldPositions);
                }
                if (NextIsValid(col, currentFieldSize))
                {
                    fieldPositions = fieldPositions[row + 2, col + 1].Detonate(currentFieldSize, fieldPositions);
                }
            }

            if (NextIsValid(col + 1, currentFieldSize))
            {
                if (PrevIsValid(row))
                {
                    fieldPositions = fieldPositions[row - 1, col + 2].Detonate(currentFieldSize, fieldPositions);
                }
                if (NextIsValid(row, currentFieldSize))
                {
                    fieldPositions = fieldPositions[row + 1, col + 2].Detonate(currentFieldSize, fieldPositions);
                }
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
