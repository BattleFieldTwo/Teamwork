using BattleField2.Models.Cells;

namespace BattleField2.Renderers
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    /// <summary>
    /// IGameRenderer interface to be implemented and inherited.
    /// </summary>
    public interface IGameRenderer
    {
        /// <summary>
        /// Method to handle the incoming messages to display.
        /// </summary>
        /// <param name="message">String input to be handled</param>
        void DisplayMessage(string message);

        /// <summary>
        /// Method that draws a gamefield based on given input array of cells.
        /// </summary>
        /// <param name="fieldPositions">Valid field positioning cells.</param>
        void DrawField(Cell[,] fieldPositions);

        /// <summary>
        /// Method that clears the input on the screen.
        /// </summary>
        void Clear();

        /// <summary>
        /// Method that accepts a given in-game command.
        /// </summary>
        /// <returns>Returns the result of the command input.</returns>
        string EnterCommand();

        /// <summary>
        /// Method that is used to hold the execution of the application.
        /// </summary>
        void Wait();

        /// <summary>
        /// Method that sets the size of the game window.
        /// </summary>
        /// <param name="width">Current window width.</param>
        /// <param name="height">Current window height.</param>
        void SetSize(int width, int height);
    }
}
