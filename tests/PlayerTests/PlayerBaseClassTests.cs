namespace BattleField2.Tests.PlayerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Player;

    [TestClass]
    public class PlayerBaseClassTests
    {
        [TestMethod]
        public void VerifyThatPlayerNameIsSetToNullIfInvalidDataIsProvided_EmptyString()
        {
            var player = new Player("");

            Assert.IsNull(player.Name);
        }

        [TestMethod]
        public void VerifyThatPlayerNameIsSetToNullIfInvalidDataIsProvided_InvalidStringSymbols()
        {
            var player = new Player("$#7jahs @");

            Assert.IsNull(player.Name);
        }

        [TestMethod]
        public void VerifyThatPlayerNameIsSetCorrectlyIfValidDataIsProvided()
        {
            var name = "JohnDoe";
            var player = new Player(name);

            Assert.AreEqual(player.Name, name);
        }

        [TestMethod]
        public void VerifyThatPlayerScoreIsSetTZeroIfInvalidDataIsProvided_NegativeNumber()
        {
            var name = "JohnDoe";
            var negativeScore = -1;
            var player = new Player(name);
            player.Score = negativeScore;


            Assert.AreEqual(player.Score, 0);
        }
    }
}
