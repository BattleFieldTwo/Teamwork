namespace BattleField2.Tests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Mines;
    using Models.Cells;
    using Models.Coordinates;
    using Moq;

    [TestClass]
    public class MineTypesTests
    {
        [TestMethod]
        public void CheckIfCreatingAMineWithALevelUpgradeWorksAsExpected_LevelOne()
        {
            var fieldPositions = new Cell[4, 4];
            var currentCellFactory = CellFactory.Instance();
            // These coordinates should be the position of the mine
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mineMock = new Mock<IExplosive> (); //basic Mine class 
            //mineMock = new MineLevelOneUpgrade(); //Decorated Mine object
            mineMock.Setup(m => m.Detonate(fieldPositions, currentCoordinates)).Returns(testCell);
            Assert.AreEqual(mineMock.Object.Detonate(fieldPositions, currentCoordinates), testCell);
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
