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
        }


        public override Cell[,] Detonate(Cell[,] fieldPositions, CellFactory currentCellFactory, Coordinates currentCoordinates)
        {
            int row = currentCoordinates.Row;
            int col = currentCoordinates.Col;
            int currentFieldSize = fieldPositions.GetLength(0);

            fieldPositions = base.Detonate(fieldPositions, currentCellFactory, currentCoordinates);

            if (Mine.PrevIsValid(row))
            {
                fieldPositions[row - 1, col] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.PrevIsValid(col))
            {
                fieldPositions[row, col - 1] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(row, currentFieldSize))
            {
                fieldPositions[row + 1, col] = currentCellFactory.GetCell(CellType.Detonated);
            }
            if (Mine.NextIsValid(col, currentFieldSize))
            {
                fieldPositions[row, col + 1] = currentCellFactory.GetCell(CellType.Detonated);
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
