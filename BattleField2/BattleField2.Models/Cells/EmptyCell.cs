namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

    class EmptyCell : Cell
    {
        private readonly string stringRepresentation = " - ";

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
