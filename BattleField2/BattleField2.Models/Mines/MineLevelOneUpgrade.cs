namespace BattleField2.Models.Mines
{
    using System.Collections.Generic;
    using Coordinates;
    using Cells;    

    internal class MineLevelOneUpgrade : MineDecorator
    {
        private readonly int mineSpan = 1;
        private readonly string stringRepresentation = " 1 ";

        public MineLevelOneUpgrade(Coordinates currentCoordinates)
            :base(currentCoordinates)
        {
        }

        public override Cell[,] Detonate(int fieldSize, Cell[,] field)
        {
            int row = this.Coordinates.Row;
            int col = this.Coordinates.Col;
            
            List<Coordinates> toEmpty = new List<Coordinates>()
            {
                new Coordinates(row - this.mineSpan, col),
                new Coordinates(row + this.mineSpan, col),
                new Coordinates(row, col - this.mineSpan),
                new Coordinates(row, col + this.mineSpan)
            };

            this.DetonateMineBase(fieldSize, field, mineSpan, toEmpty);

            return field;
        }

        public override string StringRepresentation
        {
            get { return this.stringRepresentation; }
        }
    }
    //public abstract class Mine : Cell
    //{
    //    private Coordinates coordinates;

    //    public Mine(Coordinates currentCoordinates)
    //    {
    //        this.Coordinates = currentCoordinates;
    //    }

    //    public Coordinates Coordinates
    //    {
    //        get { return coordinates; }

    //        // TODO: Checks!
    //        set { coordinates = value; }
    //    }

    //    public abstract Cell[,] Detonate(int currentFieldSize, Cell[,] fieldPositions);

    //    //Checking if entered coordinates are valid
    //    public bool PrevIsValid(int coord)
    //    {
    //        bool result = (coord - 1) >= 0;
    //        return result;
    //    }

    //    public bool NextIsValid(int coord, int size)
    //    {
    //        bool result = (coord + 1) < size;
    //        return result;
    //    }
    //}
}
