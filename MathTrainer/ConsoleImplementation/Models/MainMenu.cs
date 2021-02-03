using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

using ConsoleImplementation.Helpers;
using ConsoleImplementation.Enums;

namespace ConsoleImplementation.Models
{
    class MainMenu
    {
        public MainMenuSection CurrentSection { get; private set; }
        public ConsoleCursor MainMenuCursor { get; private set; }
        private List<MenuOption> menuOptions;
        /// <summary>
        /// Whether to completely redisplay the menu.
        /// </summary>
        private bool reDisplay;
        private bool shutDown;

        public MainMenu()
        {
            Console.SetWindowSize(40, 20);
            CurrentSection = MainMenuSection.MainMenu;
            reDisplay = true;
            shutDown = false;
            Console.CursorVisible = false;
            MainMenuCursor = new ConsoleCursor(0, 3);
            menuOptions = new List<MenuOption>()
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
            while (!shutDown)
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
                    MainMenuCursor.MoveCursor(CursorMovementDirection.Up);
                    break;
                case ConsoleKey.DownArrow:
                    MainMenuCursor.MoveCursor(CursorMovementDirection.Down);
                    break;
            }
        }
        private void Display()
        {
            if (reDisplay)
                DisplayFrame();
            if (MainMenuCursor.CursorRefresh)
                DisplayOptions();
        }

        private void DisplayFrame()
        {
            Console.Clear();
            ConsoleHelper.MakeFrame('|', '=', ConsoleColor.Cyan);
            ConsoleHelper.WriteInCenter("Math trainer", ConsoleColor.Red, 2);

            Console.SetCursorPosition(0, 4);
            ConsoleHelper.FillALine("=", ConsoleColor.Cyan, 1);

            reDisplay = false;
        }
        private void DisplayOptions()
        {
            for(int i = 0; i < menuOptions.Count; i++)
            {
                menuOptions[i].WriteInCenter(MainMenuCursor.TopIndex, (i * 2) + 6);
            }
            MainMenuCursor.SetCursorRefresh(false);

            /*ConsoleHelper.WriteInCenter("Practice addition", ConsoleColor.Gray, 6);
            ConsoleHelper.WriteInCenter("Practice subtraction", ConsoleColor.Gray, 8);
            ConsoleHelper.WriteInCenter("Practice multiplication", ConsoleColor.Gray, 10);
            ConsoleHelper.WriteInCenter("Practice division", ConsoleColor.Gray, 12);*/
        }
    }
}
