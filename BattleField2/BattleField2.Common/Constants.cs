namespace BattleField2.Common
{
    public static class Constants
    {
        public const string WELCOME_MESSAGE = "Welcome to the Battle Field game";
        public const string INVITE_TO_ENTER_SIZE_MESSAGE = "Enter legal size of board: ";
        public const string INVITE_TO_ENTER_COORDINATES_MESSAGE = "Enter coordinates: ";
        public const string INVALID_MOVE_NOTIFICATION_MESSAGE = "Invalid Move";
        public const string GAME_OVER_MESSAGE = "Game Over. Detonated Mines: ";
        public const string MINES_COUNT_MESSAGE = "mines count is: ";
        public const string PLAYER_NAME_REGEX_PATTERN = "[^a-zA-Z0-9]";

        public const int APP_WIDTH = 90;
        public const int APP_HEIGHT = 45;

        public const int MIN_FIELDSIZE = 1;
        public const int MAX_FIELDSIZE = 10;

        public const int MESSAGE_LEFT_POSSITION = 45;
        public const int MESSAGE_TOP_POSSITION = 10;

        public const string EMPTY_CELL_COLOR = "Yellow";
        public const string MINE_CELL_COLOR = "Green";
        public const string EXPLODED_CELL_COLOR = "Red";
        public const string DEFAULT_COLOR = "Blue";
    }
}
