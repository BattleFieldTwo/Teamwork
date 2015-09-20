namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Contracts;

    public class MineOne : IMine
    {
        private int col;
        private int row;


        public int Row
        {
            get { return col; }

            // TODO: Checks!
            set { col = value; }
        }

        public int Col
        {
            get { return row; }

            // TODO: Checks!
            set { row = value; }
        }

        public MineOne(int row, int col)
        {
            this.Row = col;
            this.Col = row;
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
            fieldPositions[this.Row, this.Col] = " X ";

            if (PrevIsValid(this.Row) && PrevIsValid(this.Col))
            {
                fieldPositions[this.Row - 1, this.Col - 1] = " X ";
            }
            if (PrevIsValid(this.Row) && NextIsValid(this.Col, currentFieldSize))
            {
                fieldPositions[this.Row - 1, this.Col + 1] = " X ";
            }
            if (NextIsValid(this.Row, currentFieldSize) && PrevIsValid(this.Col))
            {
                fieldPositions[this.Row + 1, this.Col - 1] = " X ";
            }
            if (NextIsValid(this.Row, currentFieldSize) && NextIsValid(this.Col, currentFieldSize))
            {
                fieldPositions[this.Row + 1, this.Col + 1] = " X ";
            }

            return fieldPositions;
        }
    }
}
