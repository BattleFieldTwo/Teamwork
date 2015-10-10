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
            var factoryMineOne =  MineFactory.Instance().GetMine(MineType.MineOne);

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
    }
}

