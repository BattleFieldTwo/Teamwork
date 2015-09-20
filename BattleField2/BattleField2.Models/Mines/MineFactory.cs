namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Contracts;
    using BattleField2.Models.Coordinates;

    public class MineFactory
    {
        public static IMine GetMine(int type, Coordinates currentCoordinates)
        {
            IMine currentMine = null;
            int col = currentCoordinates.Col;
            int row = currentCoordinates.Row;

            switch (type)
            {
                case 1:
                    currentMine = new MineOne(col, row);
                    break;
                case 2:
                    currentMine = new MineTwo(col, row);
                    break;
                case 3:
                    currentMine = new MineThree(col, row);
                    break;
                case 4:
                    currentMine = new MineFour(col, row);
                    break;
                case 5:
                    currentMine = new MineFive(col, row);
                    break;
                default:
                    break;
            }
            return currentMine;
        }
    }
}
