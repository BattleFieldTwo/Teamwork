
namespace BattleField2.Models.Mines
{
    using Cells;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 3 ";

        public MineLevelThreeUpgrade(Explosive mine)
            : base(mine)
        {

        }


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = Mine.Coordinates.Row;
            int col = Mine.Coordinates.Col;

            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (Mine.PrevIsValid(row - 1))
            {
                fieldPositions[row - 2, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.PrevIsValid(col - 1))
            {
                fieldPositions[row, col - 2] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(row + 1, currentFieldSize))
            {
                fieldPositions[row + 2, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(col + 1, currentFieldSize))
            {
                fieldPositions[row, col + 2] = CellFactory.GetCell(CellType.Detonated);
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

