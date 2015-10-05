namespace BattleField2.Models.Mines
{
    using Coordinates;
    using Cells;

    internal class MineLevelFiveUpgrade : MineDecorator
    {
        private readonly int mineSpan = 2;
        private readonly string stringRepresentation = " 5 ";

        public MineLevelFiveUpgrade(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int fieldSize, Cell[,] field)
        {
            this.DetonateMineBase(fieldSize, field, this.mineSpan);

            return field;
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

