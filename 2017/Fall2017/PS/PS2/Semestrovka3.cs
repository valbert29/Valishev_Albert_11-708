using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The1Point3Task
{
    class Program
    {
        static void Main(string[] args)//exercise 1.3
        {
            Console.WriteLine("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Сумма последовательности - {0}",CalculateGraduatedNum(e, x));
        }
        public static double CalculateGraduatedNum(double e, int x)
        {
            double sequence = 1;
            double k = 1;
            int step = 0;
            while (k > e)
            {
                step++;
                k *= (x * Math.Log(3) / step);
                sequence += k;
            }
            Console.WriteLine("Шагов - {0}", step);
            return sequence;
        }
    }
}
