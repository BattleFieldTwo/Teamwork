namespace BattleField2.ViewModels.Contracts
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    /// <summary>
    /// IViewModel interface to be inherited by a concrete ViewModel.
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Method to display the in-game messages.
        /// </summary>
        /// <param name="welcomeMessage">Message to be handled.</param>
        void DisplayWelcomeMessage(string welcomeMessage);

        /// <summary>
        /// Method to get the field size.
        /// </summary>
        /// <param name="inviteToGiveSizeMessage"></param>
        /// <returns>Returns field size.</returns>
        int GetFieldSize(string inviteToGiveSizeMessage);

        /// <summary>
        /// Method to draw the game field.
        /// </summary>
        /// <param name="currentBattleField">Field object to be drawn.</param>
        void DrawField(Field currentBattleField);

        /// <summary>
        /// Method to get input coordinates.
        /// </summary>
        /// <param name="inviteToEnterCoordinatesMessage"></param>
        /// <returns>Returns the new coordinates.</returns>
        Coordinates GetInputCoordinates(string inviteToEnterCoordinatesMessage);

        /// <summary>
        /// Method that notifies player on invalid move.
        /// </summary>
        /// <param name="invalidMoveNotificationMessage">Message to notify for invalid string.</param>
        void NotifyForInvalidMove(string invalidMoveNotificationMessage);

        /// <summary>
        /// Method that gets called at the end of the game.
        /// </summary>
        /// <param name="gameOverMessage"></param>
        /// <param name="detonatedMines"></param>
        void GameOver(string gameOverMessage, int detonatedMines);

        /// <summary>
        /// Method that gives the mines count.
        /// </summary>
        /// <param name="count"></param>
        void GiveMinesCount(int count);
    }
}
