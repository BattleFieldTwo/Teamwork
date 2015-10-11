namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

   internal class EmptyCell : Cell
    {
        private readonly string stringRepresentation = " - ";

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
