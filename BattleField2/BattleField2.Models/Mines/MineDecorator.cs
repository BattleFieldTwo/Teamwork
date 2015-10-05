
namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Cells;
    using Coordinates;

    internal abstract class MineDecorator : Explosive
    {
        protected MineDecorator(Coordinates coordinates)
        {
            this.Coordinates = coordinates;
        }

        //TODO: checks
        protected Explosive Mine { get; set; }


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            return this.Mine.Detonate(currentFieldSize, fieldPositions);
        }

        public void DetonateMineBase(int fieldSize, Cell[,] field, int mineSpan, List<Coordinates> toEmpty = null)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            for (int i = row - mineSpan; i <= row + mineSpan; i++)
            {
                for (int j = col - mineSpan; j <= col + mineSpan; j++)
                {
                    if (IsValid(i, j, fieldSize))
                    {
                        if (toEmpty != null && toEmpty.IndexOf(new Coordinates(i, j)) > -1)
                        {
                            continue;
                        }
                        else
                        {
                            field[i, j] = CellFactory.GetCell(CellType.Detonated);
                        }
                    }
                }
            }
        }

        public void DetonateAdditional(int fieldSize, Cell[,] field, List<Coordinates> toDetonated)
        {
            for (int i = 0; i < toDetonated.Count; i++)
            {
                if (IsValid(toDetonated[i].Row, toDetonated[i].Col, fieldSize))
                {
                    field[toDetonated[i].Row, toDetonated[i].Col] = CellFactory.GetCell(CellType.Detonated);
                }
            }
        }
    }
}
