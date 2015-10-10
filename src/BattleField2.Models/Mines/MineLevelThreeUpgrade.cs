
namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;

    internal class MineLevelThreeUpgrade : Mine
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
            List<Coordinates> toEmpty = new List<Coordinates>();

            for (int i = row - mineSpan; i <= row + mineSpan; i++)
            {
                for (int j = col - mineSpan; j <= col + mineSpan; j++)
                {
                    if ((i == row - mineSpan || j == col - mineSpan ||
                        i == row + mineSpan || j == col + mineSpan) &&
                        i != row && j != col)
                    {
                        toEmpty.Add(new Coordinates(i, j));
                    }
                }
            }

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

