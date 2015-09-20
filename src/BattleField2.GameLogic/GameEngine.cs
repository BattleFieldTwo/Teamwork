namespace BattleField2.GameLogic
{
    using System;

    using BattleField2.Models.Contracts;
    using BattleField2.Models.Field;
    using BattleField2.Models.Mines;

    public class GameEngine
    {
        public static void Main()
        {
            string inputFieldSize;

            Console.WriteLine("Welcome to the Battle Field game");

            do
            {
                Console.Write("Enter legal size of board: ");
                inputFieldSize = Console.ReadLine();
            } while (!InputFieldSizeIsValid(inputFieldSize));

            int currentFieldSize = Int32.Parse(inputFieldSize);

            Field currentBattleField = new Field(currentFieldSize);
            currentBattleField.GenerateField();
            currentBattleField.PositionMines();
            DrawField(currentBattleField);


            string coordinates;
            int XCoord, YCoord;

            do
            {
                do
                {
                    Console.Write("Enter coordinates: ");
                    coordinates = Console.ReadLine();
                    XCoord = Convert.ToInt32(coordinates.Substring(0, 1));
                    YCoord = Convert.ToInt32(coordinates.Substring(2));

                    if ((XCoord < 0) || (YCoord > currentBattleField.CurrentFieldSize - 1) ||
                        (currentBattleField.FieldPositions[XCoord, YCoord] == " - "))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                } while ((XCoord < 0) || (YCoord > currentBattleField.CurrentFieldSize - 1) || (currentBattleField.FieldPositions[XCoord, YCoord] == " - "));

                int mineValue = Convert.ToInt32(currentBattleField.FieldPositions[XCoord, YCoord]);

                IMine currentMine = MineFactory.GetMine(mineValue, XCoord, YCoord);

                currentBattleField.FieldPositions = currentMine.Detonate(currentBattleField.CurrentFieldSize, currentBattleField.FieldPositions);

                currentBattleField.DetonatedMines++;
                DrawField(currentBattleField);

            } while (currentBattleField.CountRemainingMines() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + currentBattleField.DetonatedMines);
            Console.ReadKey();
        }

        private static bool InputFieldSizeIsValid(string inputFieldSize)
        {
            int fieldSize;
            if(!(Int32.TryParse(inputFieldSize, out fieldSize)))
            {
                return false;
            }
            else if (fieldSize < 0)
            {
                return false;
            }
            else if (fieldSize > 11)
            {
                return false;
            }

            return true;
        }

        private static void DrawField(Field currentField)
        {
            //top side numbers
            Console.Write("   ");
            for (int i = 0; i < currentField.CurrentFieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("");

            Console.Write("    ");
            for (int i = 0; i < 4 * currentField.CurrentFieldSize - 3; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //top side numbers


            Console.WriteLine("");

            for (int i = 0; i < currentField.CurrentFieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < currentField.CurrentFieldSize; j++)
                {
                    Console.Write(" " + currentField.FieldPositions[i, j]);
                }
                Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            }
        }
    }
}
