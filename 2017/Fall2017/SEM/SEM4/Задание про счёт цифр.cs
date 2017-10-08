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
            int count = 0;
            int count1 = 1;
            int numEnd =0;
            int num;
            Console.Write("Введите число n - длину массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите первый член массива: ");
            int num1 = int.Parse(Console.ReadLine());
            
            for (int i=2; i <= n; i++)
            {
                Console.Write("Введите " + i + "-ый член массива нажимая enter: ");
                num = int.Parse(Console.ReadLine());
                if (num == num1) count1++;
                else count1 = 1;
                num1 = num;
                if (count1 > count)
                {
                    count = count1;
                    numEnd = num;
                }
            }
            Console.Write("Подмассив:");
            for (int j = 0; j < count; j++)
                Console.Write(numEnd);
            Console.WriteLine();

        }
    }
}
