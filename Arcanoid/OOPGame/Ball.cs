using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGame
{
    internal class Ball : Rectangle, IGameObject
    {
        private int speedX;
        private int speedY;
        public FieldBlocks field { get; set; }
        public Player player { get; set; }

        public Ball(int x1, int y1, int speedX, int speedY)
        {
            x = x1;
            y = y1;
            width = 15;
            height = 15;
            this.speedX = speedX;
            this.speedY = speedY;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, width, height);
        }

        public void Update(GameEngine engine)
        {

            NewSpeed(player);
            NewSpeed(graphic);
            for (int i = 0; i < field.GetField().Count; i++)
            {
                NewSpeed(field.GetField()[i]);
                if (IsCollision(field.GetField()[i]))
                {
                    player.AddScore();
                    field.GetField().RemoveAt(i);
                    BoostSpeed();
                }
            }
            y += speedY;
            x += speedX;
            if (y == 0)
            {
                Lose();
            }
            if (field.GetField().Count == 0)
            {
                Win();
            }
        }

        private void NewSpeed(Rectangle rect)
        {
            if (IsCollision(rect))
            {
                speedY = -1 * speedY;
            }
        }

        private void NewSpeed(ConsoleGraphics graphics)
        {
            if (x >= graphics.ClientWidth - 25 || x <= 5)
            {
                speedX = -1 * speedX;
            }
            if (y >= graphics.ClientHeight - 25 || y <= 0)
            {
                speedY = -1 * speedY;
            }
        }

        private void BoostSpeed()
        {
            if (player.GetScore() % 100 == 0)
            {
                if (speedX > 0) { speedX += 3; }
                else { speedX -= 3; }
                if (speedY > 0) { speedY += 3; }
                else { speedY -= 3; }
            }
        }

        private void Lose()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    System.Console.Write("a");
                }
            }

            System.Console.ForegroundColor = System.ConsoleColor.Black;
            System.Console.Clear();
            for (int j = 0; j < 17; j++)
            {
                System.Console.WriteLine();
            }
            System.Console.WriteLine("\t\tYou lose");
            System.Console.WriteLine("\t\tYour score: {0} ", player.GetScore());
            System.Console.WriteLine("\t\tWrite yo name :");
            System.Console.Write("\t\t");
            string[] line = { System.Console.ReadLine() + ";" + player.GetScore() };
            System.IO.File.AppendAllLines("Highscore.txt", line);
            RestartGame();
        }

        private void Win()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    System.Console.Write("a");
                }
            }
            System.Console.Clear();
            for (int j = 0; j < 17; j++)
            {
                System.Console.WriteLine();
            }
            System.Console.ForegroundColor = System.ConsoleColor.Black;
            System.Console.WriteLine("\t\tYou win");
            System.Console.WriteLine("\t\tYou score: {0} ", player.GetScore());
            System.Console.WriteLine("\t\tWrite yo name :");
            Console.Write("\t\t");
            string[] line = { System.Console.ReadLine() + ";" + player.GetScore() };
            System.IO.File.AppendAllLines("Highscore.txt", line);
            RestartGame();
        }
        private void RestartGame()
        {
            System.Console.WriteLine("\t\tYou want restart game ? (y/n) :");
            switch (Console.ReadLine())
            {
                case "y":
                    Program.StartGame();
                    break;
                case "n":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\t\t Not correct Answer. try again");
                    RestartGame();
                    break;
            }
        }
    }
}