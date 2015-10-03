namespace BattleField2.Renderers
{
    using System;

    using BattleField2.Models.Field;
    using BattleField2.Models.Coordinates;
    using BattleField2.Common;

    public class ConsoleGameRenderer : IGameRenderer
    {
        private static ConsoleGameRenderer instance;

        private ConsoleGameRenderer() 
        {
        }

        public static ConsoleGameRenderer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleGameRenderer();
                }

                return instance;
            }
        }

        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public void DrawField(Field currentBattleField)
        {
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

            Console.WriteLine("");

            for (int i = 0; i < currentBattleField.CurrentFieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < currentBattleField.CurrentFieldSize; j++)
                {
                    Console.Write(" " + currentBattleField.FieldPositions[i, j].StringRepresentation);
                }
                Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            }
        }

        public string EnterCommand()
        {
            string inputCommand = Console.ReadLine();
            return inputCommand;
        }

        public void Wait()
        {
            Console.ReadKey();
        }
    }
}