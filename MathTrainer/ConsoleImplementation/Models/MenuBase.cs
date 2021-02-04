using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleImplementation.Models
{
    abstract class MenuBase
    {
        public ConsoleCursor MenuCursor { get; protected set; }
        public List<MenuOption> MenuOptions { get; protected set; }

        protected bool redisplayMenu;
        protected bool shutdown;

        public int WindowWidth { get; protected set; }
        public int WindowHeight { get; protected set; }

        protected abstract void Display();
        protected abstract void DisplayFrame();
        protected abstract void DisplaySelection();

        /// <summary>
        /// Sets the window size of the console to the menu window size.
        /// </summary>
        protected void SetWindowSize()
        {
            Console.SetWindowSize(WindowWidth , WindowHeight);
        }
    }
}
