
namespace BattleField2.Models.Field
{
    using Cells;
    using Coordinates;
    using System;

    public interface IField
    {
        Cell[,] FieldPositions { get; set; }

        int DetonatedMines { get; set; }

        void GenerateField();

        void PositionMines();

        int CountRemainingMines();

        bool ValidateMoveCoordinates(Coordinates inputCoordinates);

    }
}
