namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;

    internal class MineLevelFourUpgrade : Mine
    {
        private readonly string stringRepresentation = " 4 ";
        private readonly int mineSpan = 2;

        public MineLevelFourUpgrade()
            : base()
        {
        }

        public override Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;

            List<Coordinates> toEmpty = new List<Coordinates>()
            {
                new Coordinates(row - this.mineSpan, col - this.mineSpan),
                new Coordinates(row - this.mineSpan, col + this.mineSpan),
                new Coordinates(row + this.mineSpan, col - this.mineSpan),
                new Coordinates(row + this.mineSpan, col + this.mineSpan),
            };

            this.DetonateMineBase(fieldPositions, currentCoordinates, this.mineSpan, toEmpty);

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

