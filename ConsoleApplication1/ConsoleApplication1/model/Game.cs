using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.model
{
    /// <summary>
    ///класс Game отвечает за состояние игры в текущий момент
    ///метод Init  вызывается при прогрузке игры, отвечая за начально положение всех объектов
    ///используя Filestream и Streamreader считываем файл с уровнем в методе Loadlevel
    ///рандомно генерируем положение змейки, учитывая координаты еды и стен. Данный метод в последствиии вызывается в классе Program как только прогрузится новый уровень
    ///метод Save сохраняет текущее состояние игры
    ///метод Resume позволять продолжить состояние сохраненной игры
    ///в методе Draw прописываем каждый объект и счетчик баллов
    /// </summary>
    [Serializable]
    public class Game
    {
        public static bool isActive;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            snake.body.Add(new Point { x = 20, y = 20 });
            food.body.Add(new Point { x = 30, y = 20 });

            food.color = ConsoleColor.Magenta;
            wall.color = ConsoleColor.Yellow;
            snake.color = ConsoleColor.Green;

            Console.SetWindowSize(48, 52);
            
        
        }
        
        public static void LoadlLevel(int level)
        {
       
            FileStream fs = new FileStream(string.Format(@"Levels\Level{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int row = -1;
            int col = -1;

            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == 'I')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            sr.Close();
            fs.Close();
        }
       
        public static void RandomSnakeMaker()
        {
            Game.snake.body[0].x = new Random().Next(0, 47);
            Game.snake.body[0].y = new Random().Next(0, 47);
            for (int i = 0; i < Game.wall.body.Count; i++)
            {
                if (Game.snake.body[0].x == Game.wall.body[0].x || Game.snake.body[0].y == Game.wall.body[0].y)
                {
                    RandomSnakeMaker();

                }
                else
                {
                    continue;
                }
                if (Game.food.body[0].x == Game.snake.body[0].x || Game.food.body[0].y == Game.snake.body[0].y)
                {
                    RandomSnakeMaker();

                }
                else
                {
                    continue;
                }

            }
        }
        
        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(3, 48);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Level: " + Program.level);
            Console.SetCursorPosition(3, 49);
            Console.WriteLine("Points: " + Game.snake.body.Count);
            Console.SetCursorPosition(3, 50);
            Console.WriteLine("Time: " + Program.minuts + " : " + Program.seconds);

        }
        
    }
}

