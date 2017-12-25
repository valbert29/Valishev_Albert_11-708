using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem6Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину 1 массива");
            int n1 = int.Parse(Console.ReadLine());
            int[] array1 = new int[n1];
            Console.Write("Введите длину 2 массива");
            int n2 = int.Parse(Console.ReadLine());
            int[] array2 = new int[n2];
            int k = 0;
            bool stop = false;
            for(int i = 0; i < n1; i++)
            {
                Console.Write("Введите элемент 1 массива");
                array1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n2; i++)
            {
                Console.Write("Введите элемент 2 массива");
                array2[i] = int.Parse(Console.ReadLine());
            }
            for(int i = 0; i < n1; i ++)
            {
                for(int j = 0; j < n2; j++)
                {
                    if (array1[i + j] == array2[j]) k++;
                    if (k == n2) stop = true;
                }
                if (stop) break;
                k = 0;
            }
            if (k == n2) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
