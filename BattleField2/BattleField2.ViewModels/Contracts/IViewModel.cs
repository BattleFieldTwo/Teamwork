namespace BattleField2.ViewModels.Contracts
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;

    public interface IViewModel
    {
        void DisplayWelcomeMessage(string welcomeMessage);

        int GetFieldSize(string inviteToGiveSizeMessage);

        void DrawField(Field currentBattleField);

        Coordinates GetInputCoordinates(string inviteToEnterCoordinatesMessage);

        void NotifyForInvalidMove(string invalidMoveNotificationMessage);

        void GameOver(string gameOverMessage, int detonatedMines);

        void GiveMinesCount(int count);
    }
}
