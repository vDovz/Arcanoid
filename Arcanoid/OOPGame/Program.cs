using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGame
{

    public class Program
    {

        static void Main(string[] args)
        {
            StartGame();
        }
        public static void StartGame()
        {
            Console.WindowWidth = 50;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
            ConsoleGraphics graphics = new ConsoleGraphics();
            graphics.FillRectangle(0xFFFF0000, 50, 50, 10, 10);
            GameEngine engine = new SampleGameEngine(graphics);
            engine.Start();
        }
    }
}
