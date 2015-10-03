
namespace BattleField2.Models.Mines
{

    using Cells;

    internal abstract class MineDecorator : Explosive
    {

        protected MineDecorator(Explosive mine)
        {
            this.Mine = mine; 
        }

        //TODO: checks
        protected Explosive Mine { get; set; }


        public override Cell[,] Detonate(Cell[,] fieldPositions, CellFactory currentCellFactory)
        {
            return this.Mine.Detonate(fieldPositions, currentCellFactory);
        }
    }
}
