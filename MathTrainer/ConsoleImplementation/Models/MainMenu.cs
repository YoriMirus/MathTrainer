using System;
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

        public MainMenu()
        {
            CurrentSection = MainMenuSection.MainMenu;
            reDisplay = true;
            Start();
        }
        private void Start()
        {
            while (true)
            {
                if (reDisplay)
                {
                    ConsoleHelper.Clear();
                    Display();
                }

                WaitForInput();
            }
        }
        private void WaitForInput()
        {
            Console.ReadKey();
        }
        private void Display()
        {
            ConsoleHelper.MakeFrame('|', '=');
        }
    }
}
