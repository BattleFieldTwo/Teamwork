namespace BattleField2.GameLogic
{
    using BattleField2.ViewModels.Contracts;
    using BattleField2.ViewModels;

    public class GameMain
    {
        public static void Main()
        {
            // Creating a renderer in the console.
            IViewModel renderer = new ConsoleView();

            GameEngine gameEngine = new GameEngine(renderer);

            gameEngine.InitializeGame();

            gameEngine.PlayGame();
        }
    }
}