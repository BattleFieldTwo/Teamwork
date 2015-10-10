namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Coordinates;

    public class MineFactory
    {
        private static MineFactory instance;
        private readonly Explosive levelOne;
        private readonly Explosive levelTwo;
        private readonly Explosive levelThree;
        private readonly Explosive levelFour;
        private readonly Explosive levelFive;

        private MineFactory()
        {
            this.levelOne = new MineLevelOneUpgrade();
            this.levelTwo = new MineLevelTwoUpgrade();
            this.levelThree = new MineLevelThreeUpgrade();
            this.levelFour = new MineLevelFourUpgrade();
            this.levelFive = new MineLevelFiveUpgrade();
        }

        public static MineFactory Instance()
        {
            if (instance == null)
            {
                instance = new MineFactory();
            }
            return instance;
        }

        public Explosive GetMine(MineType type)
        {
            switch (type)
            {
                case MineType.MineOne:
                    return this.levelOne;
                case MineType.MineTwo:
                    return this.levelTwo;
                case MineType.MineThree:
                    return this.levelThree;
                case MineType.MineFour:
                    return this.levelFour;
                case MineType.MineFive:
                    return this.levelFive;
            }

            return null;
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
