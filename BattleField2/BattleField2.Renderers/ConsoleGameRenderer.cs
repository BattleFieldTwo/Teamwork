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

        private void DrawCell(string cellContent)
        {
            if (cellContent == " - ")
            {
                Console.ForegroundColor = ColorConfig.SetColor(Constants.EMPTY_CELL_COLOR);
                Console.Write(" " + cellContent);
                Console.ResetColor();
            }
            else if (cellContent == " X ")
            {
                Console.ForegroundColor = ColorConfig.SetColor(Constants.EXPLODED_CELL_COLOR);
                Console.Write(" " + cellContent);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ColorConfig.SetColor(Constants.MINE_CELL_COLOR);
                Console.Write(" " + cellContent);
                Console.ResetColor();
            }
        }

        public void DrawField(Models.Cells.Cell[,] fieldPositions)
        {
            Console.ForegroundColor = ColorConfig.SetColor(Constants.DEFAULT_COLOR);
            int fieldSize = fieldPositions.GetLength(0); 
            
            this.Clear();
            Console.Write(new string(' ', 3));
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" " + i + "  ");
            }
            Console.WriteLine("\n    " + new string('-', 4 * fieldSize - 3) + "|\n");
            Console.ResetColor();
            for (int i = 0; i < fieldSize; i++)
            {
                Console.ForegroundColor = ColorConfig.SetColor(Constants.DEFAULT_COLOR);
                Console.Write(i + "|");
                Console.ResetColor();
                for (int j = 0; j < fieldSize; j++)
                {
                    DrawCell(fieldPositions[i, j].StringRepresentation);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|\n\n");
                Console.ResetColor();
            }
        }


        public void SetSize(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}