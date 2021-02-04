using System;
using System.Text;

using ConsoleImplementation.Helpers;
using ConsoleImplementation.Models;

namespace ConsoleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            new MainMenu();
        }
    }
}
