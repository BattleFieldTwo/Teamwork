namespace BattleField2.Models.Cells
{
    using BattleField2.Models.Mines;
    using BattleField2.Models.Coordinates;

    class CellFactory
    {
        // Refactor static methods????
        public static Cell GetCell(CellType type)
        {
            Cell currentCell = null;

            switch (type)
            {
                case CellType.Empty:
                    currentCell = new EmptyCell();
                    break;
                case CellType.Detonated:
                    currentCell = new DetonatedCell();
                    break;
                default:
                    break;
            }

            return currentCell;
        }
    }
}
