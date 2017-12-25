using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)//в этой задаче находим порядковый номер числа в прогресиии, 
        {
            Console.WriteLine("введите f - первый член прогрессии:");
            int f = int.Parse(Console.ReadLine());
            Console.WriteLine("введите s - шаг прогрессии:");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("введите n - проверяемое значение:");
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int k = 0;
	    // ---check--- оптимальнее это было делать без цикла
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
                Console.WriteLine("-1");//если n не являтся членом прогрессии, то выводится -1
            }
                
            
        }
    }
}
