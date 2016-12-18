using NConsoleGraphics;
using System;

namespace OOPGame
{

    public class Program
    {

        static void Main(string[] args)
        {

            Console.WindowWidth = 50;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();
            graphics.DrawString("Start", "Arial", 0xFFFF00FF, 50, 50);
            graphics.FillRectangle(0xFFFF0000, 50, 50, 60, 30);
            GameEngine engine = new SampleGameEngine(graphics);
             engine.Start();
        }
    }
}
