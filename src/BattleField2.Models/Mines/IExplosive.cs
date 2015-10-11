namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;
    /// <summary>
    /// Interface IExplosive to be implemented by a concrete Explosive class.
    /// </summary>
    public interface IExplosive
    {
        /// <summary>
        /// Method that should implement a detonation logic for the mines.
        /// </summary>
        /// <param name="fieldPositions">Detonation position.</param>
        /// <param name="currentCoordinates">Coordinates on the field.</param>
        /// <returns></returns>
        Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates);
    }
}
