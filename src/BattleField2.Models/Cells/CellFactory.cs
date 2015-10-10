namespace BattleField2.Models.Cells
{
    public class CellFactory
    {
        private Cell empty;
        private Cell detonated;
        private static CellFactory instance;

        // Implemented Sigleton and Flyweight DP here
        private CellFactory()
        {
            this.Empty = new EmptyCell();
            this.Detonated = new DetonatedCell();
        }

        public static CellFactory Instance()
        {
            if (instance == null)
            {
                instance = new CellFactory();
            }
            return instance;
        }

        private Cell Empty
        {
            get { return empty; }
            set { empty = value; }
        }

        private Cell Detonated
        {
            get { return detonated; }
            set { detonated = value; }
        }

        public Cell GetCell(CellType type)
        {
            Cell currentCell = null;

            switch (type)
            {
                case CellType.Empty:
                    currentCell = this.Empty;
                    break;
                case CellType.Detonated:
                    currentCell = this.Detonated;
                    break;
                default:
                    break;
            }

            return currentCell;
        }
    }
}
