namespace BattleField2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Mines;
    using Moq;

    [TestClass]
    public class MineBaseTests
    {
        [TestMethod]
        public void CheckIfDetonateMineBaseMethodFunctions()
        {
            //var fieldPositions = new Cell[3, 3];
            //var currentCoordinates = new Coordinates(2, 2);
            //var testCoordinates = new List<Coordinates>()
            //{

            //};
            //var testCell = new Cell[1, 2];
            //var baseMineMock = new Mock<Mine>();
            //baseMineMock.Setup(b => b.DetonateMineBase(It.IsAny<Cell[,]>(), It.IsAny<Coordinates>(), It.IsAny<int>(), It.IsAny<List<Coordinates>>())).Verifiable();

            //var mineMockObject = baseMineMock.Object;
            //mineMockObject.DetonateMineBase(fieldPositions, currentCoordinates, 1, testCoordinates);
            //baseMineMock.VerifyAll();

        }

        [TestMethod]
        public void CheckIfIsValidMethodReturnsFalseWhenNegativeValuesAreGiven()
        {
            var baseMineMock = new Mock<Mine>();
            var mineMockObject = baseMineMock.Object;
            bool isValid = mineMockObject.IsValid(-1, -2, -9);

            Assert.AreEqual(isValid, false);
        }

        [TestMethod]
        public void CheckIfIsValidMethodReturnsFalseWhenZeroValuesAreGiven()
        {
            var baseMineMock = new Mock<Mine>();
            var mineMockObject = baseMineMock.Object;
            bool isValid = mineMockObject.IsValid(0, 0, 0);

            Assert.AreEqual(isValid, false);
        }

        [TestMethod]
        public void CheckIfIsValidMethodReturnsTrueWhenValidValuesAreGiven()
        {
            var baseMineMock = new Mock<Mine>();
            var mineMockObject = baseMineMock.Object;
            bool isValid = mineMockObject.IsValid(2, 3, 8);

            Assert.AreEqual(isValid, true);
        }


        [TestMethod]
        public void CheckIfIsValidMethodReturnsFalseWhenFirstArgumentIsValidAndTheSecondArgumentIsInvalid()
        {
            var baseMineMock = new Mock<Mine>();
            var mineMockObject = baseMineMock.Object;
            bool isValid = mineMockObject.IsValid(3, 9, 8);

            Assert.AreEqual(isValid, false);
        }


        [TestMethod]
        public void CheckIfIsValidMethodReturnsFalseWhenFirstArgumentIsInvalidAndTheSecondArgumentIsValid()
        {
            var baseMineMock = new Mock<Mine>();
            var mineMockObject = baseMineMock.Object;
            bool isValid = mineMockObject.IsValid(9, 3, 8);

            Assert.AreEqual(isValid, false);
        }
    }
}
