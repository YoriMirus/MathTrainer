using System;
using System.Text;

namespace ConsoleImplementation.Helpers
{
    static class ConsoleHelper
    {
        #region WriteLine methods
        /// <summary>
        /// Writes text into the console on a specific position with a specific color.
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="fontColor">Color of the text</param>
        /// <param name="cursorLeft">Starting CursorLeft position</param>
        /// <param name="cursorTop">Starting CursorTop position</param>
        public static void WriteLine(string text, ConsoleColor fontColor)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = fontColor;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }
        #endregion
        #region WriteInCenter methods
        /// <summary>
        /// Writes text in the center of the screen on the current line and jumps to the next one.
        /// </summary>
        /// <param name="text"></param>
        public static void WriteInCenter(string text) 
            => WriteInCenter(text, Console.ForegroundColor, Console.CursorTop);
        /// <summary>
        /// Writes text in the center of the screen on the current line and jumps to the next one.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        public static void WriteInCenter(string text, ConsoleColor fontColor)
            => WriteInCenter(text, fontColor, Console.CursorTop);
        /// <summary>
        /// Writes text into the center of the console in a specific color and jumps to the next line. After writing returns back to the previous color.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        /// <param name="cursorTop"></param>
        public static void WriteInCenter(string text, ConsoleColor fontColor, int cursorTop)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = fontColor;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, cursorTop);

            Console.WriteLine(text);

            Console.ForegroundColor = previousColor;
        }

        #endregion
        #region FillALine methods
        public static void FillALine(string text) => FillALine(text, Console.ForegroundColor, Console.CursorTop);
        /// <summary>
        /// Completely fills one line with text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        public static void FillALine(string text, ConsoleColor fontColor)
            => FillALine(text, fontColor, Console.CursorTop);
        /// <summary>
        /// Completely fills one line with text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        /// <param name="cursorTop"></param>
        public static void FillALine(string text, ConsoleColor fontColor, int cursorTop)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            StringBuilder textToDisplay = new StringBuilder();

            //Add +1 to the condition field in case Console.WindowWidth % text.Length > 0
            for(int i = 0; i < (Console.WindowWidth / text.Length) + 1; i++)
            {
                textToDisplay.Append(text);
            }
            textToDisplay.Remove(Console.WindowWidth - 1, text.Length);

            Console.ForegroundColor = fontColor;
            Console.SetCursorPosition(0, cursorTop);

            Console.WriteLine(textToDisplay.ToString());

            Console.ForegroundColor = previousColor;
        }

        #endregion
        #region MakeEdges methods

        public static void MakeEdges(string text) => MakeEdges(text, Console.ForegroundColor);
        /// <summary>
        /// Writes text into the edges of the console and jumps to the next line.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void MakeEdges(string text, ConsoleColor fontColor)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            if (text.Length * 2 > Console.WindowWidth)
                throw new ArgumentOutOfRangeException("text", "Text is too large to fit inside the line.");

            Console.ForegroundColor = fontColor;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(text);

            Console.SetCursorPosition(Console.WindowWidth - text.Length, Console.CursorTop);

            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        #endregion
        #region MakeFrame methods

        public static void MakeFrame(char leftRightEdge, char topBottomEdge)
        {
            FillALine(topBottomEdge.ToString());
            for(int i = 1; i < Console.WindowHeight - 2; i++)
            {
                MakeEdges(leftRightEdge.ToString());
            }
            FillALine(topBottomEdge.ToString());
        }

        #endregion
    }
}
