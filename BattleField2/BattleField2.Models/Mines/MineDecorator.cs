
namespace BattleField2.Models.Mines
{

    using Cells;

    internal abstract class MineDecorator : Explosive
    {
        protected MineDecorator(Mine mine)
        {
            this.Mine = mine;
        }

        protected Mine Mine { get; private set; }

        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            return this.Mine.Detonate(currentFieldSize, fieldPositions);
        }
    }
}
