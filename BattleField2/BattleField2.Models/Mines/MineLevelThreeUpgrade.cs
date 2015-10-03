
namespace BattleField2.Models.Mines
{
    using Cells;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 3 ";

        public MineLevelThreeUpgrade(Explosive mine)
            : base(mine)
        {
            this.Coordinates = mine.Coordinates;
        }


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions, CellFactory currentCellFactory)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions = base.Detonate(currentFieldSize, fieldPositions, currentCellFactory);

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

