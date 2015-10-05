namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly int mineSpan = 2;
        private readonly string stringRepresentation = " 3 ";

        public MineLevelThreeUpgrade(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int fieldSize, Cell[,] field)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            List<Coordinates> toDetonate = new List<Coordinates>()
            {
                new Coordinates(row - this.mineSpan, col),
                new Coordinates(row + this.mineSpan, col),
                new Coordinates(row, col - this.mineSpan),
                new Coordinates(row, col + this.mineSpan)
            };

            this.DetonateMineBase(fieldSize, field, this.mineSpan - 1);
            this.DetonateAdditional(fieldSize, field, toDetonate);

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

