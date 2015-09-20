namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Contracts;

    public class MineOne : IMine
    {
        private int xCoord;
        private int yCoord;


        public int XCoord
        {
            get { return xCoord; }

            // TODO: Checks!
            set { xCoord = value; }
        }

        public int YCoord
        {
            get { return yCoord; }

            // TODO: Checks!
            set { yCoord = value; }
        }

        public MineOne(int xCoord, int yCoord)
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
        }
        
        
        //Checking if entered coordinates are valid
        public bool PrevIsValid(int coord)
        {
            bool result = (coord - 1) >= 0;
            return result;
        }

        public bool NextIsValid(int coord, int size)
        {
            bool result = (coord + 1) < size;
            return result;
        }

        public virtual string[,] Detonate(int currentFieldSize, string[,] fieldPositions)
        {
            fieldPositions[this.XCoord, this.YCoord] = " X ";

            if (PrevIsValid(this.XCoord) && PrevIsValid(this.YCoord))
            {
                fieldPositions[this.XCoord - 1, this.YCoord - 1] = " X ";
            }
            if (PrevIsValid(this.XCoord) && NextIsValid(this.YCoord, currentFieldSize))
            {
                fieldPositions[this.XCoord - 1, this.YCoord + 1] = " X ";
            }
            if (NextIsValid(this.XCoord, currentFieldSize) && PrevIsValid(this.YCoord))
            {
                fieldPositions[this.XCoord + 1, this.YCoord - 1] = " X ";
            }
            if (NextIsValid(this.XCoord, currentFieldSize) && NextIsValid(this.YCoord, currentFieldSize))
            {
                fieldPositions[this.XCoord + 1, this.YCoord + 1] = " X ";
            }

            return fieldPositions;
        }
    }
}
