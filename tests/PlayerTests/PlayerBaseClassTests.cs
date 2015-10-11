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
        public void VerifyThatPlayerNameIsSetToNullIfEmptyConstructorIsUsed()
        {
            var player = new Player();

            Assert.IsNull(player.Name);
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

        [TestMethod]
        public void VerifyThatPlayerScoreIsSetCorrectlyIfValidDataIsProvided_Zero()
        {
            var name = "JohnDoe";
            var zeroScore = 0;
            var player = new Player(name);
            player.Score = zeroScore;


            Assert.AreEqual(player.Score, zeroScore);
        }

        [TestMethod]
        public void VerifyThatPlayerScoreIsSetCorrectlyIfValidDataIsProvided_ValidScoreNotZero()
        {
            var name = "JohnDoe";
            var validScore = 25;
            var player = new Player(name);
            player.Score = validScore;


            Assert.AreEqual(player.Score, validScore);
        }

        [TestMethod]
        public void VerifyThatCalculateScoreMethodReturnsZeroIfMineDifferenceIsOne()
        {

           var player = new Player();

            var initialMinesCount = 3;
            var finalMinesCount = 2;

            var playerScore = player.CalculateScore(initialMinesCount, finalMinesCount);

            Assert.AreEqual(playerScore, 1);
   
        }

        [TestMethod]
        public void VerifyThatCalculateScoreMethodReturnsProperValueIfMinesDifferenceIsMoreThanOne()
        {

            var player = new Player();

            var initialMinesCount = 5;
            var finalMinesCount = 2;
            var differenceInMinesDetonated = initialMinesCount - finalMinesCount;

            var calculatedScore = 1 + (differenceInMinesDetonated - 1) * 2;

            var playerScore = player.CalculateScore(initialMinesCount, finalMinesCount);

            Assert.AreEqual(playerScore, calculatedScore);

        }
    }
}
