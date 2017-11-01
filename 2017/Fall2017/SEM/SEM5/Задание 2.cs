using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number, which have less than 100 signs: ");
            long k = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree, в которой записано число: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree, в которйо хотите получить число: ");
            int b = int.Parse(Console.ReadLine());
            int[] secondArray = new int[100];
            int[] firstArray = new int[100];
            int[] thurdArray = new int[100];
            long mainNum = 0;
            int r = 0;
            while (k > 0)
            {
                firstArray[r] = (int)k % 10;// переводим число из степени а, в 10-ую
                mainNum += (firstArray[r] * (int)Math.Pow(a, r));
                k /= 10;
                r++;
            }
            int countNum = 0;
            int i = 0;
            while (mainNum > 0)
            {
                secondArray[i] = (int)(mainNum % b);//находим b-ую запись 10-ого числа
                mainNum /= b;
                i++;
                countNum++;
            }
            Console.Write("Number in degree b is:");
            for (int y = 0; y < countNum; y++)
            {
                thurdArray[y] = secondArray[countNum - y - 1];
                Console.Write(thurdArray[y]);
            }

        }
    }
}
