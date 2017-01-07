using NConsoleGraphics;
using System;

namespace OOPGame
{

    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleGraphics graphics = new ConsoleGraphics();
            Console.WindowWidth = 50;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
            Menu.MainMenu(graphics);
        }
    }
}
