﻿namespace BattleField2.Models.Cells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BattleField2.Models.Mines;
    using BattleField2.Models.Contracts;
    using BattleField2.Models.Coordinates;

    class CellFactory
    {
        // Refactor static methods!
        public static Cell GetCell(Coordinates currentCoordinates, CellType type, MineType mineType = MineType.None)
        {
            Cell currentCell = null;

            switch (type)
            {
                case CellType.Mine:
                    currentCell = MineFactory.GetMine(mineType, currentCoordinates);
                    break;
                case CellType.Empty:
                    currentCell = new EmptyCell(currentCoordinates);
                    break;
                case CellType.Detonated:
                    currentCell = new DetonatedCell(currentCoordinates);
                    break;
                default:
                    break;
            }

            return currentCell;
        }
    }
}