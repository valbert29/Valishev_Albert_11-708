using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите точность: ");//Exercise 2
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine(FindCos(e, 0.0));
            
        }
        public static double FindCos(double e, double x)
        {
            double value = Math.Cos(x);
            if (Math.Abs(value - x) < e) return value;
            return FindCos(e, value);
        }
    }
}
