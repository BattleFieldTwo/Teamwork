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
        public void CheckIfIExplosiveDetonateMethodReturnsProperResult()
        {
            var fieldPositions = new Cell[4, 4];
            //var currentCellFactory = CellFactory.Instance();
            // These coordinates should be the position of the mine
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mineMock = new Mock<IExplosive> (); 
            //mineMock = new MineLevelOneUpgrade(); //Decorated Mine object
            mineMock.Setup(m => m.Detonate(fieldPositions, currentCoordinates)).Returns(testCell);
            Assert.AreEqual(mineMock.Object.Detonate(fieldPositions, currentCoordinates), testCell);
        }

        [TestMethod]
        public void CheckIfStringRepresentationMethodWorksReturnsAProperValue_MineLevelOneUpgrade()
        {
            var mineLevelOne = new MineLevelOneUpgrade();

            Assert.AreEqual(mineLevelOne.StringRepresentation, " 1 ");
        }

        [TestMethod]
        public void CheckIfStringRepresentationMethodWorksReturnsAProperValue_MineLevelTwoUpgrade()
        {
            var mineLevelOne = new MineLevelTwoUpgrade();

            Assert.AreEqual(mineLevelOne.StringRepresentation, " 2 ");
        }

        [TestMethod]
        public void CheckIfStringRepresentationMethodWorksReturnsAProperValue_MineLevelThreeUpgrade()
        {
            var mineLevelOne = new MineLevelThreeUpgrade();

            Assert.AreEqual(mineLevelOne.StringRepresentation, " 3 ");
        }

        [TestMethod]
        public void CheckIfStringRepresentationMethodWorksReturnsAProperValue_MineLevelFourUpgrade()
        {
            var mineLevelOne = new MineLevelFourUpgrade();

            Assert.AreEqual(mineLevelOne.StringRepresentation, " 4 ");
        }


        [TestMethod]
        public void CheckIfStringRepresentationMethodWorksReturnsAProperValue_MineLevelFiveUpgrade()
        {
            var mineLevelOne = new MineLevelFiveUpgrade();

            Assert.AreEqual(mineLevelOne.StringRepresentation, " 5 ");
        }
    }
}
