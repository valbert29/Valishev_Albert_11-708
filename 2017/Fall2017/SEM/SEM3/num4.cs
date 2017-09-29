using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите начало 1 отрезка: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("введите конец 1 отрезка: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("введите начало 2 отрезка: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("введите конец 2 отрезка: ");
            int d = int.Parse(Console.ReadLine());
            int length = 0;
            if (a < c && d < b) length = (d - c);
            else
            length = Math.Max(0, (Math.Min(b, d) - Math.Min(a, c)));
            Console.WriteLine(length);
        }
    }
}
