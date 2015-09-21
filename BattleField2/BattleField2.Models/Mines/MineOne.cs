namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;

    public class MineOne : Mine
    {
        public MineOne(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }
        
        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions[row, col] = CellFactory.GetCell(this.Coordinates, CellType.Detonated);

            if (PrevIsValid(row) && PrevIsValid(col))
            {
                fieldPositions = fieldPositions[row - 1, col - 1].Detonate(currentFieldSize, fieldPositions);
            }
            if (PrevIsValid(row) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions = fieldPositions[row - 1, col + 1].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row, currentFieldSize) && PrevIsValid(col))
            {
                fieldPositions = fieldPositions[row + 1, col - 1].Detonate(currentFieldSize, fieldPositions);
            }
            if (NextIsValid(row, currentFieldSize) && NextIsValid(col, currentFieldSize))
            {
                fieldPositions = fieldPositions[row + 1, col + 1].Detonate(currentFieldSize, fieldPositions);
            }

            return fieldPositions;
        }

        public override string Drow()
        {
            return " 1 ";
        }
    }
}
