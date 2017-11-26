using LibraryFor1a;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35//Exercise 1.1 Valishev 2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите точность e: ");
            double e = double.Parse(Console.ReadLine());
            var answer = (ClassFor1a.FindValueAndStep(e));
            Console.Write("Значение: {0} На шаге {1}",answer[0], answer[1]);
        }
        
    }
}
