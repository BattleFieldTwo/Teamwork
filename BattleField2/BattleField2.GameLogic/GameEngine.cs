namespace BattleField2.GameLogic
{
    using BattleField2.Common;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Field;
    using BattleField2.Renderers;
    using BattleField2.ViewModels.Contracts;
    using BattleField2.Models.Mines;
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
            this.renderer.DisplayMessage(Constants.WelcomeMessage);
            int currentFieldSize = this.EnterFieldSize();

            this.battleField = new Field(currentFieldSize);

            this.battleField.GenerateField();

            this.battleField.PositionMines();

            this.renderer.DrawField(battleField);
        }

        public void PlayGame()
        {
            this.renderer.DisplayMessage(Constants.MinesCountMessage + this.battleField.InitialMines);

            int remainingMines;
            do
            {
                Coordinates currentCoordinates;

                do
                {
                    currentCoordinates = this.EnterInputCoordinates();

                    if (!this.battleField.ValidateMoveCoordinates(currentCoordinates))
                    {
                        this.renderer.DisplayMessage(Constants.InvalidMoveNotificationMessage);
                    }
                } while (!this.battleField.ValidateMoveCoordinates(currentCoordinates));

                this.battleField.FieldPositions = (this.battleField.FieldPositions[currentCoordinates.Row, currentCoordinates.Col] as Mine).Detonate(
                    this.battleField.CurrentFieldSize, this.battleField.FieldPositions);

                this.battleField.DetonatedMines++;

                this.renderer.DrawField(this.battleField);

                remainingMines = this.battleField.CountRemainingMines();
                this.renderer.DisplayMessage(Constants.MinesCountMessage + remainingMines);

            } while (remainingMines > 0);

            this.GameOver();
        }

        private int EnterFieldSize()
        {
            string inputFieldSize;
            do
            {
                this.renderer.DisplayMessage(Constants.InviteToEnterSizeMessage);
                inputFieldSize = this.renderer.EnterCommand();
            } while (!Validations.IsValidInputFieldSize(inputFieldSize));

            int currentFieldSize = Int32.Parse(inputFieldSize);

            return currentFieldSize;
        }

        //TODO refactor this method
        private Coordinates EnterInputCoordinates()
        {
            Coordinates currentCoordinates;

            do
            {
                this.renderer.DisplayMessage(Constants.InviteToEnterCoordinatesMessage);

                string coordinates = this.renderer.EnterCommand();
                if (!Validations.IsValidInputCoordinates(coordinates, this.battleField.CurrentFieldSize))
                {
                    this.renderer.DisplayMessage(Constants.InvalidMoveNotificationMessage);
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
            this.renderer.DisplayMessage(Constants.GameOverMessage + this.battleField.DetonatedMines);
            this.renderer.Wait();
        }
    }
}
