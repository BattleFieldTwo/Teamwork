using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamBattleField2
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

            if (PrevIsValid(this.XCoord - 1))
            {
                if (PrevIsValid(this.YCoord))
                {
                    fieldPositions[this.XCoord - 2, this.YCoord - 1] = " X ";
                }
                if (NextIsValid(this.YCoord, currentFieldSize))
                {
                    fieldPositions[this.XCoord - 2, this.YCoord + 1] = " X ";
                }
            }

            if (PrevIsValid(this.YCoord - 1))
            {
                if (PrevIsValid(this.XCoord))
                {
                    fieldPositions[this.XCoord - 1, this.YCoord - 2] = " X ";
                }
                if (NextIsValid(this.XCoord, currentFieldSize))
                {
                    fieldPositions[this.XCoord + 1, this.YCoord - 2] = " X ";
                }
            }

            if (NextIsValid(this.XCoord + 1, currentFieldSize))
            {
                if (PrevIsValid(this.YCoord))
                {
                    fieldPositions[this.XCoord + 2, this.YCoord - 1] = " X ";
                }
                if (NextIsValid(this.YCoord, currentFieldSize))
                {
                    fieldPositions[this.XCoord + 2, this.YCoord + 1] = " X ";
                }
            }

            if (NextIsValid(this.YCoord + 1, currentFieldSize))
            {
                if (PrevIsValid(this.XCoord))
                {
                    fieldPositions[this.XCoord - 1, this.YCoord + 2] = " X ";
                }
                if (NextIsValid(this.XCoord, currentFieldSize))
                {
                    fieldPositions[this.XCoord + 1, this.YCoord + 2] = " X ";
                }
            }

            return fieldPositions;
        }
    }
}
