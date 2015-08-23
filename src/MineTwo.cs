using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamBattleField2
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

            if (PrevIsValid(this.XCoord))
            {
                fieldPositions[this.XCoord - 1, this.YCoord] = " X ";
            }
            if (PrevIsValid(this.YCoord))
            {
                fieldPositions[this.XCoord, this.YCoord - 1] = " X ";
            }
            if (NextIsValid(this.XCoord, currentFieldSize))
            {
                fieldPositions[this.XCoord + 1, this.YCoord] = " X ";
            }
            if (NextIsValid(this.YCoord, currentFieldSize))
            {
                fieldPositions[this.XCoord, this.YCoord + 1] = " X ";
            }

            return fieldPositions;
        }
    }
}
