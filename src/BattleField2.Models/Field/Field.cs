namespace BattleField2.Models.Field
{
    using System;

    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Mines;

    public class Field
    {
        private Cell[,] fieldPositions;
        private int detonatedMines;
        private readonly CellFactory currentCellFactory;
        private readonly MineFactory currentMineFactory;


        public Field(int currentFieldSize)
        {
            this.FieldPositions = new Cell[currentFieldSize, currentFieldSize];
            this.DetonatedMines = 0;
            this.currentCellFactory = CellFactory.Instance();
            this.currentMineFactory = MineFactory.Instance();
        }

        public Cell[,] FieldPositions
        {
            get { return this.fieldPositions; }

            // TODO: Implement checks!
            set
            {
                this.fieldPositions = value;
            }
        }

        public int DetonatedMines
        {
            get { return this.detonatedMines; }

            // TODO: Implement checks!
            set
            {
                this.detonatedMines = value;
            }
        }

        public void GenerateField()
        {
            int currentFieldSize = this.FieldPositions.GetLength(0);

            for (int i = 0; i < currentFieldSize; i++)
            {
                for (int j = 0; j < currentFieldSize; j++)
                {
                    this.fieldPositions[i, j] = currentCellFactory.GetCell(CellType.Empty);
                }
            }
        }

        public void PositionMines()
        {
            Random rnd = new Random();
            int numberOfAlreadyPositionedMines = 0;
            int currentFieldSize = this.FieldPositions.GetLength(0);
            int initialMines = CalculateInitialMines(rnd);

            do
            {
                int currentMineRow = Convert.ToInt32(rnd.Next(0, currentFieldSize - 1));
                int currentMineCol = Convert.ToInt32(rnd.Next(0, currentFieldSize - 1));

                if (this.FieldPositions[currentMineRow, currentMineCol] is EmptyCell)
                {
                    int numberTypeOfMine = rnd.Next(0, (int)MineType.MineCount);
                    MineType type = (MineType)numberTypeOfMine;
                    this.FieldPositions[currentMineRow, currentMineCol] = currentMineFactory.GetMine(type);

                    numberOfAlreadyPositionedMines++;
                }
            } while (initialMines - numberOfAlreadyPositionedMines > 0);

        }

        public int CountRemainingMines()
        {
            int count = 0;
            int currentFieldSize = this.FieldPositions.GetLength(0);

            for (int i = 0; i < currentFieldSize; i++)
            {
                for (int j = 0; j < currentFieldSize; j++)
                {
                    if ((this.FieldPositions[i, j] is Mine))
                        count++;
                }
            }

            return count;
        }

        public bool ValidateMoveCoordinates(Coordinates inputCoordinates)
        {
            int currentFieldSize = this.FieldPositions.GetLength(0);

            if ((inputCoordinates.Col < 0) ||
                (inputCoordinates.Col > currentFieldSize - 1) ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] is EmptyCell) ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] is DetonatedCell))
            {
                return false;
            }

            return true;
        }

        private int CalculateInitialMines(Random rnd)
        {
            int currentFieldSize = this.FieldPositions.GetLength(0);
            int minesDownLimit = Convert.ToInt32(0.15 * currentFieldSize * currentFieldSize);
            int minesUpperLimit = Convert.ToInt32(0.30 * currentFieldSize * currentFieldSize);

            int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));

            return minesCount;
        }
    }
}