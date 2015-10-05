namespace BattleField2.Common
{
    public static class Constants
    {
        public const string WELCOMEMESSAGE = "Welcome to the Battle Field game";
        public const string INVITETOENTERSIZEMESSAGE = "Enter legal size of board: ";
        public const string INVITETOENTERCOORDINATESMESSAGE = "Enter coordinates: ";
        public const string INVALIDMOVENOTIFICATIONMESSAGE = "Invalid Move";
        public const string GAMEOVERMESSAGE = "Game Over. Detonated Mines: ";
        public const string MINESCOUNTMESSAGE = "mines count is: ";
        public const string PLAYERNAMEREGEXPATTERN = "[^a-zA-Z0-9]";

        public const int MINFIELDSIZE = 1;
        public const int MAXFIELDSIZE = 10;
    }
}
