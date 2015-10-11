namespace BattleField2.Models.Player
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    /// <summary>
    /// HighScore class handles the procedures involving the storage of the Players scores
    /// and their listing.
    /// </summary>
    public class HighScore
    {
        private readonly string filePath = Constants.HIGH_SCORE_FILE_PATH;
        private readonly int topListCount = 5;
        private List<Player> highScoreList = new List<Player>();

        private void ReadHighScoreFromFile()
        {
            if (!File.Exists(this.filePath))
            {
                File.Create(this.filePath).Close();
            }

            using (StreamReader reader = new StreamReader(this.filePath))
            {
                string[] line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(' ');
                    Player player = new Player();
                    player.Name = line[0];
                    player.Score = int.Parse(line[1]);

                    this.highScoreList.Add(player);
                }
            }
        }

        private void WriteHighScoreToFile()
        {
            StreamWriter writer = new StreamWriter(this.filePath);

            using (writer)
            {
                foreach (Player highscore in this.highScoreList)
                {
                    writer.WriteLine(highscore.Name + " " + highscore.Score);
                }
            }
        }

        private void SortHighScoreDesc()
        {
            this.highScoreList = this.highScoreList
                                    .OrderByDescending(s => s.Score)
                                    .ToList();
        }

        /// <summary>
        /// Method that reads the high score results from file.
        /// </summary>
        public HighScore()
        {
            this.ReadHighScoreFromFile();
        }

        /// <summary>
        /// Method that first sorts the current content of the highScoreList
        /// and then creates and formats a StringBuilder object to be returned as a string.
        /// </summary>
        /// <returns>Returns a string that represents a list of the top Player results.</returns>
        public string ListHighScore()
        {
            StringBuilder str = new StringBuilder();
            str.Append(new String(' ', Constants.MESSAGE_LEFT_POSSITION));
            str.Append(new String(' ', Constants.MESSAGE_LEFT_POSSITION) + "--=== HIGH SCORES ===--\n\n");

            if (this.highScoreList.Count == 0)
            {
                str.Append(new String(' ', Constants.MESSAGE_LEFT_POSSITION));
                str.Append("NO SCORES YET!\n");
            }
            for (int i = 0; i < this.highScoreList.Count; i++)
            {
                str.Append(new String(' ', Constants.MESSAGE_LEFT_POSSITION));
                str.Append(string.Format("Rank {0}: {1}, Score: {2}\n", i + 1, this.highScoreList[i].Name, this.highScoreList[i].Score));
            }

            return str.ToString();
        }

        /// <summary>
        /// Method that gets the current player score at the end of the game
        /// and adds it to the highScoreList.
        /// </summary>
        /// <param name="currentPlayer">Player object that represents the current player.</param>
        public void SaveHighScore(Player currentPlayer)
        {
            this.highScoreList.Add(currentPlayer);
            this.SortHighScoreDesc();

            if (this.highScoreList.Count > this.topListCount)
            {
                this.highScoreList.RemoveAt(this.topListCount);
            }

            this.WriteHighScoreToFile();
        }
    }
}
