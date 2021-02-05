﻿using System;
using System.Threading;
using System.Collections.Generic;
using ConsoleImplementation.Helpers;
using ConsoleImplementation.Enums;

namespace ConsoleImplementation.Models
{
    class MainMenu : MenuBase
    {
        ResizeListener resizeListener = new ResizeListener();

        private int prevHeight;
        private int prevWidth;
        private Thread resizeListenerThread;

        public MainMenu()
        {
            WindowWidth = 40;
            WindowHeight = 20;

            prevHeight = WindowHeight;
            prevWidth = WindowWidth;

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

            //resizeListenerThread = new Thread(new ParameterizedThreadStart(resizeListener.WasResized));
            //resizeListenerThread.Start(this);

            Start();
        }
        public override void Start()
        {
            while (!shutdown)
            {
                Display();
                WaitForInput();
            }
        }

        private void WaitForInput()
        {
            ConsoleKeyInfo cki;

            do
            {
                while(Console.KeyAvailable == false)
                {
                    Thread.Sleep(200);
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;

                    if (prevWidth != WindowWidth || prevHeight != WindowHeight)
                    {
                        Console.Clear();
                        prevHeight = WindowHeight;
                        prevWidth = WindowWidth;

                        redisplayMenu = true;
                        MenuCursor.CursorRefresh = true;
                        Display();
                    }
                }
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow);

            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    MenuCursor.MoveCursor(CursorMovementDirection.Up);
                    break;
                case ConsoleKey.DownArrow:
                    MenuCursor.MoveCursor(CursorMovementDirection.Down);
                    break;
            }
        }

        public override void Display()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            if (prevWidth != WindowWidth || prevHeight != WindowHeight)
            {
                Console.Clear();
                prevHeight = WindowHeight;
                prevWidth = WindowWidth;

                redisplayMenu = true;
                MenuCursor.CursorRefresh = true;
            }

            if (MenuCursor.CursorRefresh)
                DisplaySelection();
            if (redisplayMenu)
                DisplayFrame();
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
