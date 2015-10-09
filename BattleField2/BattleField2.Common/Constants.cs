/// <summary>
/// Namespace that holds general information - CONSTANTS, Data validations etc.
/// </summary>
namespace BattleField2.Common
{
    /// <summary>
    /// This class consists of predefined CONSTANT values that we use
    /// in the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Predefined game start up welcoming message. 
        /// </summary>
        public const string WELCOME_MESSAGE = "Welcome to the Battle Field game";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string INVITE_TO_ENTER_SIZE_MESSAGE = "Enter legal size of board: ";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string INVITE_TO_ENTER_NAME_MESSAGE = "Enter your name:  ";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string HI_MESSAGE = "Hi, ";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string INVITE_TO_ENTER_COORDINATES_MESSAGE = "Enter coordinates: ";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string MINES_COUNT_MESSAGE = "Mines count is: ";
        /// <summary>
        /// In-game information message.
        /// </summary>
        public const string SCORE_MESSAGE = "Score: ";

        /// <summary>
        /// In-game warning message.
        /// </summary>
        public const string INVALID_MOVE_NOTIFICATION_MESSAGE = "Invalid Move";
        /// <summary>
        /// In-game warning message.
        /// </summary>
        public const string GAME_OVER_MESSAGE = "Game Over. Detonated Mines: ";

        /// <summary>
        /// Console window width on start-up.
        /// NOTE: This will be set to the current system Console maximum width 
        /// in case of an exception.
        /// </summary>
        public const int APP_WIDTH = 90;
        /// <summary>
        /// Console window height on start-up.
        /// NOTE: This will be set to the current system Console maximum height 
        /// in case of an exception.
        /// </summary>
        public const int APP_HEIGHT = 45;

        /// <summary>
        /// Minimum field size property;
        /// </summary>
        public const int MIN_FIELDSIZE = 1;
        /// <summary>
        /// Maximum field-size property.
        /// </summary>
        public const int MAX_FIELDSIZE = 10;

        /// <summary>
        /// In-game messages left position coordinate.
        /// </summary>
        public const int MESSAGE_LEFT_POSSITION = 45;
        /// <summary>
        /// In-game messages top position coordinate.
        /// </summary>
        public const int MESSAGE_TOP_POSSITION = 10;

        /// <summary>
        /// Regex pattern that checks the validity of the Player name value on input.
        /// </summary>
        public const string PLAYER_NAME_REGEX_PATTERN = "[^a-zA-Z0-9]";
        /// <summary>
        /// Gives to ConsoleColor the color value for the EmptyCell type. 
        /// </summary>
        public const string EMPTY_CELL_COLOR = "Yellow";
        /// <summary>
        /// Gives to ConsoleColor the color value for the Mine cell type. 
        /// </summary>
        public const string MINE_CELL_COLOR = "Green";
        /// <summary>
        /// Gives to ConsoleColor the color value for the Exploded type. 
        /// </summary>
        public const string EXPLODED_CELL_COLOR = "Red";
        /// <summary>
        /// Gives to ConsoleColor the default color value. 
        /// </summary>
        public const string DEFAULT_COLOR = "Blue";
        /// <summary>
        /// Gives to ConsoleColor the default message color value.
        /// </summary>
        public const string DEFAULT_MESSAGE_COLOR = "DarkYellow";
    }
}
