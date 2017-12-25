using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)//задача узнает, является ли набор данных последовательностью
        {
            Console.Write("введите n - количество членов последовательности: ");//подается n
            int n = Int32.Parse(Console.ReadLine());//вводим данные
            int a = 0;
            int b = 0;
            int k = 1;
            for (int i = 1; i <= (n); i++) 

            {
                Console.WriteLine("Введите " + i + " член последовательности");//вводим члены последовательности
                a = Int32.Parse(Console.ReadLine());
		// ---check--- зачем это условие? надо было просто последовательно проверять все элементы из последовательности a<b
                if(i!=n)
                {

                    Console.WriteLine("Введите " + (i + 1) + " член последовательности");
                    b = Int32.Parse(Console.ReadLine());
                    i++;
                    int c = b - a;
                    if (c > 0)//проверяем, является ли этот набор данных последовательностью
                    {
                        k *= 1;
                    }
                    else
                    {
                        k *= 0;
                    }
                }
                
            }
            if (k == 1) Console.WriteLine("Является!");//выводим ответ по вычисленным данным
            else Console.WriteLine("Не является!");
        }
    }
}
