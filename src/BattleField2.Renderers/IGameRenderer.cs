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
        void DisplayMessage(string message);

        void DrawField(Cell[,] fieldPositions);

        void Clear();

        string EnterCommand();

        void Wait();

        void SetSize(int width, int height);
    }
}
