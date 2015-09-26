namespace BattleField2.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    //TODO
    [TestClass]
    public class MineTypesTests
    {
        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelOne()
        {
            var mineMock = new Mock<Mine>(); //basic Mine class 
            var levelOneupgrade = new TypeOneUpgrade(mineMock.Object); //Decorated Mine object
        }

        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelTwo()
        {
        }

        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelThree()
        {
        }

        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelFour()
        {
        }

        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelFive()
        {
        }
    }
}
