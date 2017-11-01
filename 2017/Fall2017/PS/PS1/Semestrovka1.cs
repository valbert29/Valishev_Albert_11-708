using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)//в этой задаче надо определить, можно ли пойти конем на заданную точку
        {
            Console.WriteLine("введите x фигуры: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y фигуры: ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("введите x проверяемой точки: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y проверяемой точки: ");
            int y1 = int.Parse(Console.ReadLine());
            if ((Math.Abs(x1 - x) == 2 && Math.Abs(y1 - y) == 1) || (Math.Abs(x1 - x) == 1 && Math.Abs(y1 - y) == 2))
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");

        }
    }
}
