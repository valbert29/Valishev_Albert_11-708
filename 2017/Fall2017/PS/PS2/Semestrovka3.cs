﻿using ConsoleApp37;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The1Point3Task
{
    class Program
    {
        static void Main(string[] args)//Ex 1.3 Valishev 2var
        {
            Console.WriteLine("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Сумма последовательности - {0}", TestClassFor1.CalculateGraduatedNum(e, x));
        }
        
    }
}