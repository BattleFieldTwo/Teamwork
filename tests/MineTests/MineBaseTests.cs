namespace BattleField2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Mines;
    using Moq;

    [TestClass]
    public class MineBaseTests
    {
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
