using LibraryFor1b;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)//Exercise 1.2 Valishev 2var
        {
            Console.WriteLine("Введите точность e: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите |X|<=1: ");
            double x = double.Parse(Console.ReadLine());
            var answer = TestClass1b.FindValue(e, x);
            Console.Write("Значение: {0}. Шаг: {1}", answer[0], answer[1]);
        }
    }
}