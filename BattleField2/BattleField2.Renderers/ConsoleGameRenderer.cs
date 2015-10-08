namespace BattleField2.Renderers
{
    using BattleField2.Common;
    using System;

    public class ConsoleGameRenderer : IGameRenderer
    {
        private static ConsoleGameRenderer instance;
        private int displayedMessages;

        private ConsoleGameRenderer() 
        {
            this.displayedMessages = 0;
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
            Console.SetCursorPosition(Constants.MESSAGE_LEFT_POSSITION, Constants.MESSAGE_TOP_POSSITION + this.displayedMessages);
            Console.Write(message);
            this.displayedMessages++;
        }

        public void Clear()
        {
            this.displayedMessages = 0;
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
            
            this.Clear();
            Console.Write(new string(' ', 3));
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


        public void SetSize(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}