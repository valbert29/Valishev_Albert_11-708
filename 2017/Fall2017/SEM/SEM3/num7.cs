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
            Console.WriteLine("введите x - начальный рейтинг: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("введите y - желаемый рейтинг: ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("введите кол-во проголосовавших: ");
            int n = int.Parse(Console.ReadLine());
            int i = 1;
            string c = "";
            if (x <= y) Console.WriteLine(0);
            if ((y == 1) && (y != x))
            {
                c = "Impossible";
                
            }
            else while ((Math.Round(((x * n + i) / (n + i)), 1)) > y)
                {
                    i++;
                    c = i.ToString();
                }
                Console.WriteLine(c);
            

        }       
    }
}
