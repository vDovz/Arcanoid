using NConsoleGraphics;
using System;
using System.Threading;

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
            CreateMenu();
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

        public static void CreateMenu()
        {
            int userinput = Menu.MainMenu();
            if (userinput == 1) StartGame();
            if (userinput == 2) Menu.ShowHighscore();
            if (userinput == 3) Environment.Exit(0);
        }
    }
}
