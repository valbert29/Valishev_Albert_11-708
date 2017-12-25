using System;

namespace Col22
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            while(a < c)
            {
                if (a += b < c) a += b;
                if (c -= d > a) c -= d;
            }
            Console.WriteLine(a);
        }
    }
}
