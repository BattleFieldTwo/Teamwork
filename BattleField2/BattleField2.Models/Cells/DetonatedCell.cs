namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

    class DetonatedCell : Cell
    {
        private readonly string stringRepresentation = " X ";
            
        public DetonatedCell(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
