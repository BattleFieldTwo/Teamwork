namespace BattleField2.GameLogic
{
    using BattleField2.Common;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Field;
    using BattleField2.Models.Mines;
    using BattleField2.Renderers;
    using System;

    public class GameEngine
    {
        private readonly IGameRenderer renderer;
        private Field battleField;
        private static GameEngine instance;

        private GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
        }

        public static GameEngine Instance(IGameRenderer renderer)
        {
            if (instance == null)
            {
                instance = new GameEngine(renderer);
            }

            return instance;
        }

        public void InitializeGame()
        {
            this.renderer.Clear();
            this.renderer.DisplayMessage(Constants.WELCOME_MESSAGE);
            int currentFieldSize = this.EnterFieldSize();

            this.battleField = new Field(currentFieldSize);

            this.battleField.GenerateField();

            this.battleField.PositionMines();

            this.renderer.DrawField(this.battleField.FieldPositions);
        }

        public void PlayGame()
        {
            int remainingMines = this.battleField.CountRemainingMines();
            this.renderer.DisplayMessage(Constants.MINES_COUNT_MESSAGE + remainingMines);

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

                this.battleField.FieldPositions = (this.battleField.FieldPositions[currentCoordinates.Row, currentCoordinates.Col] as Explosive).Detonate(
                    this.battleField.FieldPositions, currentCoordinates);

                this.battleField.DetonatedMines++;

                this.renderer.DrawField(this.battleField.FieldPositions);

                remainingMines = this.battleField.CountRemainingMines();
                this.renderer.DisplayMessage(Constants.MINES_COUNT_MESSAGE + remainingMines);

            } while (remainingMines > 0);

            this.GameOver();
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

        public void GameOver()
        {
            this.renderer.DisplayMessage(Constants.GAME_OVER_MESSAGE + this.battleField.DetonatedMines);
            this.renderer.Wait();
            this.InitializeGame();
            this.PlayGame();
        }
    }
}
