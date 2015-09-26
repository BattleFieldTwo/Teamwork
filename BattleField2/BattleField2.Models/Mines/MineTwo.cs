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
                fieldPositions = fieldPositions[row - 1, col].Detonate(currentFieldSize, fieldPositions);
            }
            if (PrevIsValid(col))
            {
                fieldPositions = fieldPositions[row, col - 1].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row, currentFieldSize))
            {
                fieldPositions = fieldPositions[row + 1, col].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(col, currentFieldSize))
            {
                fieldPositions = fieldPositions[row, col + 1].Detonate(currentFieldSize, fieldPositions);
            }

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
