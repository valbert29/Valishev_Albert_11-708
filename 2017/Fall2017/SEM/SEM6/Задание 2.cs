using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem6Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int sum = 0;
            var results = new int[n]; 
            for(int j = 0; j < array.Length - 1; j++)
            {
                sum += array[j];
                results[j] = sum;
                
            }
            for (int i = 0; i < n + 1; i++)
            {
                int l = int.Parse(Console.ReadLine());
                int r = int.Parse(Console.ReadLine());
                int x = int.Parse(Console.ReadLine());
                array[l] += x;
                array[r + 1] -= x;
                for (int j = l; j < r + 1; j ++)
                {
                    array[j] += x;
                }
            }
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }

        }
    }
}
