namespace BattleField2.ViewModels.Contracts
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    /// <summary>
    /// 
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="welcomeMessage"></param>
        void DisplayWelcomeMessage(string welcomeMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inviteToGiveSizeMessage"></param>
        /// <returns></returns>
        int GetFieldSize(string inviteToGiveSizeMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentBattleField"></param>
        void DrawField(Field currentBattleField);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inviteToEnterCoordinatesMessage"></param>
        /// <returns></returns>
        Coordinates GetInputCoordinates(string inviteToEnterCoordinatesMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invalidMoveNotificationMessage"></param>
        void NotifyForInvalidMove(string invalidMoveNotificationMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameOverMessage"></param>
        /// <param name="detonatedMines"></param>
        void GameOver(string gameOverMessage, int detonatedMines);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        void GiveMinesCount(int count);
    }
}
