using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите e: ");//Exercise 1.1
            double m = double.Parse(Console.ReadLine());
            double answer = FindValueAndStep(m);
            Console.Write("значение " + answer);
            Console.WriteLine();
            
            
        }
        public static double FindValueAndStep(double e)
        {
            double step = 2;
            double value = 1.0/2;
            double c = value;
            while (c > e)
            {
                c *= ((step - 1)*(step - 1)/((2 * step - 1) * (2 * step)));
                value += c;
                    step++;
            }
            Console.Write("Шаг" + (step-1));
            Console.WriteLine();
            return value;
        }

    }
}
