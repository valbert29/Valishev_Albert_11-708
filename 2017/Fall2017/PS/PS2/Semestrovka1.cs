using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите точность e: ");//Exercise 1.1
            double e = double.Parse(Console.ReadLine());
            var answer = FindValueAndStep(e);
            Console.Write("Значение - " + answer);
            Console.WriteLine();
        }
        public static double FindValueAndStep(double e)
        {
            double step = 2;
            double c = 1.0 / 2;
            double value = c;
            while(c>e)
            {
                c *= ((step - 1) * (step - 1) / (2 * step - 1) / (2 * step));
                value += c;
                step++;
            }
            Console.Write("Шаг - " + (step - 1));
            Console.WriteLine();
            return value;
        }
    }
}
