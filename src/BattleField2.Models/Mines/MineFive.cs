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

            if (PrevIsValid(this.XCoord - 1) && PrevIsValid(this.YCoord - 1))
            {
                fieldPositions[this.XCoord - 2, this.YCoord - 2] = " X ";
            }
            if (PrevIsValid(this.XCoord - 1) && NextIsValid(this.YCoord + 1, currentFieldSize))
            {
                fieldPositions[this.XCoord - 2, this.YCoord + 2] = " X ";
            }
            if (NextIsValid(this.XCoord + 1, currentFieldSize) && PrevIsValid(this.YCoord - 1))
            {
                fieldPositions[this.XCoord + 2, this.YCoord - 2] = " X ";
            }
            if (NextIsValid(this.XCoord + 1, currentFieldSize) && NextIsValid(this.YCoord + 1, currentFieldSize))
            {
                fieldPositions[this.XCoord + 2, this.YCoord + 2] = " X ";
            }

            return fieldPositions;
            
        }
    }
}
