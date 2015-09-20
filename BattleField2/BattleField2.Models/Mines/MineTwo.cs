namespace BattleField2.Models.Mines
{
    class MineTwo : MineOne
    {
        public MineTwo(int xCoord, int yCoord)
            : base(xCoord, yCoord)
        {
        }

        public override string[,] Detonate(int currentFieldSize, string[,] fieldPositions)
        {
            fieldPositions = base.Detonate(currentFieldSize, fieldPositions);

            if (PrevIsValid(this.Row))
            {
                fieldPositions[this.Row - 1, this.Col] = " X ";
            }
            if (PrevIsValid(this.Col))
            {
                fieldPositions[this.Row, this.Col - 1] = " X ";
            }
            if (NextIsValid(this.Row, currentFieldSize))
            {
                fieldPositions[this.Row + 1, this.Col] = " X ";
            }
            if (NextIsValid(this.Col, currentFieldSize))
            {
                fieldPositions[this.Row, this.Col + 1] = " X ";
            }

            return fieldPositions;
        }
    }
}
