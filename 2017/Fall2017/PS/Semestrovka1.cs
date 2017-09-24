using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)//в этой задаче надо определить, можно ли пойти конем на заданную точку
        {
            Console.WriteLine("введите f - первый член прогрессии:");
            int f = int.Parse(Console.ReadLine());
            Console.WriteLine("введите s - шаг прогрессии:");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("введите n - проверяемое значение:");
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int k = 0;
            while (a < n)
            {
                k += 1;
                a = f + (k - 1) * s;
            }
            if (a==n)
            {
                Console.WriteLine(k);
            }
            else
            {
                Console.WriteLine("-1");
            }
                
            
        }
    }
}
