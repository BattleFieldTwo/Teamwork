namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

   internal class DetonatedCell : Cell
    {
        private readonly string stringRepresentation = " X ";

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
}
