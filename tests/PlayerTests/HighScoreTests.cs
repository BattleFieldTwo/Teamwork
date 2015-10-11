namespace BattleField2.Tests.PlayerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BattleField2.Models.Player;
    using System.IO;
    using System.Text;

    [TestClass]
    public class HighScoreTests
    {
        [TestMethod]
        public void VerifyThatPlayerResultIsSaved()
        {
            var highscore = new HighScore();
            var player = new Player("Pesho");
            player.Score = 1000;
            highscore.SaveHighScore(player);
            var output = highscore.ListHighScore();
            var isSaved = output.IndexOf("Pesho, Score: 1000");
            Assert.AreNotEqual(isSaved, -1);
        }

        [TestMethod]
        public void VerifyThatHighScoreFileIsCreatedIfNone()
        {
            File.Delete(@"..\..\highscore.txt");
            var highscore = new HighScore();
            var exists = File.Exists(@"..\..\highscore.txt");
            
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void VerifyThatLowScorePlayerIsNotRecorded()
        {
            var highscore = new HighScore();
            for (int i = 0; i < 5; i++)
            {
                var player = new Player("Pesho");
                player.Score = 1000;
                highscore.SaveHighScore(player);
            }
            
            var playerLow = new Player("Gosho");
            playerLow.Score = 10;
            highscore.SaveHighScore(playerLow);
            var output = highscore.ListHighScore();
            var isSaved = output.IndexOf("Gosho, Score: 10");

            Assert.AreEqual(isSaved, -1);
        }

        [TestMethod]
        public void VerifyThatHighScorePlayersAreListedCorrectly()
        {
            File.Delete(@"..\..\highscore.txt");
            var highscore = new HighScore();
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                var player = new Player("Pesho");
                player.Score = i;
                highscore.SaveHighScore(player);
                str.Append(string.Format("Rank {0}: {1}, Score: {2}\n", 5-i, player.Name, player.Score));
            }

            var output = highscore.ListHighScore();
            Assert.AreNotEqual(output, str);
        }
    }
}
