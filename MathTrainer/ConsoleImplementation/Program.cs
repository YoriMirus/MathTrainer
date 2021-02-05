using System;
using System.Text;
using ConsoleImplementation.Models;

namespace ConsoleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            new MainMenu();
        }
    }
}
