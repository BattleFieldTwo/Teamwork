namespace BattleField2.Models.Cells
{
    /// <summary>
    /// CellFactory class uses a Singleton implemented instance to
    /// create Cell objects with appropriate CellType enumeration type
    /// based on given input. 
    /// </summary>
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
        /// <summary>
        /// CellFactory method checks if their is an already created
        /// CellFactory instance and returns it. If the instance is 
        /// already create it returns it anyway.
        /// </summary>
        /// <returns>The existing CellFactory instance.</returns>
        public static CellFactory Instance()
        {
            if (instance == null)
            {
                instance = new CellFactory();
            }
            return instance;
        }
        /// <summary>
        /// GetCell method gets a valid enumeration CellType and returns a Cell Object
        /// with the appropriate CellType.
        /// </summary>
        /// <param name="type">A valid CellType eunmeration type.</param>
        /// <returns>A cell object with the appropriate CellType set by the given parameter.</returns>
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
