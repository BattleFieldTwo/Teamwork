namespace BattleField2.Renderers
{
    using BattleField2.Common;
    using System;
    /// <summary>
    /// ConsoleGameRenderer class implements the IGameRenderer interface and
    /// provides most of the main methods that we use inside the GameEngine class.
    /// </summary>
    public class ConsoleGameRenderer : IGameRenderer
    {
        private static ConsoleGameRenderer instance;
        private int displayedMessages;

        private ConsoleGameRenderer() 
        {
            this.displayedMessages = 0;
        }

        /// <summary>
        /// ConsoleGameRenderer that checks for an existing class instance 
        /// and creates it if missing. Returns the current instance in both cases.
        /// </summary>
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

        /// <summary>
        /// Method that gets a string and prints it as a message to the Console.
        /// </summary>
        /// <param name="message">Message to be printed on the Console.</param>
        public void DisplayMessage(string message)
        {
            Console.ForegroundColor = ColorConfig.SetColor(Constants.DEFAULT_MESSAGE_COLOR);
            Console.SetCursorPosition(Constants.MESSAGE_LEFT_POSSITION, Constants.MESSAGE_TOP_POSSITION + this.displayedMessages);
            Console.Write(message);
            this.displayedMessages++;
        }

        /// <summary>
        /// Method that clears the Console screen.
        /// </summary>
        public void Clear()
        {
            this.displayedMessages = 0;
            Console.Clear();
        }

        /// <summary>
        /// Method that waits for a user input as a command and returns that command.
        /// </summary>
        /// <returns>The command that was inputed.</returns>
        public string EnterCommand()
        {
            string inputCommand = Console.ReadLine();
            return inputCommand;
        }

        /// <summary>
        /// Method that is used to hold the execution of the application.
        /// </summary>
        public void Wait()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Method that draw a given cell from the game field.
        /// We get the cell content as an input parameter and then evaluate what to print
        /// and with what color based on that content.
        /// </summary>
        /// <param name="cellContent">Cell content to be printed.</param>
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

        /// <summary>
        /// Method that draws the whole game field.
        /// </summary>
        /// <param name="fieldPositions">Multi-dimensional array of Cell Objects that will build the game field.</param>
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

        /// <summary>
        /// Method that is used to set the size of the game field.
        /// NOTE: In case of unsupported width or height the game field
        /// size will be set to the maximum size for the current system
        /// Console.
        /// </summary>
        /// <param name="width">Game field width.</param>
        /// <param name="height">Game field height.</param>
        public void SetSize(int width, int height)
        {
            try
            {
                Console.WindowWidth = width;
                Console.WindowHeight = height;
            }
            catch(ArgumentOutOfRangeException e)
            {
                if(e.ParamName == "height")
                {
                    Console.WindowHeight = Console.LargestWindowHeight;
                }
                else
                {
                    Console.WindowWidth = Console.LargestWindowWidth;
                }
            }
        }
    }
}