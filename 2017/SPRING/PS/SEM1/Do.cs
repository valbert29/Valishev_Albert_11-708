using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestr1
{
    public class Do
    {

        public FigureList MyList = new FigureList();

        //метод кодирования - создание списка элементов, считыванием с файла
        public FigureList Encode()
        {
            TextReader objReader = new StreamReader(@"C:\Users\Пользователь\Desktop\TEXT.txt");

            while (true)
            {
                var sLine = objReader.ReadLine();
                if (sLine == null ) break;
                string[] str = sLine.Split(' ');
                Create(str);

            }
            return MyList;
        }

        //вспомогательный метод, который создает элементы листа и добавляет в лист
        private void Create(string[] str)
        {
            MyList.Add(new Figure(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]),
                Convert.ToInt32(str[3]), Convert.ToInt32(str[4]), Convert.ToInt32(str[5])), Convert.ToInt32(str[6]));
        }

        //декодирование, выводит строки полей элементов листа на консоль
        public void Decode()
        {
            Figure item = MyList.head;
            while (item != null)
            {
                Console.Write("{0} \t{1} \t{2} \t{3} \t{4} \t{5}", item.Type, item.XLU, item.YLU, item.XRD, item.YRD, item.Color);
                item = item.Next;
                MyList.head = item;
                Console.WriteLine();
            }
        }

        //по координатам прямоугольника строит список состоящий из фигур с теми же координатами
        public FigureList RectangleCoordinates(Figure rectangle)
        {
            if (rectangle.Type != 1) throw new ArgumentException();
            Random rnd = new Random();
            MyList = new FigureList();
            while (MyList.Count() < 6)
            {
                int item = rnd.Next(2, 4);
                if (item == 3)
                {
                    MyList.AddLast(new Figure(item, rectangle.XLU,
                rectangle.YLU, Math.Abs(rectangle.XRD-rectangle.XLU), 0, rnd.Next(1, 4)));
                }
                else
                {
                    MyList.AddLast(new Figure(item, rectangle.XLU,
                rectangle.YLU, rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 4)));
                }

            }
            return MyList;
        }

        //преобраует все отрезочки в прямоугольники, иначе удаляет 
        public FigureList LinesToRectangle()
        {
            Figure item;
            item = MyList.head;
            Random rnd = new Random();
            while (item != null)
            {
                if (item.Type == 2)
                {
                    if (item.XLU != item.XRD && item.YLU != item.YRD)
                    {
                        item.Type = 1;
                        item.Color = rnd.Next(1, 10);
                    }
                    else
                    {
                        MyList.Remove(item);
                    }
                }
                item = item.Next;
            }
            return MyList;
        }

        //строит список фигур, площадь которых больше некоторой константы
        public FigureList BuildListByConst(int constant)
        {
            MyList = new FigureList();
            Random rnd = new Random();
            while (MyList.Count() < 5)
            {
                int type = rnd.Next(1, 4);  
                if (type == 1)
                {
                    int x1 = rnd.Next(0, 25);
                    int y1 = rnd.Next(0, 25);
                    int x2 = rnd.Next(25, 50);
                    int y2 = rnd.Next(25, 50);
                    if (y2 - y1 > constant || x2 - x1 > constant)
                    {
                        MyList.Add(new Figure(type, x1, y1, x2, y2, rnd.Next(1, 8)), 0);
                    }
                }
                if (type == 3)
                {
                    int x1 = rnd.Next(0, 25);
                    int y1 = rnd.Next(0, 25);
                    int x2 = rnd.Next(0, 15);
                    if (x2 * 6 > constant)
                    {
                        MyList.Add(new Figure(type, x1, y1, x2, 0, rnd.Next(1, 8)), 0);
                    }
                }
            }
            return MyList;
        }
    }
}
