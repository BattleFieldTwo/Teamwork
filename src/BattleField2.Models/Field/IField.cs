
namespace BattleField2.Models.Field
{
    using Cells;
    using Coordinates;
    using System;
    /// <summary>
    /// 
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// 
        /// </summary>
        Cell[,] FieldPositions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int DetonatedMines { get; set; }
        /// <summary>
        /// 
        /// </summary>
        void GenerateField();
        /// <summary>
        /// 
        /// </summary>
        void PositionMines();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int CountRemainingMines();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputCoordinates"></param>
        /// <returns></returns>
        bool ValidateMoveCoordinates(Coordinates inputCoordinates);

    }
}
