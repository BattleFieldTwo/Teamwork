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


        public void DrawField(Models.Cells.Cell[,] fieldPositions)
        {
            int fieldSize = fieldPositions.GetLength(0); 
            
            Console.Clear();
            Console.Write("   ");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("\n    " + new string('-', 4 * fieldSize - 3) + '\n');
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.Write(" " + fieldPositions[i, j].StringRepresentation);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}