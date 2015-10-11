namespace BattleField2.Tests.FieldTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Models.Field;
    using Models.Coordinates;
    using Models.Cells;
    using Models.Mines;

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
        public void CheckIfGenerateFieldMethodSetsACellToAnEmptyOneInsideField()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);

            field.GenerateField();
            var testCell = field.FieldPositions[2, 3];
            var testEmptyCell = new EmptyCell();

            Assert.AreEqual(testCell.ToString(), testEmptyCell.ToString());

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

        [TestMethod]
        public void CheckIfFieldConstructorSetsProperFieldPositionsValue()
        {
            var testFieldSize = 4;
            var testFieldPositions = new Cell[testFieldSize, testFieldSize];
            var field = new Field(testFieldSize);

            Assert.AreEqual(field.FieldPositions.ToString(), testFieldPositions.ToString());

        }


        [TestMethod]
        public void CheckIfFieldConstructorSetsProperDetonatedMinesValue()
        {
            var testFieldSize = 4;
            var field = new Field(testFieldSize);

            Assert.AreEqual(field.DetonatedMines, 0);

        }

        [TestMethod]
        public void CheckIfPositionMinesMethodPositionsAtLeastOneMine()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);

            field.GenerateField();
            field.PositionMines();

            var countMines = 0;

            for (int i = 0; i < testFieldSize; i++)
            {
                for (int j = 0; j < testFieldSize; j++)
                {
                    if (field.FieldPositions[i, j] is Mine)
                    {
                        countMines++;
                    }
                }
            }

            Assert.AreNotEqual(countMines, 0);


        }

        [TestMethod]
        public void CheckIfCountRemainingMinesGivesANumberThatIsNotZeroAtTheStartOfTheGame()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);

            field.GenerateField();
            field.PositionMines();

            var countMines = 0;

            for (int i = 0; i < testFieldSize; i++)
            {
                for (int j = 0; j < testFieldSize; j++)
                {
                    if (field.FieldPositions[i, j] is Mine)
                    {
                        countMines++;
                    }
                }
            }

            Assert.AreNotEqual(field.CountRemainingMines(), 0);


        }


        [TestMethod]
        public void CheckIfValidateMovieCoordinatesReturnsCorrectly_InvalidCoordinates()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);
            var invalidCoordinates = new Coordinates(9, 9);
            field.GenerateField();

            Assert.IsFalse(field.ValidateMoveCoordinates(invalidCoordinates));

        }


        [TestMethod]
        public void CheckIfValidateMovieCoordinatesReturnsCorrectly_NegativeCoordinates()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);
            var zeroCoordinates = new Coordinates(-1, -2);
            field.GenerateField();

            Assert.IsFalse(field.ValidateMoveCoordinates(zeroCoordinates));

        }

        [TestMethod]
        public void CheckIfValidateMovieCoordinatesReturnsCorrectly_ValidCoordinates()
        {
            var testFieldSize = 9;
            var field = new Field(testFieldSize);

            field.GenerateField();
            field.PositionMines();

            Coordinates mineCell = new Coordinates();

            for (int i = 0; i < testFieldSize; i++)
            {
                for (int j = 0; j < testFieldSize; j++)
                {
                    if (field.FieldPositions[i, j] is Mine)
                    {
                        mineCell = new Coordinates(i, j);
                    }
                }
            }

            Assert.IsTrue(field.ValidateMoveCoordinates(mineCell));

        }

    }
}
