using NConsoleGraphics;

namespace OOPGame
{
    public abstract class Rectangle
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;
        protected ConsoleGraphics graphic = new ConsoleGraphics();

        public bool IsCollision(Rectangle rect)
        {
         
            //left and right side of block
            if((x== rect.x + rect.width&& y >= rect.y&& y <= rect.y+ rect.height)|| (x == rect.x && y >= rect.y && y <= rect.y + rect.height))
            {
                return true;
            }
            if ((x + width == rect.x + rect.width && y + height >= rect.y && y + height <= rect.y + rect.height) || (x + width == rect.x && y + height >= rect.y && y + height <= rect.y + rect.height))
            {
                return true;
            }
            //up and down side of block
            if ((x >= rect.x  && x <= rect.x + rect.width && y == rect.y) || (x >= rect.x && x <= rect.x + rect.width && y == rect.y + rect.height))
            {
                return true;
            }
            if ((x + width >= rect.x && x + width <= rect.x + rect.width && y + height == rect.y) || (x + width >= rect.x && x + width<= rect.x + rect.width && y + height== rect.y + rect.height))
            {
                return true;
            }
            //fix one small problem with right side
            if(x ==rect.x&&( (y >= rect.y && y<=rect.y+ rect.height)|| (y +height >= rect.y && y + height <= rect.y + rect.height)))
            {
                return true;
            }
            return false;
        }

    }
}
