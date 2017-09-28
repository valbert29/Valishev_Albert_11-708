

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите число: ");
            int n = int.Parse(Console.ReadLine());
            if ((((n - 1) % 10) + (((n - 1) / 10) % 10) + (((n - 1) / 100) % 10) ==
                (((n - 1) / 1000) % 10) + (((n - 1) / 10000) % 10) + (((n - 1) / 100000) % 10))||
                    (((n + 1) % 10) + (((n + 1) / 10) % 10) + (((n + 1) / 100) % 10) ==
                (((n + 1) / 1000) % 10) + (((n + 1) / 10000) % 10) + (((n + 1) / 100000) % 10)))
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
