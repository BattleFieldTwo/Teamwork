namespace BattleField2.GameLogic
{
    using BattleField2.Common;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Field;
    using BattleField2.Models.Mines;
    using BattleField2.Models.Player;
    using BattleField2.Renderers;
    using System;

    /// <summary>
    /// The application engine. This class does all the work and runs the game.
    /// </summary>
    public class GameEngine
    {

        private readonly IGameRenderer renderer;
        private Field battleField;
        private static GameEngine instance;
        private Player currentPlayer;
        private HighScore highScore = new HighScore();

        private GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
        }

        private int EnterFieldSize()
        {
            string inputFieldSize;
            do
            {
                this.renderer.DisplayMessage(Constants.INVITE_TO_ENTER_SIZE_MESSAGE);
                inputFieldSize = this.renderer.EnterCommand();
            } while (!Validator.IsValidInputFieldSize(inputFieldSize));

            int currentFieldSize = Int32.Parse(inputFieldSize);

            return currentFieldSize;
        }

        public void GameMenu()
        {
            this.renderer.SetSize(Constants.APP_WIDTH, Constants.APP_HEIGHT);
            this.renderer.Clear();
            string choice = "";
            do
            {
                this.renderer.DisplayMessage(Constants.WELCOME_MESSAGE);
                this.renderer.DisplayMessage("GAME MENU");
                this.renderer.DisplayMessage("1. START NEW GAME");
                this.renderer.DisplayMessage("2. HIGHSCORES");
                this.renderer.DisplayMessage("3. EXIT");
                this.renderer.DisplayMessage("\n");
                this.renderer.DisplayMessage("Enter your choice: ");
                choice = this.renderer.EnterCommand();

                switch (choice)
                {
                    case "1":
                        this.renderer.Clear();
                        this.EnterPlayerName();
                        this.renderer.DisplayMessage(Constants.HI_MESSAGE + this.currentPlayer.Name);
                        this.InitializeGame();
                        this.PlayGame();
                        break;
                    case "2":
                        this.renderer.Clear();
                        this.renderer.DisplayMessage(highScore.ListHighScore());
                        this.renderer.EnterCommand();
                        this.GameMenu();
                        break;
                    case "3":
                        this.renderer.Clear();
                        Environment.Exit(0);
                        break;
                }
            } while (!Validator.IsValidMenuChoice(3, choice));
        }

        private void EnterPlayerName()
        {
            string inputPlayerName;
            do
            {
                this.renderer.DisplayMessage(Constants.INVITE_TO_ENTER_NAME_MESSAGE);
                inputPlayerName = this.renderer.EnterCommand();
            } while (!Validator.isValidPlayerName(inputPlayerName));
            this.currentPlayer = new Player(inputPlayerName);
        }

        //TODO refactor this method
        private Coordinates EnterInputCoordinates()
        {
            Coordinates currentCoordinates;

            do
            {
                this.renderer.DisplayMessage(Constants.INVITE_TO_ENTER_COORDINATES_MESSAGE);

                string coordinates = this.renderer.EnterCommand();
                if (!Validator.IsValidInputCoordinates(coordinates, this.battleField.FieldPositions.GetLength(0)))
                {
                    this.renderer.DisplayMessage(Constants.INVALID_MOVE_NOTIFICATION_MESSAGE);
                    continue;
                }

                int rowCoord = Convert.ToInt32(coordinates.Substring(0, 1));
                int colCoord = Convert.ToInt32(coordinates.Substring(2, 1));
                currentCoordinates = new Coordinates(rowCoord, colCoord);
                break;

            } while (true);

            return currentCoordinates;
        }
        /// <summary>
        /// This method initializes the GameEngine renderer.
        /// </summary>
        /// <param name="renderer">Object of type IGameRenderer.</param>
        /// <returns>New GameEngine instance holding the IGameRenderer object.</returns>
        public static GameEngine Instance(IGameRenderer renderer)
        {
            if (instance == null)
            {
                instance = new GameEngine(renderer);
            }

            return instance;
        }
        /// <summary>
        /// This method does the necessary pre-game initialization before the game.
        /// Creates the game field. Generates the random mines. 
        /// Gets the current player name. Prints some information messages. 
        /// </summary>
        public void InitializeGame()
        {
            int currentFieldSize = this.EnterFieldSize();

            this.battleField = new Field(currentFieldSize);

            this.battleField.GenerateField();

            this.battleField.PositionMines();

            this.renderer.DrawField(this.battleField.FieldPositions);
        }
        /// <summary>
        /// This is the main method in our application.  
        /// This is the method that does all the work in the Game Engine.
        /// Gets the player input, prints messages, counts mines etc.
        /// </summary>
        public void PlayGame()
        {
            int remainingMines = this.battleField.CountRemainingMines();
            this.renderer.DisplayMessage(Constants.MINES_COUNT_MESSAGE + remainingMines);
            this.renderer.DisplayMessage(Constants.SCORE_MESSAGE + this.currentPlayer.Score);

            do
            {
                Coordinates currentCoordinates;

                do
                {
                    currentCoordinates = this.EnterInputCoordinates();

                    if (!this.battleField.ValidateMoveCoordinates(currentCoordinates))
                    {
                        this.renderer.DisplayMessage(Constants.INVALID_MOVE_NOTIFICATION_MESSAGE);
                    }
                } while (!this.battleField.ValidateMoveCoordinates(currentCoordinates));

                this.battleField.FieldPositions = (this.battleField.FieldPositions[currentCoordinates.Row, currentCoordinates.Col] as Mine).Detonate(
                    this.battleField.FieldPositions, currentCoordinates);

                this.battleField.DetonatedMines++;

                this.renderer.DrawField(this.battleField.FieldPositions);

                this.currentPlayer.Score += this.currentPlayer.CalculateScore(remainingMines, this.battleField.CountRemainingMines());
                remainingMines = this.battleField.CountRemainingMines();

                this.renderer.DisplayMessage(Constants.MINES_COUNT_MESSAGE + remainingMines);
                this.renderer.DisplayMessage(Constants.SCORE_MESSAGE + this.currentPlayer.Score);

            } while (remainingMines > 0);

            highScore.SaveHighScore(currentPlayer);
            this.GameOver();
        }
        
        /// <summary>
        /// Method that gets executed everytime the game ends.
        /// We get the end game messages from the Constants class and after that 
        /// we re-initialize the game.
        /// </summary>
        public void GameOver()
        {
            this.renderer.DisplayMessage(Constants.GAME_OVER_MESSAGE + this.battleField.DetonatedMines);
            this.renderer.Wait();
            this.InitializeGame();
            this.PlayGame();
        }
    }
}
