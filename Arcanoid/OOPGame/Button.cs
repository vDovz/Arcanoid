using NConsoleGraphics;

namespace OOPGame
{
    class Button : Rectangle
    {
        private uint color;
        private string title;

        public Button(string title, int x, int y, int width, int height, uint color, ConsoleGraphics graphics)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public void AddToBoard(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(color, x, y, width, height);
            graphics.DrawString(title, "Arial", 0xFFFF00FF, x, y);
        }

        public bool IsCollision(int CoorX, int CoorY)
        {
            if (CoorX >= x && CoorX <= x + width && CoorY >= y && CoorY <= y + height)
            {
                return true;
            }
            return false;
        }


    }
}
