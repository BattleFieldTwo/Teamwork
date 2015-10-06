using BattleField2.Models.Mines;

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
            // TODO: Make a full property and checks to this!
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
            this.renderer.DisplayMessage(Constants.WELCOMEMESSAGE);
            int currentFieldSize = this.EnterFieldSize();

            this.battleField = new Field(currentFieldSize);

            this.battleField.GenerateField();

            this.battleField.PositionMines();

            this.renderer.DrawField(battleField);
        }

        public void PlayGame()
        {
            this.renderer.DisplayMessage(Constants.MINESCOUNTMESSAGE + this.battleField.InitialMines);

            int remainingMines;
            do
            {
                Coordinates currentCoordinates;

                do
                {
                    currentCoordinates = this.EnterInputCoordinates();

                    if (!this.battleField.ValidateMoveCoordinates(currentCoordinates))
                    {
                        this.renderer.DisplayMessage(Constants.INVALIDMOVENOTIFICATIONMESSAGE);
                    }
                } while (!this.battleField.ValidateMoveCoordinates(currentCoordinates));

                this.battleField.FieldPositions = (this.battleField.FieldPositions[currentCoordinates.Row, currentCoordinates.Col] as Explosive).Detonate(
                    this.battleField.FieldPositions, currentCoordinates);

                this.battleField.DetonatedMines++;

                this.renderer.DrawField(this.battleField);

                remainingMines = this.battleField.CountRemainingMines();
                this.renderer.DisplayMessage(Constants.MINESCOUNTMESSAGE + remainingMines);

            } while (remainingMines > 0);

            this.GameOver();
        }

        private int EnterFieldSize()
        {
            string inputFieldSize;
            do
            {
                this.renderer.DisplayMessage(Constants.INVITETOENTERSIZEMESSAGE);
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
                this.renderer.DisplayMessage(Constants.INVITETOENTERCOORDINATESMESSAGE);

                string coordinates = this.renderer.EnterCommand();
                if (!Validations.IsValidInputCoordinates(coordinates, this.battleField.FieldPositions.GetLength(0)))
                {
                    this.renderer.DisplayMessage(Constants.INVALIDMOVENOTIFICATIONMESSAGE);
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
            this.renderer.DisplayMessage(Constants.GAMEOVERMESSAGE + this.battleField.DetonatedMines);
            this.renderer.Wait();
            this.InitializeGame();
            this.PlayGame();
        }
    }
}
