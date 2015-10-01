
namespace BattleField2.Models.Mines
{

    using Cells;

    internal abstract class MineDecorator : Explosive
    {

        protected MineDecorator(Explosive mine)
        {
            this.Mine = mine; //could be improved 
        }

        //TODO: checks
        protected Explosive Mine { get; set; }


        public override Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions)
        {
            return this.Mine.Detonate(currentFieldSize, fieldPositions);
        }
    }
}
