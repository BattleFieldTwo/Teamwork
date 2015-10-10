namespace BattleField2.Renderers
{
    using System;
    /// <summary>
    /// This class holds some configuration details related to the color rendering in the application.
    /// </summary>
    class ColorConfig
    {
        /// <summary>
        /// Method that sets the Console color based on given string.
        /// </summary>
        /// <param name="color">String value representing a Color name to be parsed.</param>
        /// <returns>New object of type ConsoleColor to be implemented as a new color setting by the console.</returns>
        public static ConsoleColor SetColor(string color)
        {
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        }
    }
}
