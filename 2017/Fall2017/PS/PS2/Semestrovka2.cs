﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLybraryfor12;

namespace Ex12
{
    class Program
    {
        static void Main(string[] args)//Exercise 1.2
        {
            Console.WriteLine("Введите точность e: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите |X|<=1: ");
            double x = double.Parse(Console.ReadLine());
            double answer = TestClass12.FindValue(e, x);
            Console.Write("Значение - " + answer);
        }
        
    }
}