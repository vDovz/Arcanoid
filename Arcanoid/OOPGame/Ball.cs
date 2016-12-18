using NConsoleGraphics;

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

            GetSpeed(player);
            GetSpeed(graphic);
            for (int i = 0; i < field.GetField().Count; i++)
            {
                GetSpeed(field.GetField()[i]);
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
                //GameOver

            }
        }
        private void GetSpeed(Rectangle rect)
        {
            if (IsCollision(rect))
            {
                speedY = -1 * speedY;
            }
        }
        private void GetSpeed(ConsoleGraphics graphics)
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
    }
}