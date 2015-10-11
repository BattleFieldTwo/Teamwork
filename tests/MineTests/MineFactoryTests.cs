namespace BattleField2.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Models.Coordinates;
    using Models.Cells;
    using Models.Mines;

    [TestClass]
    public class MineFactoryTests
    {
        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMine_LevelOne()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineOne);

            Assert.AreEqual(factoryMineOne.StringRepresentation, " 1 ");

        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMine_LevelTwo()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineTwo);

            Assert.AreEqual(factoryMineOne.StringRepresentation, " 2 ");
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMine_LevelThree()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineThree);

            Assert.AreEqual(factoryMineOne.StringRepresentation, " 3 ");
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMine_LevelFour()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineFour);

            Assert.AreEqual(factoryMineOne.StringRepresentation, " 4 ");
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMine_LevelFive()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineFive);

            Assert.AreEqual(factoryMineOne.StringRepresentation, " 5 ");
        }

        public void VerifyThatMineFactoryCreatesAProperMineByComparing_LevelOne()
        {
            var factoryMineOne = MineFactory.Instance().GetMine(MineType.MineOne);
            var mineLevelOne = new MineLevelOneUpgrade();

            Assert.AreEqual(factoryMineOne.StringRepresentation, mineLevelOne.StringRepresentation);

        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMineByComparing_LevelTwo()
        {
            var factoryMineTwo = MineFactory.Instance().GetMine(MineType.MineTwo);
            var mineLevelTwo = new MineLevelTwoUpgrade();

            Assert.AreEqual(factoryMineTwo.StringRepresentation, mineLevelTwo.StringRepresentation);
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMineByComparing_LevelThree()
        {
            var factoryMineThree = MineFactory.Instance().GetMine(MineType.MineThree);
            var mineLevelThree = new MineLevelThreeUpgrade();

            Assert.AreEqual(factoryMineThree.StringRepresentation, mineLevelThree.StringRepresentation);
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMineByComparing_LevelFour()
        {
            var factoryMineFour = MineFactory.Instance().GetMine(MineType.MineFour);
            var mineLevelFour = new MineLevelFourUpgrade();

            Assert.AreEqual(factoryMineFour.StringRepresentation, mineLevelFour.StringRepresentation);
        }

        [TestMethod]
        public void VerifyThatMineFactoryCreatesAProperMineByComparing_LevelFive()
        {
            var factoryMineFive = MineFactory.Instance().GetMine(MineType.MineFive);
            var mineLevelFive = new MineLevelFiveUpgrade();

            Assert.AreEqual(factoryMineFive.StringRepresentation, mineLevelFive.StringRepresentation);
        }
    }
}

