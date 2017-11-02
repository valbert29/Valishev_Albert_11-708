using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)//Exercise 1.2
        {
            Console.WriteLine("Введите точность e: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите |X|<=1: ");
            double x = double.Parse(Console.ReadLine());
            double answer = FindValue(e, x);
            Console.Write("Значение - " + answer);
        }
        public static double FindValue(double e, double x)
        {
            double step = 1;
            var p = -1;
            double c = 1.0/1;
            double value;
            value = c;
            while ((Math.Sqrt(Math.Pow(c,2))) > e)
            {
                c *= (p * (2 * step) * (2 * step - 1) * x * (-2 * step + 3) / (-2 * step + 1) / (step * step) / 4);
                value += c;
                step++;
            }
            Console.Write("Шаг - " + (step));
            Console.WriteLine();
            return value;
        }
    }
}
