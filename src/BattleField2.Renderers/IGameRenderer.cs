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
        /// 
        /// </summary>
        /// <param name="message"></param>
        void DisplayMessage(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldPositions"></param>
        void DrawField(Cell[,] fieldPositions);

        /// <summary>
        /// 
        /// </summary>
        void Clear();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string EnterCommand();

        /// <summary>
        /// 
        /// </summary>
        void Wait();

        void SetSize(int width, int height);
    }
}
