using ConsoleImplementation.Models;
using System;
using System.Threading;

namespace ConsoleImplementation
{
    public class ResizeListener
    {
        public bool ShouldBreak { get; private set; } = false;

        private int width;
        private int height;

        public void WasResized(Object menuBaseObj)
        {
            MenuBase menu = menuBaseObj as MenuBase;
            if(menu == null)
            {
                throw new ArgumentException("You done goofed!", nameof(menuBaseObj));
            }

            width = menu.WindowWidth;
            height = menu.WindowHeight;

            while (true)
            {
                if (width != Console.WindowWidth || height != Console.WindowHeight)
                {
                    width = Console.WindowWidth;
                    height = Console.WindowHeight;

                    ShouldBreak = true;
                    menu.Start();
                }

                ShouldBreak = false;
                Thread.Sleep(1000);
            }
        }
    }
}
