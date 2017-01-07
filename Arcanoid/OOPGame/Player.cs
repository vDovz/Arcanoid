using NConsoleGraphics;

namespace OOPGame
{

    public class Player : Rectangle, IGameObject
    {
        private int speed = 10;
        private int score = 1;

        public void AddScore()
        {
            score += 10;
        }

        public int GetScore()
        {
            return score;
        }

        public Player(ConsoleGraphics graphics)
        {
            x = 50;
            y = 25;
            width = 60;
            height = 15;
            graphics.DrawRectangle(0xFFFF0000, x, y, 30, 8);
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(0xFFFF0000, x, y, width, height, (float)3);
        }

        public void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (x - speed >= 0)
                    x -= speed;
            }
            if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (x + speed < graphic.ClientWidth - 50)
                    x += speed;
            }
        }
    }
}