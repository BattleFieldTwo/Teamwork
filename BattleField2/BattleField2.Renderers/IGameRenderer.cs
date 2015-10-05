namespace BattleField2.Renderers
{
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;

    public interface IGameRenderer
    {
        void DisplayMessage(string message);

        void DrawField(Field currentBattleField);

        void Clear();

        string EnterCommand();

        void Wait();
    }
}
