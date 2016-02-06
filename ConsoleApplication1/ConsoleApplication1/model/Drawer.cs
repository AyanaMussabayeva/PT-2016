using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.model
{
    /// <summary>
    /// в классе Drawer создаем методы постановки объектов по координатам
    /// реализация сериализации и десериализации с помощью BinaryFormatter
    /// </summary>
    [Serializable]
    public class Drawer
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public Drawer()
        {
            color = ConsoleColor.White;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
           
                Console.Write(sign);
            }
        }

        public void Save()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Create, FileAccess.Write);
            //XmlSerializer xs = new XmlSerializer(t);
            //xs.Serialize(fs, this);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Open, FileAccess.Read);
            //XmlSerializer xs = new XmlSerializer(t);
            BinaryFormatter bf = new BinaryFormatter();
            if (t == typeof(Wall)) Game.wall = bf.Deserialize(fs) as Wall;
            if (t == typeof(Snake)) Game.snake = bf.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.food = bf.Deserialize(fs) as Food;
            fs.Close();
        }

    }
}
