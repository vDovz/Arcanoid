using NConsoleGraphics;
using System;

namespace OOPGame
{
    class Menu
    {
        public static void MainMenu(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
            Button Start = new Button("Start Game", 130, 150, 120, 20, 0xFFFFFF00, graphics);
            Button Score = new Button("High Score", 130, 200, 120, 20, 0xFFFFFF00, graphics);
            Button Exit = new Button("Exit", 130, 250, 120, 20, 0xFFFFFF00, graphics);
            Start.AddToBoard(graphics);
            Score.AddToBoard(graphics);
            Exit.AddToBoard(graphics);
            graphics.FlipPages();
            bool isSelected = false;
            while (!isSelected)
            {
                if (Input.IsMouseLeftButtonDown)
                {
                    if (Start.IsCollision(Input.MouseX, Input.MouseY))
                    {
                        StartGame(new ConsoleGraphics());
                        isSelected = true;
                    }
                    if (Score.IsCollision(Input.MouseX, Input.MouseY))
                    {
                        ShowHighscore(graphics);
                        isSelected = true;
                    }
                    if (Exit.IsCollision(Input.MouseX, Input.MouseY))
                    {
                        Environment.Exit(0);
                        isSelected = true;
                    }
                }
            }
        }

        public static void ShowHighscore(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
            Button Back = new Button("Back", 0, 0, 120, 20, 0xFFFF00FF, graphics);
            Back.AddToBoard(graphics);

            graphics.DrawString("Name", "Arial", 0xFFFF00FF, 15, 20);
            graphics.DrawString("Score", "Arial", 0xFFFF00FF, 120, 20);
            string[] lines = System.IO.File.ReadAllLines("Highscore.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] result = lines[i].Split(';');
                graphics.DrawString(result[0], "Arial", 0xFFFF00FF, 15, 20 * (i+2));
                graphics.DrawString(result[1], "Arial", 0xFFFF00FF, 120, 20 * (i + 2));
            }
            graphics.FlipPages();
            bool isSelected = false;
            while (!isSelected)
            {
                if (Input.IsMouseLeftButtonDown)
                {
                    if (Back.IsCollision(Input.MouseX, Input.MouseY))
                    {
                        MainMenu(graphics);
                    }
                }
            }
        }
        public static void StartGame(ConsoleGraphics graphics)
        {
            Console.Clear();
            GameEngine engine = new SampleGameEngine(graphics);
            engine.Start();
        }

    }
}
