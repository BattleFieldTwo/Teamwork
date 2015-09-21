namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    class MineFive : MineFour
    {
        public MineFive(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col; 
            
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(row - 1) && PrevIsValid(col - 1))
            {
                fieldPositions = fieldPositions[row - 2, col - 2].Detonate(currentFieldSize, fieldPositions);
            }
            if (PrevIsValid(row - 1) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions = fieldPositions[row - 2, col + 2].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row + 1, currentFieldSize) && PrevIsValid(col - 1))
            {
                fieldPositions = fieldPositions[row + 2, col - 2].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row + 1, currentFieldSize) && NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions = fieldPositions[row + 2, col + 2].Detonate(currentFieldSize, fieldPositions);
            }

            return fieldPositions;
            
        }

        public override string Drow()
        {
            return " 5 ";
        }
    }
}
