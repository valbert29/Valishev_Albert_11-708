using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            int i;
            for (i = 1; i < 1000; i++)
            {
                if (i % 5 == 0)
                {
                    k = k + i;
                }
                if (i%3==0)
                {
                    k = k + i;
                }
                if (i%15==0)
                {
                    k = k - i;
                }
            }
            Console.WriteLine(k);
        }

    }
}
