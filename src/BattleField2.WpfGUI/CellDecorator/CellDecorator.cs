namespace BattleField2.WpfGUI.CellDecorator
{
    using BattleField2.Models.Cells;

    /// <summary>
    /// This is an abstract decorator implementation for the Cell class.
    /// Implementing Decorator design pattern
    /// </summary>
    public abstract class CellDecorator : Cell
    {
        protected Cell cellToBeDecorated;
        

        public CellDecorator(Cell cellToBeDecorated)
        {
            this.CellToBeDecorated = cellToBeDecorated;
        }

        public Cell CellToBeDecorated
        {
            get { return cellToBeDecorated; }
            set { cellToBeDecorated = value; }
        }

        public override string StringRepresentation
        {
	        get { return this.CellToBeDecorated.StringRepresentation; }
        }
    }
}
