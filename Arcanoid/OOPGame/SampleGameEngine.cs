using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public class SampleGameEngine : GameEngine
    {

        public SampleGameEngine(ConsoleGraphics graphics)
           : base(graphics)
        {
            Ball bullet = new Ball(10, 10, 5, 5);
            Player player = new Player(graphics);
            FieldBlocks field = new FieldBlocks(8,8, 10, 100);
            bullet.field = field;
            bullet.player = player;
            AddObject(bullet);
            AddObject(player);
            AddObject(field);
        }
    }
}
