using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField2.WpfGUI.CellDecorator
{
    using BattleField2.Models.Cells;

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
