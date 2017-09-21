using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)//задача про козла на веревке, который ест траву
        {
            string str = Console.ReadLine();
            double rad, storona;
            storona = double.Parse(str.Substring(0, str.IndexOf(' ')));
            str = str.Substring(str.IndexOf(' ') + 1);
            rad = double.Parse(str);
            if (storona / 2 >= rad)
            {
                Console.WriteLine(Math.Round(rad * rad * Math.PI, 3));
            }
            else
            {
                if (Math.Pow(rad, 2) - Math.Pow(storona / 2, 2) >= Math.Pow(storona / 2, 2))
                {
                    Console.WriteLine(Math.Pow(storona, 2));
                }
                else
                {
                    Double x, alpha;
                    x = Math.Sqrt(Math.Pow(rad, 2) - Math.Pow(storona / 2, 2));
                    alpha = 2 * Math.Asin(x / rad);
                    double otvet;
                    otvet = Math.Pow(rad, 2) * Math.PI - 4 * 0.5 * (alpha - Math.Sin(alpha)) * Math.Pow(rad, 2);
                    Console.WriteLine(Math.Round(otvet, 3));
                }
            }


        }
    }
}
