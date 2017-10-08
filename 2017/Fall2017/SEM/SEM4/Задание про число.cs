using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число 1<=n<=27: ");
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            for(int a = 1; a<10; a++)
            {
                for(int b = 0; b < 10; b++)
                {
                    for(int c=0; c<10; c++)
                    {
                        if ((a + b + c) == n) count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
