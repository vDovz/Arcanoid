using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    class Menu
    {
        public static int MainMenu()
        {
            Console.Clear();
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("\t\t   1. Start Game ");
            Console.WriteLine();
            Console.WriteLine("\t\t   2. HighScore");
            Console.WriteLine();
            Console.WriteLine("\t\t   3. Exit ");
            switch (Console.ReadLine())
            {
                case "1": return 1;
                case "2": return 2;
                case "3": return 3;
                default: return -1;
            }
        }

        public static void ShowHighscore()
        {
            Console.Clear();
            String[] lines = System.IO.File.ReadAllLines("Highscore.txt");
            Console.WriteLine("\tName \t Score");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] result =lines[i].Split(';');
                Console.WriteLine("\t{0} \t {1}", result[0], result[1]);
            }
            Console.WriteLine("1.Back to Main Menu ");
            switch (Console.ReadLine())
            {
                case "1": Program.CreateMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
