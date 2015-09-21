namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Contracts;
    using BattleField2.Models.Coordinates;

    public class MineFactory
    {
        // Refactor static methods!
        public static Mine GetMine(MineType type, Coordinates currentCoordinates)
        {
            Mine currentMine = null;

            switch (type)
            {
                case MineType.MineOne:
                    currentMine = new MineOne(currentCoordinates);
                    break;
                case MineType.MineTwo:
                    currentMine = new MineTwo(currentCoordinates);
                    break;
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
