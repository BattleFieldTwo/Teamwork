﻿
namespace BattleField2.Models.Mines
{
    using Cells;
    using Coordinates;

    public abstract class Explosive : Cell
    {
<<<<<<< HEAD
        public abstract Cell[,] Detonate(Cell[,] fieldPositions, Coordinates currentCoordinates);
=======
        public abstract Cell[,] Detonate(Cell[,] fieldPositions, CellFactory CurrentCellFactory, Coordinates currentCoordinates);
>>>>>>> master

        //Checking if entered coordinates are valid
        public bool IsValid(int i, int j, int size)
        {
            bool result = (0 <= i && i < size) &&
                          (0 <= j && j < size);
            return result;
        }

        //public bool PrevIsValid(int coord)
        //{
        //    bool result = (coord - 1) >= 0;
        //    return result;
        //}

        //public bool NextIsValid(int coord, int size)
        //{
        //    bool result = (coord + 1) < size;
        //    return result;
        //}

    }
}
