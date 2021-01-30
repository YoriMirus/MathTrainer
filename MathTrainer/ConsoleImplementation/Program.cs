using System;

using ConsoleImplementation.Helpers;

namespace ConsoleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(10, 10);
            Console.SetBufferSize(40, 30);
            Console.SetWindowSize(40, 30);
            ConsoleHelper.MakeFrame('|', '=');
            Console.ReadLine();
        }
    }
}
