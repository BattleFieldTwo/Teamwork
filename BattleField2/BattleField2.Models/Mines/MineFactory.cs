namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Contracts;
    using BattleField2.Models.Coordinates;

    public class MineFactory
    {
        public static IMine GetMine(int type, Coordinates currentCoordinates)
        {
            IMine currentMine = null;
            int x = currentCoordinates.Col;
            int y = currentCoordinates.Row;

            switch (type)
            {
                case 1:
                    currentMine = new MineOne(x, y);
                    break;
                case 2:
                    currentMine = new MineTwo(x, y);
                    break;
                case 3:
                    currentMine = new MineThree(x, y);
                    break;
                case 4:
                    currentMine = new MineFour(x, y);
                    break;
                case 5:
                    currentMine = new MineFive(x, y);
                    break;
                default:
                    break;
            }
            return currentMine;
        }
    }
}
