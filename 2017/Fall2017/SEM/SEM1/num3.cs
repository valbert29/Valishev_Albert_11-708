using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("H(количество Часов):");
            int H = Int32.Parse(Console.ReadLine());
            var P = H;
            if (P >= 12) P = P - 12;
            var M = P * 30;
            if (M > 180) M = 360 - M;
            string Str = H + " часов -> " + M.ToString() + " градусов";
            Console.WriteLine(Str);
        } 
    }
}
