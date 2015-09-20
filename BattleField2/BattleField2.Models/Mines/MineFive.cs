namespace BattleField2.Models.Mines
{
    class MineFive : MineFour
    {
        public MineFive(int xCoord, int yCoord)
            : base(xCoord, yCoord)
        {
        }

        public override string[,] Detonate(int currentFieldSize, string[,] fieldPositions)
        {
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(this.Row - 1) && PrevIsValid(this.Col - 1))
            {
                fieldPositions[this.Row - 2, this.Col - 2] = " X ";
            }
            if (PrevIsValid(this.Row - 1) && NextIsValid(this.Col + 1, currentFieldSize))
            {
                fieldPositions[this.Row - 2, this.Col + 2] = " X ";
            }
            if (NextIsValid(this.Row + 1, currentFieldSize) && PrevIsValid(this.Col - 1))
            {
                fieldPositions[this.Row + 2, this.Col - 2] = " X ";
            }
            if (NextIsValid(this.Row + 1, currentFieldSize) && NextIsValid(this.Col + 1, currentFieldSize))
            {
                fieldPositions[this.Row + 2, this.Col + 2] = " X ";
            }

            return fieldPositions;
            
        }
    }
}
