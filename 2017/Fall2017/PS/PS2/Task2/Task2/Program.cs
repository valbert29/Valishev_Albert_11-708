using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите точность: ");//Exercise 2
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine(Class.FindCos(e, 0.0));
        }

    }

}

