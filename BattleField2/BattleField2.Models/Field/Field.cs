namespace BattleField2.Models.Field
{
    using System;

    using BattleField2.Models.Coordinates;

    public class Field
    {
        private int currentFieldSize;
        private string[,] fieldPositions;
        private int detonatedMines;

        public Field(int currentFieldSize)
        {
            this.CurrentFieldSize = currentFieldSize;
            this.FieldPositions = new string[currentFieldSize, currentFieldSize];
            this.DetonatedMines = 0;
        }

        public string[,] FieldPositions
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

        public void GenerateField()
        {
            for (int i = 0; i < currentFieldSize; i++)
            {
                for (int j = 0; j < currentFieldSize; j++)
                {
                    this.fieldPositions[i, j] = " - ";
                }
            }
        }

        public void PositionMines()
        {
            int minesDownLimit = Convert.ToInt32(0.15 * this.CurrentFieldSize * this.CurrentFieldSize);
            int minesUpperLimit = Convert.ToInt32(0.30 * this.CurrentFieldSize * this.CurrentFieldSize);

            Random rnd = new Random();

            int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));

            // Unsed:
            // int[,] minesPositions = new int[minesCount, minesCount];

            // This should be out of this class
            Console.WriteLine("mines count is: " + minesCount);

            for (int i = 0; i < minesCount; i++)
            {
                bool alreadyPositionedMine;

                do
                {
                    int currentMineRow = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));
                    int currentMineCol = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));

                    if (this.FieldPositions[currentMineRow, currentMineCol] == " - ")
                    {
                        this.FieldPositions[currentMineRow, currentMineCol] =
                            " " + Convert.ToString(rnd.Next(1, 6) + " ");
                        alreadyPositionedMine = false;
                    }
                    else
                    {
                        alreadyPositionedMine = true;
                    }
                } while (alreadyPositionedMine);
            }
        }

        public int CountRemainingMines()
        {
            int count = 0;

            for (int i = 0; i < this.CurrentFieldSize; i++)
            {
                for (int j = 0; j < this.CurrentFieldSize; j++)
                {
                    if ((this.FieldPositions[i, j] != " X ") && (this.FieldPositions[i, j] != " - "))
                        count++;
                }
            }

            return count;
        }

        public bool ValidateMoveCoordinates(Coordinates inputCoordinates)
        {
            if ((inputCoordinates.Col < 0) ||
                (inputCoordinates.Col > this.CurrentFieldSize - 1) ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] == " - ") ||
                (this.FieldPositions[inputCoordinates.Row, inputCoordinates.Col] == " X "))
            {
                return false;
            }

            return true;
        }
    }
}