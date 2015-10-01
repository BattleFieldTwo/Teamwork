
namespace BattleField2.Models.Mines
{
    using Cells;

    internal abstract class Explosive : Cell
    {
        public int Coordinates { get; set; }

        public abstract Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions);

    }
}
