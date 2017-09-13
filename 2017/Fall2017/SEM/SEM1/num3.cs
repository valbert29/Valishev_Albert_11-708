using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int v;
            a = 1899;
            b = 1913;
            v = (b - a) / 4 - (b - a) / 100 + (b - a) / 400;
            Console.WriteLine(v);
        }
    }
}
