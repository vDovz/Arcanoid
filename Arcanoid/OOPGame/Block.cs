using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Block : Rectangle, IGameObject
    {
        public Block(int x1, int y1)
        {
            x = x1;
            y = y1;
            width = 30;
            height = 15;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, width, height);
        }

        public void Update(GameEngine engine)
        {

        }
    }
}
