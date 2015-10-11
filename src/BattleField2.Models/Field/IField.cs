
namespace BattleField2.Models.Field
{
    using Cells;
    using Coordinates;
    using System;
    /// <summary>
    /// IField interface to be inherited by a concrete Field class implementation.
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// Cell property for the field position.
        /// </summary>
        Cell[,] FieldPositions { get; set; }
        /// <summary>
        /// Detonated mines setter and getter properties.
        /// </summary>
        int DetonatedMines { get; set; }
        /// <summary>
        /// Field generating method.
        /// </summary>
        void GenerateField();
        /// <summary>
        /// Mine positioning method.
        /// </summary>
        void PositionMines();
        /// <summary>
        /// Remaining mines counter method.
        /// </summary>
        /// <returns>Returns the number of mines remaining on the field.</returns>
        int CountRemainingMines();
        /// <summary>
        /// Method that validates the inputed coordinates.
        /// </summary>
        /// <param name="inputCoordinates">Input coordinates.</param>
        /// <returns>Return the validity of the input coordinates.</returns>
        bool ValidateMoveCoordinates(Coordinates inputCoordinates);

    }
}
