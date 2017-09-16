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
            Console.Write("Введите X прямой:");
            int X = Int32.Parse(Console.ReadLine());// ввели числа
            Console.Write("Введите Y прямой:");
            int Y = Int32.Parse(Console.ReadLine());
            Console.Write("Введите X1 прямой:");
            int X1 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите Y1 прямой:");
            int Y1 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите X точки:");
            int X2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите Y точки:");
            int Y2 = Int32.Parse(Console.ReadLine());

            var L = (Math.Abs((Y - Y1) * X2 - (X - X1) * Y2 + X1 * Y - Y1 * X)) / (Math.Sqrt(Math.Pow((Y1 - Y), 2) + Math.Pow((X1 - X), 2)));
            Console.WriteLine(L);
        } 
    }
}
