namespace BattleField2.WpfGUI
{
    using BattleField2.Models.Cells;

    public class ObservableCell
    {
        public ObservableCell(Cell currentInputCell, int row, int col)
        {
            this.CurrentCell = currentInputCell;
            this.Row = row;
            this.Col = col;
        }

        private int col;

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        private int row;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        private Cell currentCell;

        public Cell CurrentCell
        {
            get { return currentCell; }
            set { currentCell = value; }
        }
    }
}
