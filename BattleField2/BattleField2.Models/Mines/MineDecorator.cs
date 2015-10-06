namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Cells;
    using Coordinates;

    internal abstract class MineDecorator : Explosive
    {
        protected MineDecorator()
        {
        }

        //TODO: checks
        protected Explosive Mine { get; set; }


        public override Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates)
        {
            return this.Mine.Detonate(fieldPositions, currentCoordinates);
        }

        public void DetonateMineBase(Cell[,] fieldPositions, Coordinates currentCoordinates, int mineSpan, List<Coordinates> toEmpty = null)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;
            int currentfieldsize = fieldPositions.GetLength(0);

            for (int i = row - mineSpan; i <= row + mineSpan; i++)
            {
                for (int j = col - mineSpan; j <= col + mineSpan; j++)
                {
                    bool noEmpty = (toEmpty == null) || (toEmpty.IndexOf(new Coordinates(i, j)) == -1);
                    bool isValid = IsValid(i, j, currentfieldsize);

                    if (isValid && noEmpty)
                    {
                        fieldPositions[i, j] = new DetonatedCell();
                    }
                }
            }
        }

        public void DetonateAdditional(Cell[,] fieldPositions, Coordinates currentCoordinates, List<Coordinates> toDetonated)
        {
            int currentfieldsize = fieldPositions.GetLength(0);

            for (int i = 0; i < toDetonated.Count; i++)
            {
                bool isValid = IsValid(toDetonated[i].Row, toDetonated[i].Col, currentfieldsize);

                if (isValid)
                {
                    fieldPositions[toDetonated[i].Row, toDetonated[i].Col] = new DetonatedCell();
                }
            }
        }
    }
}
