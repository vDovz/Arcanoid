using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;

namespace OOPGame
{

    public abstract class GameEngine
    {

        protected ConsoleGraphics graphics;
        private List<IGameObject> objects = new List<IGameObject>();
        private List<IGameObject> tempObjects = new List<IGameObject>();


        public GameEngine(ConsoleGraphics graphics)
        {

            this.graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {

            tempObjects.Add(obj);
        }

        public void Start()
        {
            while (true)
            {
                // Game Loop
                foreach (var obj in objects)
                    obj.Update(this);

                objects.AddRange(tempObjects);
                tempObjects.Clear();
      
                // clearing screen before painting new frame
                graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);    
                foreach (var obj in objects)
                    obj.Render(graphics);

                // double buffering technique is used
                graphics.FlipPages();
                Thread.Sleep(25);
            }
        }
        private static void Menu(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFFFF00, 50, 50, 90, 20);
            graphics.DrawString("Start", "Arial", 0xFF000000, 70 , 50);
        }
    }
}
