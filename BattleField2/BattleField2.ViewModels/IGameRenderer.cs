namespace BattleField2.Renderers
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;

    public interface IGameRenderer
    {
        void DisplayMessage(string message);

        void DrawField(Field currentBattleField);

        string EnterCommand();

        void Wait();
    }
}
