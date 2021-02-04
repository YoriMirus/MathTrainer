using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleImplementation.Models
{
    class Rectangle
    {
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Creates a new rectangle object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int width, int height)
        {
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Displays the rectangle to the console.
        /// </summary>
        /// <param name="cursorLeft">CursorLeft position of the top left corner of the rectangle</param>
        /// <param name="cursorTop">CursorTop position of the top left corner of the rectangle</param>
        public void Display(int cursorLeft, int cursorTop)
        {
            StringBuilder line = new StringBuilder();

            for (int i = 0; i < Width - 2; i++)
                line.Append('━');

            Console.SetCursorPosition(cursorLeft, cursorTop);

            //Writing top corner
            Console.Write('┏');
            Console.Write(line.ToString());
            Console.WriteLine('┓');

            //Writing left and right corners
            for (int i = 0; i < Height - 2; i++)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop + 1 + i);
                Console.Write('┃');
                Console.SetCursorPosition(cursorLeft + Width - 1, cursorTop + 1 + i);
                Console.Write('┃');
            }

            //Writing bottom corner
            Console.SetCursorPosition(cursorLeft, cursorTop + Height - 1);

            Console.Write('┗');
            Console.Write(line.ToString());
            Console.WriteLine('┛');

        }
    }
}
