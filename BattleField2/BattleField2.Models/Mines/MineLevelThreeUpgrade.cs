
namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;
    using Coordinates;

    internal class MineLevelThreeUpgrade : MineDecorator
    {
        private readonly string stringRepresentation = " 3 ";
        private readonly int mineSpan = 2;

        public MineLevelThreeUpgrade()
            : base()
        {
        }

<<<<<<< HEAD
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
=======

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
>>>>>>> master

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

