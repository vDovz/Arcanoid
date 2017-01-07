using System.Collections.Generic;
using NConsoleGraphics;

namespace OOPGame
{

    class FieldBlocks : Rectangle, IGameObject
    {
        public List<Block> field { get; set; }

        public FieldBlocks(int Line, int Column, int startX, int startY)
        {
            field = new List<Block>();
            InitField(Line, Column, startX, startY);
        }

        private void InitField(int Line, int Column, int startX, int startY)
        {
            for (int i = 0; i < Line; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    field.Add(new Block(startX + j * 50, startY + i * 50));
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (var item in field)
            {
                item.Render(graphics);
            }
        }

        public void Update(GameEngine engine)
        {
            foreach (var item in field)
            {
                item.Update(engine);
            }
        }
    }
}
