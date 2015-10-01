namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Coordinates;

    public class MineFactory
    {
        // Refactor static methods!
        public static Explosive GetMine(MineType type, Coordinates currentCoordinates)
        {
            var currentMine = new Mine(currentCoordinates);
            var levelTwo = new MineLevelTwoUpgrade(currentMine);

            switch (type)
            {
                //case MineType.MineOne:
                //    break;
                case MineType.MineTwo:
                    return levelTwo;
                case MineType.MineThree:
                    currentMine = new MineThree(currentCoordinates);
                    break;
                case MineType.MineFour:
                    currentMine = new MineFour(currentCoordinates);
                    break;
                case MineType.MineFive:
                    currentMine = new MineFive(currentCoordinates);
                    break;
                default:
                    break;
            }
            return currentMine;
        }
    }
}
