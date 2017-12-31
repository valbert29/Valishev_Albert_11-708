using System;

namespace Sev6Ex1
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var array = GetArray(n);
            var k = int.Parse(Console.ReadLine());
            var arrayK = GetArrayOfArray(k);
            GetSum(arrayK, array);
        }

        static int[] GetArray(int n)
        {
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static int[][] GetArrayOfArray(int n)
        {
            var arrayK = new int[n][];
            for (int i = 0; i < n; i++)
            {
                var array = new int[2];
                arrayK[i] = array;
                for (int j = 0; j < 2; j++)
                {
                    arrayK[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return arrayK;
        }

        static void GetSum(int[][] arrayK, int[] array)
        {
            var sum = 0;
            for (int i = 0; i < arrayK.Length; i++)
            {
                var indexBegin = arrayK[i][0] - 1;
                var indexEnd = arrayK[i][1];
                for (int j = indexBegin; j < indexEnd; j++)
                {
                    sum += array[j];
                }
                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
