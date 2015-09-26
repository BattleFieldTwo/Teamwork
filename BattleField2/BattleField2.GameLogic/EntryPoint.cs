namespace BattleField2.GameEngine
{
    using BattleField2.Renderers;

    public class EntryPoint
    {
        public static void Main()
        {
            IGameRenderer consoleRenderer = ConsoleGameRenderer.Instance;
            GameEngine gameEngine = GameEngine.Instance(consoleRenderer);

            gameEngine.InitializeGame();
            gameEngine.PlayGame();
        }
    }
}