using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleImplementation.Helpers
{
    static class ConsoleHelper
    {
        #region WriteLine methods
        /// <summary>
        /// Writes text into the console with a specific color.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        public static void WriteLine(string text, ConsoleColor fontColor)
            => WriteLine(text, fontColor, Console.CursorLeft, Console.CursorTop);
        /// <summary>
        /// Writes text into the console on a specific position with a specific color.
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="fontColor">Color of the text</param>
        /// <param name="cursorLeft">Starting CursorLeft position</param>
        /// <param name="cursorTop">Starting CursorTop position</param>
        public static void WriteLine(string text, ConsoleColor fontColor, int cursorLeft, int cursorTop)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            (int, int) previousCursorPosition = (Console.CursorLeft, Console.CursorTop);

            Console.ForegroundColor = fontColor;
            Console.SetCursorPosition(cursorLeft, cursorTop);

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
    }
}
