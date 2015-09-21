using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;

    class DetonatedCell : Cell
    {
        public DetonatedCell(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            return fieldPositions;
        }

        public override string Drow()
        {
            return " X ";
        }
    }
}
