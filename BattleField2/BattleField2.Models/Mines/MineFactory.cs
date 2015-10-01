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
            var levelThree = new MineLevelThreeUpgrade(levelTwo);

            switch (type)
            {
                case MineType.MineTwo:
                    return levelTwo;
                case MineType.MineThree:
                    return levelThree;
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

        //public static mine getmine(minetype type, coordinates currentcoordinates)
        //{
        //    mine currentmine = null;

        //    switch (type)
        //    {
        //        case minetype.mineone:
        //            currentmine = new mineone(currentcoordinates);
        //            break;
        //        case minetype.minetwo:
        //            currentmine = new minetwo(currentcoordinates);
        //            break;
        //        case minetype.minethree:
        //            currentmine = new minethree(currentcoordinates);
        //            break;
        //        case minetype.minefour:
        //            currentmine = new minefour(currentcoordinates);
        //            break;
        //        case minetype.minefive:
        //            currentmine = new minefive(currentcoordinates);
        //            break;
        //        default:
        //            break;
        //    }
        //    return currentmine;
        //}
    }
}
