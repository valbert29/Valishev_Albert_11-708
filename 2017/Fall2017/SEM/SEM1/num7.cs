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
            var  a1 = (double)-1 / a;
            string s = "вектор, перпендикулярный прямой, с началом в начале координат имеет координаты   (" + x.ToString()+";"+(a1*x).ToString()+")";
            Console.WriteLine(s);
            string p = "вектор, параллельный прямой, с началом в начале координат имеет координаты (" + x.ToString() + ";" + (a * x).ToString() + ")";
            Console.WriteLine(p);
        } 
    }
}
