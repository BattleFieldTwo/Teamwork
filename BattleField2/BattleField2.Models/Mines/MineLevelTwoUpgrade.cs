﻿
namespace BattleField2.Models.Mines
{

    using Cells;
    using Coordinates;

    internal class MineLevelTwoUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 2 ";

        public MineLevelTwoUpgrade(Explosive mine)
            : base(mine)
        {
            this.Coordinates = mine.Coordinates;
        }


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;

            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (Mine.PrevIsValid(row))
            {
                fieldPositions[row - 1, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.PrevIsValid(col))
            {
                fieldPositions[row, col - 1] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(row, currentFieldSize))
            {
                fieldPositions[row + 1, col] = CellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row, col + 1] = CellFactory.GetCell(CellType.Detonated);
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