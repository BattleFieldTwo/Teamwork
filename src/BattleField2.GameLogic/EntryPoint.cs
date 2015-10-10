/// <summary>
/// Namespace that holds the main game logic and game engine.
/// </summary>
namespace BattleField2.GameLogic
{
    using BattleField2.Renderers;
    /// <summary>
    /// This class is just the entry point for the whole application.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Application entry point start up. 
        /// Here we Initialize the game and then start it.
        /// </summary>
        public static void Main()
        {
            IGameRenderer consoleRenderer = ConsoleGameRenderer.Instance;
            GameEngine gameEngine = GameEngine.Instance(consoleRenderer);
            gameEngine.GameMenu();
            //gameEngine.InitializeGame();
            //gameEngine.PlayGame();
        }
    }
}