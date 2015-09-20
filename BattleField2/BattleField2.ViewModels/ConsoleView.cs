namespace BattleField2.ViewModels
{
    using System;

    using BattleField2.ViewModels.Contracts;
    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    using BattleField2.Common;

    public class ConsoleView : IViewModel
    {
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
            //top side numbers
            Console.Write("   ");
            for (int i = 0; i < currentBattleField.CurrentFieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("");

            Console.Write("    ");
            for (int i = 0; i < 4 * currentBattleField.CurrentFieldSize - 3; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //top side numbers


            Console.WriteLine("");

            for (int i = 0; i < currentBattleField.CurrentFieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < currentBattleField.CurrentFieldSize; j++)
                {
                    Console.Write(" " + currentBattleField.FieldPositions[i, j]);
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

            int XCoord = Convert.ToInt32(coordinates.Substring(0, 1));
            int YCoord = Convert.ToInt32(coordinates.Substring(2));
            Coordinates currentCoordinates = new Coordinates(YCoord, XCoord);

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
    }
}
