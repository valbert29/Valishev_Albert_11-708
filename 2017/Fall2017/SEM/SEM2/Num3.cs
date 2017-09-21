using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)//задача на нахождение максимального и минимального времени заложенности ушей
        {
            double tMax = 0.0;
            double tMin = 0.0;
            Console.Write("Введите h: ");
            int h = int.Parse(Console.ReadLine());

            Console.Write("Введите t: ");
            int t = int.Parse(Console.ReadLine());

            Console.Write("Введите v: ");
            int v = int.Parse(Console.ReadLine());

            Console.Write("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            if (x > v)
            {
                tMax = h / (x + 1);
                tMin = 0.0;
            }
            else
            {
                tMax = t;
                tMin = (h - x * t) / (v - x);
            }
            Console.WriteLine(tMin);
            Console.WriteLine(tMax);

        }
    }
}
