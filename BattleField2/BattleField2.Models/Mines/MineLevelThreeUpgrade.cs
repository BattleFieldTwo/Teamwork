
namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 3 ";
        private readonly int mineSpan = 2;

        public MineLevelThreeUpgrade()
            : base()
        {
        }

        public override Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;

            List<Coordinates> toDetonate = new List<Coordinates>()
            {
                new Coordinates(row - this.mineSpan, col),
                new Coordinates(row + this.mineSpan, col),
                new Coordinates(row, col - this.mineSpan),
                new Coordinates(row, col + this.mineSpan)
            };

            this.DetonateMineBase(fieldPositions, currentCoordinates, this.mineSpan - 1);
            this.DetonateAdditional(fieldPositions, currentCoordinates, toDetonate);

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

