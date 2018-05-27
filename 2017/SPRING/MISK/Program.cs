using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PotokSumm
{
    class Program
    {
        public int[] Str { get; set; }
        static int result = 0;
        public static int n = 100;

        static void Main(string[] args)
        {
            var st = new Program
            {
                Str = new int[n]
            };
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                st.Str[i] = i;
            }

            st.CountSumm(st.Str);
            Console.WriteLine(result);
        }
        int k = 10;//диапазон
        public void CountSumm(int[] matrix)
        {
            for (int i = 0; i < n / k; i++)
            {
                var tread = new Thread(() => Func(matrix, i * k, i * k + k));
                tread.Start();
                //Thread.Sleep(2);
                tread.Join();
            }
        }

        static void Func(int[] str, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                result += str[i];
                Console.WriteLine(result);
            }
        }
    }

}
