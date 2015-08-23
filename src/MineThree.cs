using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamBattleField2
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

            if (PrevIsValid(this.XCoord - 1))
            {
                fieldPositions[this.XCoord - 2, this.YCoord] = " X ";
            }
            if (PrevIsValid(this.YCoord - 1))
            {
                fieldPositions[this.XCoord, this.YCoord - 2] = " X ";
            }
            if (NextIsValid(this.XCoord + 1, currentFieldSize))
            {
                fieldPositions[this.XCoord + 2, this.YCoord] = " X ";
            }
            if (NextIsValid(this.YCoord + 1, currentFieldSize))
            {
                fieldPositions[this.XCoord, this.YCoord + 2] = " X ";
            }

            return fieldPositions;
        }
    }
}
