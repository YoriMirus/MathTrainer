using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

using ConsoleImplementation.Helpers;
using ConsoleImplementation.Enums;

namespace ConsoleImplementation.Models
{
    class MainMenu: MenuBase
    {
        /// <summary>
        /// Whether to completely redisplay the menu.
        /// </summary>

        public MainMenu()
        {
            WindowWidth = 40;
            WindowHeight = 20;
            Console.SetWindowSize(WindowWidth, WindowHeight);

            redisplayMenu = true;
            shutdown = false;
            Console.CursorVisible = false;

            MenuCursor = new ConsoleCursor(0, 3);
            MenuOptions = new List<MenuOption>()
            {
                new MenuOption("Practice addition", 0),
                new MenuOption("Practice subtraction", 1),
                new MenuOption("Practice multiplication", 2),
                new MenuOption("Practice division", 3)
            };

            Start();
        }
        private void Start()
        {
            while (!shutdown)
            {
                Display();
                WaitForInput();
            }
        }

        private void WaitForInput()
        {
            ConsoleKeyInfo press = Console.ReadKey();

            switch (press.Key)
            {
                case ConsoleKey.UpArrow:
                    MenuCursor.MoveCursor(CursorMovementDirection.Up);
                    break;
                case ConsoleKey.DownArrow:
                    MenuCursor.MoveCursor(CursorMovementDirection.Down);
                    break;
            }
        }
        private void Display()
        {
            if (redisplayMenu)
                DisplayFrame();
            if (MenuCursor.CursorRefresh)
                DisplayOptions();
        }

        private void DisplayFrame()
        {
            Console.Clear();
            ConsoleHelper.MakeFrame('|', '=', ConsoleColor.Cyan);
            ConsoleHelper.WriteInCenter("Math trainer", ConsoleColor.Red, 2);

            Console.SetCursorPosition(0, 4);
            ConsoleHelper.FillALine("=", ConsoleColor.Cyan, 1);

            redisplayMenu = false;
        }
        private void DisplayOptions()
        {
            for(int i = 0; i < MenuOptions.Count; i++)
            {
                MenuOptions[i].WriteInCenter(MenuCursor.TopIndex, (i * 2) + 6);
            }
            MenuCursor.SetCursorRefresh(false);
        }
    }
}
