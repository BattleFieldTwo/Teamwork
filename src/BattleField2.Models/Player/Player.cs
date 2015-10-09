namespace BattleField2.Models.Player
{
    using Common;
    using System;
    public class Player
    {
        private string name;
        private int score;

        private Player() { }

        public Player(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (Validator.isValidPlayerName(value))
                {
                    this.name = value;
                }
            }
        }
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (Validator.isValidPlayerScore(value))
                {
                    this.score = value;
                }
            }
        }

        public int CalculateScore(int previousMinesCount, int nextMinesCount)
        {
            int differenceInMinesDetonated = previousMinesCount - nextMinesCount;

            if (differenceInMinesDetonated == 1)
            {
                return 1;
            }
            else
            {
                return 1 + (differenceInMinesDetonated - 1) * 2; //can be changed
            }
        }
    }
}
