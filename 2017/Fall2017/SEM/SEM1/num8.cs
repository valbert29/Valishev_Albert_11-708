using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Уравнение прямой вида: y=ax+b. ");
            Console.Write("Введите a прямой:");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("Введите x прямой:");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите b прямой:");
            int b = Int32.Parse(Console.ReadLine());
            Console.Write("Введите x точки:");
            int x1 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите y точки:");
            int y = Int32.Parse(Console.ReadLine());
            var  a1 = (double)-1 / a;
            var b2 = y - (a1 * x1);
            var x2 = (double)(b2 - b) / (a - a1); //находим координату x точки пересечения
            var y2 = a * x2 + b;//а тут её y
            string s = "точка пересечения прямой и перпендикуляра из точки имеет координаты (" + x2.ToString() + ";" + (y2).ToString() + ")";
            Console.WriteLine(s);
           
        } 
    }
}
