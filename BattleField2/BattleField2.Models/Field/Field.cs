using BattleField2.Models.Mines;

namespace BattleField2.Models.Field
{
    using System;

    using BattleField2.Models.Cells;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Contracts;

    public class Field
    {
        private int currentFieldSize;
        private Cell[,] fieldPositions;
        private int detonatedMines;
        private int initialMines;

        public Field(int currentFieldSize)
        {
            this.CurrentFieldSize = currentFieldSize;
            this.FieldPositions = new Cell[currentFieldSize, currentFieldSize];
            this.DetonatedMines = 0;
            this.InitialMines = CalculateInitialMines();
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

        public int CurrentFieldSize
        {
            get { return this.currentFieldSize; }

            // TODO: Implement checks!
            set
            {
                this.currentFieldSize = value;
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

        public int InitialMines
        {
            get { return initialMines; }

            // TODO: Implement checks!
            private set { initialMines = value; }
        }

        public void GenerateField()
        {
            for (int i = 0; i < currentFieldSize; i++)
            {
                for (int j = 0; j < currentFieldSize; j++)
                {
                    Coordinates currentCoordinates = new Coordinates(i, j);

                    this.fieldPositions[i, j] = CellFactory.GetCell(currentCoordinates, CellType.Empty);
                }
            }
        }

        public void PositionMines()
        {
            Random rnd = new Random();
            int numberOfAlreadyPositionedMines = 0;

            do
            {
                int currentMineRow = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));
                int currentMineCol = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));

                Coordinates currentCoordinates = new Coordinates(currentMineRow, currentMineCol);

                if (this.FieldPositions[currentMineRow, currentMineCol] is EmptyCell)
                {
                    int numberTypeOfMine = rnd.Next(0, 5);
                    MineType type = (MineType)numberTypeOfMine;
                    this.FieldPositions[currentMineRow, currentMineCol] = CellFactory.GetCell(currentCoordinates, CellType.Mine, type);

                    numberOfAlreadyPositionedMines++;
                }
            } while (this.InitialMines - numberOfAlreadyPositionedMines > 0);

        }

        public int CountRemainingMines()
        {
            int count = 0;

            for (int i = 0; i < this.CurrentFieldSize; i++)
            {
                for (int j = 0; j < this.CurrentFieldSize; j++)
                {
                    if ((this.FieldPositions[i, j] is Mine))
                        count++;
                }
            }

            return count;
        }

        public bool ValidateMoveCoordinates(Coordinates inputCoordinates)
        {
            if ((inputCoordinates.Col < 0) ||
                (inputCoordinates.Col > this.CurrentFieldSize - 1) ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] is EmptyCell) ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] is DetonatedCell))
            {
                return false;
            }

            return true;
        }

        private int CalculateInitialMines()
        {
            int minesDownLimit = Convert.ToInt32(0.15 * this.CurrentFieldSize * this.CurrentFieldSize);
            int minesUpperLimit = Convert.ToInt32(0.30 * this.CurrentFieldSize * this.CurrentFieldSize);

            Random rnd = new Random();

            int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));

            return minesCount;
        }
    }
}