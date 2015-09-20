namespace BattleField2.GameLogic
{
    using System;

    using BattleField2.Common;
    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Contracts;
    using BattleField2.Models.Field;
    using BattleField2.Models.Mines;
    using BattleField2.ViewModels.Contracts;

    public class GameEngine
    {
        private readonly IViewModel renderer;
        private Field currentBattleField;
        private Coordinates currentCoordinates;
        private int currentFieldSize;

        public GameEngine(IViewModel renderer)
        {
            // TODO: Make a full property and checks to this!
            this.renderer = renderer;
        }

        public void InitializeGame()
        {
            this.renderer.DisplayWelcomeMessage(Constants.WelcomeMessage);

            this.currentFieldSize = this.renderer.GetFieldSize(Constants.InviteToGiveSizeMessage);

            this.currentBattleField = new Field(currentFieldSize);

            this.currentBattleField.GenerateField();

            this.currentBattleField.PositionMines();

            this.renderer.DrawField(currentBattleField);
        }
        
        public void PlayGame()
        {
            do
            {
                do
                {
                    this.currentCoordinates = this.renderer.GetInputCoordinates(Constants.InviteToEnterCoordinatesMessage);

                    if (!this.currentBattleField.ValidateMoveCoordinates(this.currentCoordinates))
                    {
                        this.renderer.NotifyForInvalidMove(Constants.InvalidMoveNotificationMessage);
                    }
                } while (!this.currentBattleField.ValidateMoveCoordinates(this.currentCoordinates));

                int mineValue = Convert.ToInt32(this.currentBattleField.FieldPositions[this.currentCoordinates.Row, this.currentCoordinates.Col]);

                IMine currentMine = MineFactory.GetMine(mineValue, currentCoordinates);

                this.currentBattleField.FieldPositions = currentMine.Detonate(this.currentBattleField.CurrentFieldSize,
                    this.currentBattleField.FieldPositions);

                this.currentBattleField.DetonatedMines++;
                
                this.renderer.DrawField(this.currentBattleField);

            } while (this.currentBattleField.CountRemainingMines() > 0);

            this.renderer.GameOver(Constants.GameOverMessage, this.currentBattleField.DetonatedMines);
        }
    }
}
