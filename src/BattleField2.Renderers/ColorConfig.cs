namespace BattleField2.Renderers
{
    using System;

    class ColorConfig
    {
        public static ConsoleColor SetColor(string color)
        {
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
    }
}
