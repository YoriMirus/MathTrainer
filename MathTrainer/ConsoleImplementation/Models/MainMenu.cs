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
        public MainMenu()
        {
            WindowWidth = 40;
            WindowHeight = 20;
            SetWindowSize();

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

        protected override void Display()
        {
            if (redisplayMenu)
                DisplayFrame();
            if (MenuCursor.CursorRefresh)
                DisplaySelection();
        }
        protected override void DisplayFrame()
        {
            Rectangle r = new Rectangle(WindowWidth, WindowHeight);
            r.Display(0, 0);

            Console.SetCursorPosition(0, 4);
            ConsoleHelper.MakeEdges("┣", "┫");
            Console.SetCursorPosition(0, 4);
            ConsoleHelper.FillALine("━", 1);

            Console.SetCursorPosition(0, 2);
            ConsoleHelper.WriteInCenter("Math trainer");

            redisplayMenu = false;
        }
        protected override void DisplaySelection()
        {
            for(int i = 0; i < MenuOptions.Count; i++)
            {
                MenuOptions[i].WriteInCenter(MenuCursor.LeftIndex, MenuCursor.TopIndex, (i * 2) + 6);
            }
            MenuCursor.SetCursorRefresh(false);
        }
    }
}
