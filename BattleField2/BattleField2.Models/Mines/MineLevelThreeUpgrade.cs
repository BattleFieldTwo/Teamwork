
namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 3 ";

        public MineLevelThreeUpgrade(Explosive mine)
            : base(mine)
        {
        }


        public override Cell[,] Detonate(Cell[,] fieldPositions, CellFactory currentCellFactory, Coordinates currentCoordinates)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;
            int currentFieldSize = fieldPositions.GetLength(0);

            fieldPositions = base.Detonate(fieldPositions, currentCellFactory, currentCoordinates);

            if (Mine.PrevIsValid(row - 1))
            {
                fieldPositions[row - 2, col] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.PrevIsValid(col - 1))
            {
                fieldPositions[row, col - 2] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(row + 1, currentFieldSize))
            {
                fieldPositions[row + 2, col] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row, col + 2] = currentCellFactory.GetCell(CellType.Detonated);
            }

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

