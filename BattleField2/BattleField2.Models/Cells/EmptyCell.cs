namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

    class EmptyCell : Cell
    {
        private readonly string stringRepresentation = " - ";
        
        public EmptyCell(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            fieldPositions[this.Coordinates.Row, this.Coordinates.Col] = CellFactory.GetCell(this.Coordinates,
                CellType.Detonated);
            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
