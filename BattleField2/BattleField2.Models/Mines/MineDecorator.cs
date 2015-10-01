
namespace BattleField2.Models.Mines
{
    using Coordinates;
    using Cells;
    using System;

    internal abstract class MineDecorator : Explosive
    {
        protected MineDecorator(Explosive explosive)
        {
            this.Explosive = explosive;
        }

        protected Explosive Explosive { get; private set; }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            this.Explosive.Detonate(currentFieldSize, fieldPositions);
        }
    }
}
