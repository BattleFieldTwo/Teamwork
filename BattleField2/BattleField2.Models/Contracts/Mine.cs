namespace BattleField2.Models.Contracts
{
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Cells;

    public abstract class Mine : Cell
    {
        public Mine(Coordinates currentCoordinates)
            : base(currentCoordinates)
        {
        }
        
        //Checking if entered coordinates are valid
        public bool PrevIsValid(int coord)
        {
            bool result = (coord - 1) >= 0;
            return result;
        }

        public bool NextIsValid(int coord, int size)
        {
            bool result = (coord + 1) < size;
            return result;
        }
    }
}
