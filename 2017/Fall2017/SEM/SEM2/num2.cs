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
            Console.Write("введите значение часовой стрелки");
                int x = int.Parse(Console.ReadLine());
            Console.Write("введите значение минутной стрелки");
                int y = int.Parse(Console.ReadLine());
            if (x>12)
            {
                x -= 12;
            }
            double otvet =1.0;
            double grm = y * 6;
            double grh = x * 30 + grm / 12;
            double ugol = Math.Abs(grh - grm);
            if (ugol >180)
            {
                 otvet = (360 - ugol);
            }
            else
            {
                otvet = ugol;
            }
            Console.WriteLine(grm);
            Console.WriteLine(grh);
            Console.WriteLine(otvet);
        }   


    }
}
