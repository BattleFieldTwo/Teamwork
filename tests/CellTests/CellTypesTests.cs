namespace BattleField2.Tests.CellTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BattleField2.Models.Cells;


    [TestClass]
    public class CellTypesTests
    {
        [TestMethod]
        public void CheckIfStringRepresentationMethodFunctions()
        {
            var baseCellmock = new Mock<Cell>();
            baseCellmock.Setup(b => b.StringRepresentation).Returns("test");
            var baceCellMockObject = baseCellmock.Object;

            Assert.AreEqual(baceCellMockObject.StringRepresentation, "test");

        }

        [TestMethod]
        public void CheckIfAnEmptyCellIsBeingCreatedWithTheProperStringRepresentation()
        {
            var emptyCell = new EmptyCell();

            Assert.AreEqual(emptyCell.StringRepresentation, " - ");
        }

        [TestMethod]
        public void CheckIfADetonatedyCellIsBeingCreatedWithTheProperStringRepresentation()
        {
            var detonatedCell = new DetonatedCell();

            Assert.AreEqual(detonatedCell.StringRepresentation, " X ");
        }
    }
}
