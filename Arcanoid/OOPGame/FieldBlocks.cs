using System.Collections.Generic;
using NConsoleGraphics;

namespace OOPGame
{
    
    class FieldBlocks :Rectangle, IGameObject
    {
        private List<Block> field = new List<Block>();

        public FieldBlocks(int Line,int Column, int  startX, int startY)
        {
           for (int i = 0; i < Line ; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    field.Add(new Block(startX + j * 50, startY+ i*50));
                }
            }
        }
        public List<Block> GetField()
        {
            return field;
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
          
        }
    }
}
