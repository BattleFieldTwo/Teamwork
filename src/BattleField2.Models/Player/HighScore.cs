namespace BattleField2.Models.Player
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class HighScore
    {
        private readonly string filePath = @"..\..\highscore.txt";
        private readonly int topListCount = 5;
        private List<Player> highScoreList = new List<Player>();

        public HighScore()
        {
            this.ReadHighScoreFromFile();
        }

        public void ListHighScore()
        {
            this.SortHighScoreDesc();

            for (int i = 0; i < this.highScoreList.Count; i++)
            {
                Console.WriteLine(string.Format("Rank {0}: {1}, Score: {2}", i + 1, this.highScoreList[i].Name, this.highScoreList[i].Score));
            }
        }

        public void SaveHighScore(Player currentPlayer)
        {
            this.highScoreList.Add(currentPlayer);

            if (this.highScoreList.Count > this.topListCount)
            {
                this.highScoreList.RemoveAt(this.topListCount - 1);
            }

            this.WriteHighScoreToFile();
        }

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
    }
}
