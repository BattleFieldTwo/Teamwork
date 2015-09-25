namespace BattleField2.GameLogic
{
    using BattleField2.Common;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Field;
    using BattleField2.ViewModels.Contracts;

    public class GameEngine
    {
        private readonly IViewModel view;
        private Field currentBattleField;
        private static GameEngine instance;

        // Implemented Sigleton DP here
        private GameEngine(IViewModel view)
        {
            // TODO: Make a full property and checks to this!
            this.view = view;
        }

        public static GameEngine Instance(IViewModel view)
        {
            if (instance == null)
            {
                instance = new GameEngine(view);
            }
            return instance;
        }

        public void InitializeGame()
        {
            this.view.DisplayWelcomeMessage(Constants.WelcomeMessage);

            int currentFieldSize = this.view.GetFieldSize(Constants.InviteToGiveSizeMessage);

            this.currentBattleField = new Field(currentFieldSize);

            this.currentBattleField.GenerateField();

            this.currentBattleField.PositionMines();

            this.view.DrawField(currentBattleField);
        }
        
        public void PlayGame()
        {
            this.view.GiveMinesCount(this.currentBattleField.InitialMines);

            int remainingMines;
            do
            {
                Coordinates currentCoordinates;
                do
                {
                    currentCoordinates = this.view.GetInputCoordinates(Constants.InviteToEnterCoordinatesMessage);

                    if (!this.currentBattleField.ValidateMoveCoordinates(currentCoordinates))
                    {
                        this.view.NotifyForInvalidMove(Constants.InvalidMoveNotificationMessage);
                    }
                } while (!this.currentBattleField.ValidateMoveCoordinates(currentCoordinates));

                this.currentBattleField.FieldPositions = this.currentBattleField.FieldPositions[currentCoordinates.Row, currentCoordinates.Col].Detonate(
                    this.currentBattleField.CurrentFieldSize, this.currentBattleField.FieldPositions);
                
                this.currentBattleField.DetonatedMines++;
                
                this.view.DrawField(this.currentBattleField);

                remainingMines = this.currentBattleField.CountRemainingMines();
                this.view.GiveMinesCount(remainingMines);

            } while (remainingMines > 0);

            this.view.GameOver(Constants.GameOverMessage, this.currentBattleField.DetonatedMines);
        }
    }
}
