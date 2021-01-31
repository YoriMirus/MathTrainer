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
        /// <summary>
        /// Whether to completely redisplay the menu.
        /// </summary>
        private bool reDisplay;
        private bool shutDown;

        public MainMenu()
        {
            ConsoleHelper.SetWindowSize(40, 20);
            CurrentSection = MainMenuSection.MainMenu;
            reDisplay = true;
            shutDown = false;
            Console.CursorVisible = false;



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
            Console.ReadKey();
        }
        private void Display()
        {
            if (reDisplay)
                DisplayFrame();

            DisplayOptions();
        }

        private void DisplayFrame()
        {
            ConsoleHelper.Clear();
            ConsoleHelper.MakeFrame('|', '=', ConsoleColor.Cyan);
            ConsoleHelper.WriteInCenter("Math trainer", ConsoleColor.Red, 2);

            Console.SetCursorPosition(0, 4);
            ConsoleHelper.FillALine("=", ConsoleColor.Cyan, 1);

            ConsoleHelper.WriteInCenter("Practice addition", ConsoleColor.Gray, 6);
            ConsoleHelper.WriteInCenter("Practice subtraction", ConsoleColor.Gray, 8);
            ConsoleHelper.WriteInCenter("Practice multiplication", ConsoleColor.Gray, 10);
            ConsoleHelper.WriteInCenter("Practice division", ConsoleColor.Gray, 12);

            reDisplay = false;
        }
        private void DisplayOptions()
        {

        }
    }
}
