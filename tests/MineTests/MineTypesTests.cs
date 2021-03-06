﻿namespace BattleField2.Tests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Cells;
    using Models.Coordinates;
    using Models.Mines;
    using Moq;

    [TestClass]
    public class MineTypesTests
    {
        [TestMethod]
        public void CheckIfIExplosiveDetonateMethodReturnsProperResult()
        {
            var fieldPositions = new Cell[4, 4];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mineMock = new Mock<IExplosive> (); 
            mineMock.Setup(m => m.Detonate(It.IsAny<Cell[,]>(), It.IsAny<Coordinates>())).Returns(testCell);
            Assert.AreEqual(mineMock.Object.Detonate(fieldPositions, currentCoordinates), testCell);
        }

        [TestMethod]
        public void ValidateThatMineDetonateMethodFunctions()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var baseMineMock = new Mock<Mine>();
            baseMineMock.Setup(b => b.Detonate(It.IsAny<Cell[,]>(), It.IsAny<Coordinates>())).Verifiable();

            var mineMockObject = baseMineMock.Object;
            mineMockObject.Detonate(fieldPositions, currentCoordinates);
            baseMineMock.VerifyAll();
        }

        [TestMethod]
        public void ValidateThatMinеDetonateMethodFunctions_LevelOne()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mine = new MineLevelOneUpgrade();
            Assert.AreEqual(mine.Detonate(fieldPositions, currentCoordinates), fieldPositions);
        }

        [TestMethod]
        public void ValidateThatMinеDetonateMethodFunctions_LevelTwo()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mine = new MineLevelTwoUpgrade();
            Assert.AreEqual(mine.Detonate(fieldPositions, currentCoordinates), fieldPositions);
        }

        [TestMethod]
        public void ValidateThatMinеDetonateMethodFunctions_LevelThree()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mine = new MineLevelThreeUpgrade();
            Assert.AreEqual(mine.Detonate(fieldPositions, currentCoordinates), fieldPositions);
        }

        [TestMethod]
        public void ValidateThatMinеDetonateMethodFunctions_LevelFour()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mine = new MineLevelFourUpgrade();
            Assert.AreEqual(mine.Detonate(fieldPositions, currentCoordinates), fieldPositions);
        }

        [TestMethod]
        public void ValidateThatMinеDetonateMethodFunctions_LevelFive()
        {
            var fieldPositions = new Cell[3, 3];
            var currentCoordinates = new Coordinates(2, 2);
            var testCell = new Cell[1, 2];
            var mine = new MineLevelFiveUpgrade();
            Assert.AreEqual(mine.Detonate(fieldPositions, currentCoordinates), fieldPositions);
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
