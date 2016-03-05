using System;
using System.IO;
using Snake.model;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public static Timer time = new Timer(new TimerCallback(seconding), st, 0, 1000);
       

        public static int seconds = 0;
        public static int minuts = 0;
        private static int st;

        public static void seconding(object st)
        {
            seconds++;
            if (seconds == 60)
            {
                minuts++;
                seconds = 0;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(3, 47);
            Console.WriteLine("Time " + minuts + " : " + seconds);
        }


        public static string dir = "Right";
       
        static void Main(string[] args)
        {
            
            while (level <= Directory.GetFiles(@"C:\Users\Admin\Source\Repos\NewRepo\ConsoleApplication1\ConsoleApplication1\bin\Debug\Levels").Length)
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
                            //Game.snake.Move(0, -1);
                            dir = "Up";
                            break;
                        case ConsoleKey.DownArrow:
                            //Game.snake.Move(0, 1);
                            dir = "Down";
                            break;
                        case ConsoleKey.LeftArrow:
                            //Game.snake.Move(-1, 0);
                            dir = "Left";
                            break;
                        case ConsoleKey.RightArrow:
                            //Game.snake.Move(1, 0);
                            dir = "Right";
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
                    switch (dir)// меняем положение 
                    {
                        case "Up":
                            Game.snake.Move(0, -1);
                            break;
                        case "Down":
                            Game.snake.Move(0, 1);
                            break;
                        case "Left":
                            Game.snake.Move(-1, 0);
                            break;
                        case "Right":
                            Game.snake.Move(1, 0);
                            break;

                    }
                }
                

                //Game.wall.Draw();// убираем мерцание стены 
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("You won!");
        }

    }
}


