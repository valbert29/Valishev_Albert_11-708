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
            int b = 3;
            int a = 2;
            b = b - a;
            a = a + b;
            b = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
