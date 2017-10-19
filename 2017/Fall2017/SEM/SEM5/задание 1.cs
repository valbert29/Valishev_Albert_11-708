using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите k: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите n - размер массива");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            ReverseMyArray(0, n, array);
            ReverseMyArray(0, k, array);
            ReverseMyArray(k, n, array);

            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i]+ " ");
        }

        private static void ReverseMyArray(int k, int n, int[] array)
        {
            for (int j = k; j < (n + k) / 2; j++)
            {
                int change = array[j];
                array[j] = array[n - 1 - j + k];
                array[n - 1 - j + k] = change;
            }
        }
    }
}
