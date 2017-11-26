using LibraryFor1c;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The1Point3Task
{
    class Program
    {
        static void Main(string[] args)//exercise 1.3 Valishev 2var
        {
            Console.WriteLine("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность: ");
            double e = double.Parse(Console.ReadLine());
            var result = TestClassFor1c.CalculateGraduatedNum(e, x);
            Console.WriteLine("Сумма последовательности: {0}, Шаг: {1} ", result[0], result[1]);
        }

    }
}