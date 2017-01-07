using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGame
{
    internal class Ball : Rectangle, IGameObject
    {
        private int speedX;
        private int speedY;
        public FieldBlocks field;
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
            for (int i = 0; i < field.field.Count; i++)
            {
                if (IsCollision(field.field[i]))
                {
                    NewSpeed(field.field[i]);
                    break;
                }
            }
            y += speedY;
            x += speedX;
            CheckGameOver();
        }

        private void NewSpeed(Block block)
        {
            player.AddScore();
            field.field.Remove(block);
            BoostSpeed();
            speedY = -1 * speedY;
        }

        private void NewSpeed(Player player)
        {
            if (IsCollision(player))
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

        private void CheckGameOver()
        {
            if (y == 0)
            {
                Lose();
            }
            if (field.field.Count == 0)
            {
                Win();
            }
        }

        private void Lose()
        {
            graphic.FillRectangle(0xFFFFFFFF, 0, 0, graphic.ClientWidth, graphic.ClientHeight);
            graphic.FlipPages();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int j = 0; j < 17; j++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("\t\tYou lose");
            Console.WriteLine("\t\tYour score: {0} ", player.GetScore());
            Console.WriteLine("\t\tWrite yo name :");
            Console.Write("\t\t");
            string[] line = { Console.ReadLine() + ";" + player.GetScore() };
            System.IO.File.AppendAllLines("Highscore.txt", line);
            RestartGame();
        }

        private void Win()
        {
            graphic.FillRectangle(0xFFFFFFFF, 0, 0, graphic.ClientWidth, graphic.ClientHeight);
            graphic.FlipPages();
            Console.Clear();
            for (int j = 0; j < 17; j++)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = System.ConsoleColor.Black;
            Console.WriteLine("\t\tYou win");
            Console.WriteLine("\t\tYou score: {0} ", player.GetScore());
            Console.WriteLine("\t\tWrite yo name :");
            Console.Write("\t\t");
            string[] line = { System.Console.ReadLine() + ";" + player.GetScore() };
            System.IO.File.AppendAllLines("Highscore.txt", line);
            RestartGame();
        }

        private void RestartGame()
        {
            Console.WriteLine("\t\tYou want restart game ? (y/n) :");
            Console.Write("\t\t");
            switch (Console.ReadLine())
            {
                case "y":
                    Menu.StartGame(new ConsoleGraphics());
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