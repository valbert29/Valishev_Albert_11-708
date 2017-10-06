using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n от 0 до 100: ");//вводим n
            int n = int.Parse(Console.ReadLine());//первый множитель кол-во элементов, второй: сумма первого..
            Console.WriteLine("Сумма всех " + n + "-значных чисел: " + 
                (((9 * Math.Pow(10, n - 1)) * (Math.Pow(10, n - 1) + Math.Pow(10, n) - 1)) / 2));
            //и последних чисел
        }
    }
}
