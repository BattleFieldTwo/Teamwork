namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    public interface IExplosive
    {
        Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates);
    }
}
