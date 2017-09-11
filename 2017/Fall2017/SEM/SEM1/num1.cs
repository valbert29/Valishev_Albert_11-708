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
            a = 123;
            int b = (a/100);
            b = (a / 100) + (((a % 100) / 10) * 10) + ((a % 10) * 100);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
