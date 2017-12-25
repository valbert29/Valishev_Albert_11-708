using System;

namespace SemPoRecursiyamEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var degree = int.Parse(Console.ReadLine());
            var endNumber = Pow(number, degree);
            Console.WriteLine(endNumber);
        }

        static long Pow(int a, int b, long mult = 1)
        {
            if (b == 0) return mult;
            if (b % 2 == 0) return Pow(a * a, b / 2, mult);
            return Pow(a * a, b / 2, a * mult);
        }

        static long Pow2(int a, int b, long mult = 1)
        {
            while (b > 0)
            {
                if (b % 2 > 0) mult *= a;
                a *= a;
                b /= 2;
            }

            return mult;
        }
    }
}
