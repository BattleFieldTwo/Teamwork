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

        /// <summary>
        /// Initializes a new instance of the <see cref="CellDecorator" /> class.
        /// Cell Decorator constructor taking as parameter Cell to be decorated
        /// </summary>
        public CellDecorator(Cell cellToBeDecorated)
        {
            this.CellToBeDecorated = cellToBeDecorated;
        }

        /// <summary>
        /// Gets or sets an instance on Cell that is being decorated
        /// </summary>
        public Cell CellToBeDecorated
        {
            get { return cellToBeDecorated; }
            set { cellToBeDecorated = value; }
        }

        /// <summary>
        /// Override of the StringRepresentation property from base class Cell
        /// </summary>
        public override string StringRepresentation
        {
	        get { return this.CellToBeDecorated.StringRepresentation; }
        }
    }
}
