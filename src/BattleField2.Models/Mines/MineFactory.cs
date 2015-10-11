namespace BattleField2.Models.Mines
{
    using BattleField2.Models.Coordinates;
    /// <summary>
    /// MineFactory class for the creation of the different mine types.
    /// </summary>
    public class MineFactory
    {
        private static MineFactory instance;
        private readonly Mine levelOne;
        private readonly Mine levelTwo;
        private readonly Mine levelThree;
        private readonly Mine levelFour;
        private readonly Mine levelFive;

        private MineFactory()
        {
            this.levelOne = new MineLevelOneUpgrade();
            this.levelTwo = new MineLevelTwoUpgrade();
            this.levelThree = new MineLevelThreeUpgrade();
            this.levelFour = new MineLevelFourUpgrade();
            this.levelFive = new MineLevelFiveUpgrade();
        }
        /// <summary>
        /// Method that creates and returns a MineFactory instance if none is present.
        /// </summary>
        /// <returns>The current MineFactory instance.</returns>
        public static MineFactory Instance()
        {
            if (instance == null)
            {
                instance = new MineFactory();
            }
            return instance;
        }
        /// <summary>
        /// Method that returns a given mine based on the input type.
        /// </summary>
        /// <param name="type">Mine type parameter.</param>
        /// <returns>Returns a Mine object based on the input type.</returns>
        public Mine GetMine(MineType type)
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
