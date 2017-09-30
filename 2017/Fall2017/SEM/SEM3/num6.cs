using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите x 1 точки: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y 1 точки: ");
            int y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите x 2 точки: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y 2 точки: ");
            int y2 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите x 3 точки: ");
            int x3 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y 3 точки: ");
            int y3 = int.Parse(Console.ReadLine());
            int k = 0;
            if ((x1 == x2) && (x2 != x3) && (y1 != y2) && (y2 == y3)) Console.WriteLine(x3 + ", " + y1);
            else k += 1;
            if ((x1 == x3) && (x2 != x3) && (y1 != y3) && (y2 == y3)) Console.WriteLine(x2 + ", " + y1);
            else k += 1;
            if ((x1 == x2) && (x1 != x3) && (y1 != y2) && (y1 == y3)) Console.WriteLine(x3 + ", " + y2);
            else k += 1;
            if ((x3 == x2) && (x1 != x3) && (y3 != y2) && (y1 == y3)) Console.WriteLine(x1 + ", " + y2);
            else k += 1;
            if ((x3 == x2) && (x2 != x1) && (y3 != y2) && (y2 == y1)) Console.WriteLine(x3 + ", " + y1);
            else k += 1;
            if ((x3 == x1) && (x2 != x1) && (y3 != y1) && (y2 == y1)) Console.WriteLine(x3 + ", " + y2);
            else k += 1;
            if (k == 6) Console.WriteLine("Не является :(");
        }
    }
}
