namespace BattleField2.Tests.CellTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Models.Cells;

    [TestClass]
    public class CellFactoryTests
    {
        [TestMethod]
        public void VerifyThatCellFactoryCreatesAProperCell_EmptyCell()
        {
            var factoryEmptyCell = CellFactory.Instance().GetCell(CellType.Empty);

            Assert.AreEqual(factoryEmptyCell.StringRepresentation, " - ");
        }

        [TestMethod]
        public void VerifyThatCellFactoryCreatesAProperCell_DetonatedCell()
        {
            var factoryDetonatedCell = CellFactory.Instance().GetCell(CellType.Detonated);

            Assert.AreEqual(factoryDetonatedCell.StringRepresentation, " X ");
        }

        [TestMethod]
        public void VerifyThatCellFactoryCreatesAProperCellByComparing_EmptyCell()
        {
            var factoryEmptyCell = CellFactory.Instance().GetCell(CellType.Empty);
            var emptyCell = new EmptyCell();

            Assert.AreEqual(factoryEmptyCell.StringRepresentation, emptyCell.StringRepresentation);
        }

        [TestMethod]
        public void VerifyThatCellFactoryCreatesAProperCellByComparing_DetonatedCell()
        {
            var factoryDetonatedCell = CellFactory.Instance().GetCell(CellType.Detonated);
            var detonatedCell = new DetonatedCell();

            Assert.AreEqual(factoryDetonatedCell.StringRepresentation, detonatedCell.StringRepresentation);
        }
    }
}
