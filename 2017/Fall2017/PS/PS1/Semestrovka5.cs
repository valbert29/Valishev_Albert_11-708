using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите K: ");
            int k = int.Parse(Console.ReadLine());//вводм k
            int num1 = k;
            long x = k;
            long y = 0;
            long p = 0;
            for(long i = (k-1); i>1; i--)//вводим цикл, который считает числа от к-1 до 1 
            {
                y = i;
                p = x * y;//данное число является произведением последнего и предпоследнего чисел
                while (x != 0 && y != 0)//пока один из членов не станет 0
                {
                    if (x > y) x %= y;
                    else y %= x;
                }
                x = p / (x + y);//вычивляется нок последних чисел и присваивается к последнему, для продолжения вычисления конечного НОК

            }
            Console.WriteLine(x);
            
        }
    }
}
