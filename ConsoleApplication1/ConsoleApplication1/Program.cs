using System;
using System.IO;
using Snake.model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake
{
    /// <summary>
    /// в классе Program вызываем ранее описаные в Game методы Init, LoadLevel и RandomSnakeMaker
    /// первый цикл задает условие играть пока не закончатся уровни в папке с указанным путем
    /// используя цикл задаем условие активности игры, где прописываем действия при нажатии клавиш, используя ConsoleKeyInfo
    /// </summary>
    class Program
    {
        public static int level = 1;
        static void Main(string[] args)
        {
            while(level<= Directory.GetFiles(@"C:\Users\Admin\Source\Repos\NewRepo\ConsoleApplication1\ConsoleApplication1\bin\Debug\Levels").Length)
            {
                Game.Init();
                Game.LoadlLevel(level);
                Game.RandomSnakeMaker();

                while (Game.isActive)
                {
                    Game.Draw();

                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Game.snake.Move(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            Game.snake.Move(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            Game.snake.Move(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            Game.snake.Move(1, 0);
                            break;
                        case ConsoleKey.Escape:
                            Game.isActive = false;
                            break;
                        case ConsoleKey.F2:
                            Game.Save();
                            break;
                        case ConsoleKey.F3:
                            Game.Resume();
                            break;
                    }
                }

                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("You won!");
        }
        
    }
}
