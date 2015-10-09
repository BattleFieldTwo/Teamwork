namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    internal class MineLevelFiveUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 5 ";
        private readonly int mineSpan = 2;

        public MineLevelFiveUpgrade()
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

