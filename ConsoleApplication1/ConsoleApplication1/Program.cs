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
        public static string dir = "Right";
        public static Thread forTimer;
        public static Thread Direction = new Thread(new ParameterizedThreadStart(move));
        //public static Timer time = new Timer(new TimerCallback(seconding), st, 0, 1000);


        public static int seconds = 0;
        public static int minuts = 0;
        /*private static int st;
        
        public static void seconding(object st)
        {
            
                seconds++;
                minuts++;
                if (seconds == 60)
                {
                    seconds = 0;
                }
                
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(3, 47);
            Console.WriteLine("Time " + minuts + " : " + seconds);

            

        }*/
        public static void timer(object obj)
        {
            while (Game.isActive)
            {
                seconds++;
                if (seconds == 60)
                {
                    minuts++;
                    seconds = 0;
                }
                Thread.Sleep(1000);
            }
           
        }




        static void Main(string[] args)
        {

            MainThreadFunction();
        }




        public static void MainThreadFunction()
        {
            Game.Init();
            Game.LoadlLevel(level);
            Game.snake.Draw();
            Direction = new Thread(new ParameterizedThreadStart(move));
            forTimer = new Thread(new ParameterizedThreadStart(timer));
            Direction.Start();
            forTimer.Start();
            while (Game.isActive)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        dir = "Up";
                        break;
                    case ConsoleKey.DownArrow:
                        dir = "Down";
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = "Left";
                        break;
                    case ConsoleKey.RightArrow:
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
            }
            Direction.Abort();
            forTimer.Abort();
            MainThreadFunction();
        }
        private static void move(object obj) // основы движения змейки
        {
            while (Game.isActive)
            {
                
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

                Game.Draw();
                Thread.Sleep(100);

            }
        }

    }
}


