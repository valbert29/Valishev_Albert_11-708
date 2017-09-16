using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N:");
            int N = Int32.Parse(Console.ReadLine());// ввели числа
            Console.Write("Введите X:");
            int X = Int32.Parse(Console.ReadLine());
            Console.Write("Введите Y :");
            int Y = Int32.Parse(Console.ReadLine());
            var K = 0;
            int i;
            for (i = 1; i < (N-1); i++)
            {
                if (i % X == 0) K++; // считает кол-во чисел с делителем х
                if (i % Y == 0) K++;//считает с делителем у
                if (i % (Y * X) == 0) K--; //вычитает повторяющиеся числа
            }   
            Console.WriteLine(K);
        } 
    }
}
