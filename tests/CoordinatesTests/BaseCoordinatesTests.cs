namespace BattleField2.Tests.CoordinatesTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Coordinates;

    [TestClass]
    public class BaseCoordinatesTests
    {
        [TestMethod]
        public void TestIfCoordinatesToStringFunctionsProperly()
        {
            var coordinatesMock = new Coordinates(2, 1);

            Assert.AreEqual(coordinatesMock.ToString(), "2  1");

        }
    }
}
