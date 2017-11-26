using Solve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.0;
            double b = 1.5;
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            //разделили фигуру на n частей
            //Console.WriteLine(CalculateLeftRectangle(n, h));
            Console.WriteLine("Метод Левых прямоугольников -\t {0}", TestClass3.CalculateLeftRectangle(n, a, b));
            Console.WriteLine("Метод Правых прямоугольников -\t {0}", TestClass3.CalculateRightRectangle(n, a, b));
            Console.WriteLine("Метод Трапеций -\t \t {0}", TestClass3.CalculateTrapeze(n, a, b));
            Console.WriteLine("Метод Монте-Карло -\t \t {0}", TestClass3.CalculateMonteKarlo(n, b));
            Console.WriteLine("Метод Симпсона -\t \t {0}", TestClass3.CalculateSimpson(n, a, b));
        }
    }
}
