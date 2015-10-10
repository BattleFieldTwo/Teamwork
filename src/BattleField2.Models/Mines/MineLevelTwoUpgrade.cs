namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    internal class MineLevelTwoUpgrade : Mine
    {
        private readonly string stringRepresentation = " 2 ";
        private readonly int mineSpan = 1;

        public MineLevelTwoUpgrade()
            : base()
        {
        }


        public override Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates)
        {
            this.DetonateMineBase(fieldPositions, currentCoordinates, this.mineSpan);

            return fieldPositions;
        }

        public override string StringRepresentation
        {
            get
            {
                return this.stringRepresentation;
            }
        }
    }
}
