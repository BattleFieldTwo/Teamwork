namespace BattleField2.Renderers
{
    using BattleField2.Models.Field;
    using System;

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
            Console.WriteLine(message);
        }

        public void DrawField(Field currentBattleField)
        {
            Console.Clear();
            Console.Write("   ");
            for (int i = 0; i < currentBattleField.CurrentFieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("\n    " + new string('-', 4 * currentBattleField.CurrentFieldSize - 3) + '\n');
            for (int i = 0; i < currentBattleField.CurrentFieldSize; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < currentBattleField.CurrentFieldSize; j++)
                {
                    Console.Write(" " + currentBattleField.FieldPositions[i, j].StringRepresentation);
                }
                Console.WriteLine("\n\n");
            }
        }

        public void Clear()
        {
            Console.Clear();
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