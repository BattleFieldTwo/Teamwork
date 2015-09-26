namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    class MineThree : MineTwo
    {
        private readonly string stringRepresentation = " 3 ";

        
        public MineThree(Coordinates currentCoordinates)
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
                fieldPositions = fieldPositions[row - 2, col].Detonate(currentFieldSize, fieldPositions);
            }
            if (PrevIsValid(col - 1))
            {
                fieldPositions = fieldPositions[row, col - 2].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row + 1, currentFieldSize))
            {
                fieldPositions = fieldPositions[row + 2, col].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions = fieldPositions[row, col + 2].Detonate(currentFieldSize, fieldPositions);
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
