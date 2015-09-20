namespace BattleField2.Models.Field
{
    using System;

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
        {//tuka ne sym siguren kakvo tochno pravq ama pyk raboti
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
                    int currentMineXCoordinate;
                    int currentMineYCoordinate;

                    currentMineXCoordinate = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));
                    currentMineYCoordinate = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));

                    if (this.FieldPositions[currentMineXCoordinate, currentMineYCoordinate] == " - ")
                    {
                        this.FieldPositions[currentMineXCoordinate, currentMineYCoordinate] =
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

        //tuka sa mogyshtite metodi za gyrmejite

        //Checking if entered coordinates are valid
        private bool PrevIsValid(int coord)
        {
            bool result = (coord - 1) >= 0;
            return result;
        }

        private bool NextIsValid(int coord, int size)
        {
            bool result = (coord + 1) < size;
            return result;
        }

        public int CountRemainingMines()
        {
            int count = 0;

            for (int i = 0; i < this.CurrentFieldSize; i++)
            {
                for (int j = 0; i < this.CurrentFieldSize; i++)
                {
                    if ((this.FieldPositions[i, j] != " X ") && (this.FieldPositions[i, j] != " - "))
                        count++;
                }
            }

            return count;
        }
    }
}