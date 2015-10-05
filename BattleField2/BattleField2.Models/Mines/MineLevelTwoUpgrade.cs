namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    internal class MineLevelTwoUpgrade : MineDecorator
    {
        private readonly int mineSpan = 1;
        private readonly string stringRepresentation = " 2 ";

        public MineLevelTwoUpgrade(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int fieldSize, Cell[,] field)
        {
            this.DetonateMineBase(fieldSize, field, mineSpan);

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
