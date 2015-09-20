namespace BattleField2.Models.Mines
{
    class MineFour : MineThree
    {
        public MineFour(int xCoord, int yCoord)
            : base(xCoord, yCoord)
        {
        }

        public override string[,] Detonate(int currentFieldSize, string[,] fieldPositions)
        {
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(this.Row - 1))
            {
                if (PrevIsValid(this.Col))
                {
                    fieldPositions[this.Row - 2, this.Col - 1] = " X ";
                }
                if (NextIsValid(this.Col, currentFieldSize))
                {
                    fieldPositions[this.Row - 2, this.Col + 1] = " X ";
                }
            }

            if (PrevIsValid(this.Col - 1))
            {
                if (PrevIsValid(this.Row))
                {
                    fieldPositions[this.Row - 1, this.Col - 2] = " X ";
                }
                if (NextIsValid(this.Row, currentFieldSize))
                {
                    fieldPositions[this.Row + 1, this.Col - 2] = " X ";
                }
            }

            if (NextIsValid(this.Row + 1, currentFieldSize))
            {
                if (PrevIsValid(this.Col))
                {
                    fieldPositions[this.Row + 2, this.Col - 1] = " X ";
                }
                if (NextIsValid(this.Col, currentFieldSize))
                {
                    fieldPositions[this.Row + 2, this.Col + 1] = " X ";
                }
            }

            if (NextIsValid(this.Col + 1, currentFieldSize))
            {
                if (PrevIsValid(this.Row))
                {
                    fieldPositions[this.Row - 1, this.Col + 2] = " X ";
                }
                if (NextIsValid(this.Row, currentFieldSize))
                {
                    fieldPositions[this.Row + 1, this.Col + 2] = " X ";
                }
            }

            return fieldPositions;
        }
    }
}
