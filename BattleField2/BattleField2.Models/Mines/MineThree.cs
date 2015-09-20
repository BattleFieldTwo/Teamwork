namespace BattleField2.Models.Mines
{
    class MineThree : MineTwo
    {
        public MineThree(int xCoord, int yCoord)
            : base(xCoord, yCoord)
        {
        }

        public override string[,] Detonate(int currentFieldSize, string[,] fieldPositions)
        {
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(this.Row - 1))
            {
                fieldPositions[this.Row - 2, this.Col] = " X ";
            }
            if (PrevIsValid(this.Col - 1))
            {
                fieldPositions[this.Row, this.Col - 2] = " X ";
            }
            if (NextIsValid(this.Row + 1, currentFieldSize))
            {
                fieldPositions[this.Row + 2, this.Col] = " X ";
            }
            if (NextIsValid(this.Col + 1, currentFieldSize))
            {
                fieldPositions[this.Row, this.Col + 2] = " X ";
            }

            return fieldPositions;
        }
    }
}
