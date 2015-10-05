namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;

    internal class MineLevelFourUpgrade : MineDecorator
    {
        private readonly int mineSpan = 2;
        private readonly string stringRepresentation = " 4 ";

        public MineLevelFourUpgrade(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int fieldSize, Cell[,] field)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            List<Coordinates> toEmpty = new List<Coordinates>()
            {
                new Coordinates(row - this.mineSpan, col - this.mineSpan),
                new Coordinates(row - this.mineSpan, col + this.mineSpan),
                new Coordinates(row + this.mineSpan, col - this.mineSpan),
                new Coordinates(row + this.mineSpan, col + this.mineSpan),
            };

            this.DetonateMineBase(fieldSize, field, mineSpan, toEmpty);

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

