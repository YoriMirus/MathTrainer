using System;

using ConsoleImplementation.Helpers;
using ConsoleImplementation.Models;

namespace ConsoleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetWindowSize(40, 20);
            new MainMenu();
            Console.ReadLine();
        }
    }
}
