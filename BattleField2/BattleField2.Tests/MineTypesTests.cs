namespace BattleField2.Tests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Mines;
    using Models.Cells;
    using Moq;

    [TestClass]
    public class MineTypesTests
    {
        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelOne()
        {
            int currentFieldSize = 4;
            var fieldPositions = new Cell[4, 4];
            var currentCellFactory = CellFactory.Instance();
            var testCell = new Cell[1, 2];
            var mineMock = new Mock<Mine>(); //basic Mine class 
            //var levelOneUpgrade = new TypeOneUpgrade(mineMock.Object); //Decorated Mine object
            mineMock.Setup(m => m.Detonate(currentFieldSize, fieldPositions, currentCellFactory)).Returns(testCell);
            //Assert.AreEqual(levelOneUpgrade.Detonate(currentFieldSize, fieldPositions), testCell);
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
