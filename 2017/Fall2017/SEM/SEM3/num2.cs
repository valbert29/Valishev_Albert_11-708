using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("x фигуры: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("y фигуры: ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("z фигуры: ");
            int z = int.Parse(Console.ReadLine());
            Console.WriteLine("a отверстия: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("b фигуры: ");
            int b = int.Parse(Console.ReadLine());
            int c = (Math.Min(Math.Max(x, y), Math.Max(x, z)));
            if ((Math.Min(z, Math.Min(x, y)) < Math.Min(a, b)) && (Math.Max(a, b)) > c)
                Console.WriteLine(true);
            else Console.WriteLine(false);

        }
    }
}
