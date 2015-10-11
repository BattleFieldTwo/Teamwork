namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Coordinates;
    /// <summary>
    /// The Cell class is an abstract class to be inherited 
    /// by the concrete Cells 
    /// </summary>
    public abstract class Cell
    {
        /// <summary>
        /// Abstract method to be inherited by the concrete Cells
        /// to output their given in-game representations.
        /// </summary>
        abstract public string StringRepresentation { get; }
    }
}
