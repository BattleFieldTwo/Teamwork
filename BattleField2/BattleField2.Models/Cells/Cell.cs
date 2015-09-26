namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

    public abstract class Cell
    {
        private Coordinates coordinates;

        public Cell(Coordinates currentCoordinates)
        {
            this.Coordinates = currentCoordinates;
        }

        public Coordinates Coordinates
        {
            get { return coordinates; }

            // TODO: Checks!
            set { coordinates = value; }
        }
        
        public abstract Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions);

        abstract public string StringRepresentation { get; }
    }
}
