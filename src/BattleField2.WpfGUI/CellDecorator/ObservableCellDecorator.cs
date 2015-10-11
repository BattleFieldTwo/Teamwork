namespace BattleField2.WpfGUI.CellDecorator
{
    using BattleField2.Models.Cells;

    public class ObservableCellDecorator : CellDecorator
    {
        private int col;
        private int row;

        public ObservableCellDecorator(Cell cellToBeDecorated, int row, int col)
            :base(cellToBeDecorated)
        {
            this.CellToBeDecorated = cellToBeDecorated;
            this.Row = row;
            this.Col = col;
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
    }
}
