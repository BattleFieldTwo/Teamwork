namespace BattleField2.ViewModels
{
    using System;

    using BattleField2.ViewModels.Contracts;
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    using BattleField2.Common;

    public class ConsoleView : IViewModel
    {
        // Implemented Sigleton DP here
        private static ConsoleView instance;

        private ConsoleView() { }

        public static ConsoleView Instance()
        {
            if (instance == null)
            {
                instance = new ConsoleView();
            }
            return instance;
        }


        public void DisplayWelcomeMessage(string welcomeMessage)
        {
            Console.WriteLine(welcomeMessage);
        }

        public int GetFieldSize(string inviteToGiveSizeMessage)
        {
            string inputFieldSize;
            do
            {
                Console.Write(inviteToGiveSizeMessage);
                inputFieldSize = Console.ReadLine();
            } while (!Validations.InputFieldSizeIsValid(inputFieldSize));

            int currentFieldSize = Int32.Parse(inputFieldSize);

            return currentFieldSize;
        }

        public void DrawField(Field currentBattleField)
        {
            int currentFieldSize = currentBattleField.FieldPositions.GetLength(0);
                //top side numbers
            Console.Write("   ");
            for (int i = 0; i < currentFieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("");

            Console.Write("    ");
            for (int i = 0; i < 4 * currentFieldSize - 3; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");

            Console.WriteLine("");

            for (int i = 0; i < currentFieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < currentFieldSize; j++)
                {
                    Console.Write(" " + currentBattleField.FieldPositions[i, j].StringRepresentation);
                }
                Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            }
        }

        public Coordinates GetInputCoordinates(string inviteToEnterCoordinatesMessage)
        {
            string coordinates;
            Console.Write(inviteToEnterCoordinatesMessage);
            coordinates = Console.ReadLine();

            // TODO: Check if the input is in valid format!!!

            int rowCoord = Convert.ToInt32(coordinates.Substring(0, 1));
            int colCoord = Convert.ToInt32(coordinates.Substring(2, 1));
            Coordinates currentCoordinates = new Coordinates(rowCoord, colCoord);

            return currentCoordinates;
        }

        public void NotifyForInvalidMove(string invalidMoveNotificationMessage)
        {
            Console.WriteLine(invalidMoveNotificationMessage);
        }

        public void GameOver(string gameOverMessage, int detonatedMines)
        {
            Console.WriteLine(gameOverMessage + detonatedMines);
            Console.ReadKey();
        }

        public void GiveMinesCount(int count)
        {
            Console.WriteLine(Constants.MinesCountMessage + count);
        }
    }
}
