﻿namespace BattleField2.WpfGUI.CellDecorator
{
    using BattleField2.Models.Cells;

    /// <summary>
    /// This is a concrete decorator implementation for the Cell class.
    /// Needed to pass additional info to the XAML View
    /// Implementing Decorator design pattern
    /// </summary>
    public class ObservableCellDecorator : CellDecorator
    {
        private int col;
        private int row;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableCellDecorator" /> class.
        /// Constructor taking as arguments Cell and two numbers - for the position of the cell
        /// </summary>
        public ObservableCellDecorator(Cell cellToBeDecorated, int row, int col)
            :base(cellToBeDecorated)
        {
            this.CellToBeDecorated = cellToBeDecorated;
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets or sets col position property of the Cell
        /// </summary>
        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        /// <summary>
        /// Gets or sets row position property of the Cell
        /// </summary>
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
    }
}
