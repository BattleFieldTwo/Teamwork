namespace BattleField2.Tests.FieldTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Models.Field;
    using Models.Coordinates;

    //using Telerik.JustMock;

    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void CheckIfGenerateFieldMethodIsBeingCalledProperly()
        {
            var fieldMock = new Mock<IField>();

            fieldMock.CallBase = true;
            fieldMock.Setup(f => f.GenerateField()).Verifiable();

            fieldMock.Object.GenerateField();

            fieldMock.VerifyAll();

        }


        [TestMethod]
        public void CheckIfPositionMinesMethodIsBeingCalledProperly()
        {
            var fieldMock = new Mock<IField>();

            fieldMock.CallBase = true;
            fieldMock.Setup(f => f.PositionMines()).Verifiable();

            fieldMock.Object.PositionMines();

            fieldMock.VerifyAll();

        }

        [TestMethod]
        public void CheckIfCountRemainingMinesMethodIsBeingCalledProperly()
        {
            var fieldMock = new Mock<IField>();

            fieldMock.CallBase = true;
            fieldMock.Setup(f => f.CountRemainingMines()).Returns(5);


            Assert.AreEqual(fieldMock.Object.CountRemainingMines(), 5);

        }


        [TestMethod]
        public void CheckIfValidateMoveCoordinatesMethodIsBeingCalledProperly()
        {
            var fieldMock = new Mock<IField>();
            var testCoordinates = new Coordinates(2, 3);

            fieldMock.CallBase = true;
            fieldMock.Setup(f => f.ValidateMoveCoordinates(testCoordinates)).Returns(true);


            Assert.IsTrue(fieldMock.Object.ValidateMoveCoordinates(testCoordinates));

        }


    }
}
