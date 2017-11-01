using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите k - систему исчисления(от 2 до 5): ");// Найти самую часто повторяющуюся цифру в k-ичной
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите n - число, которое нужно обработать: ");//  системе счисления (k от 2 до 5) десятичного натурального числа n (n<=10^9)
            int n = int.Parse(Console.ReadLine());
            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            int k4 = 0;
            int k0 = 0;
            while (n > 0)
            {
                int k = n % i;
                n /= i;
                k0 = MethodSchetaChisel(k, 0, k0);
                k1 = MethodSchetaChisel(k, 1, k1);
                k2 = MethodSchetaChisel(k, 2, k2);
                k3 = MethodSchetaChisel(k, 3, k3);
                k4 = MethodSchetaChisel(k, 4, k4);
            }

            int znach = 0;
            znach = MethodMaxZnach(k0, znach);
            znach = MethodMaxZnach(k1, znach);
            znach = MethodMaxZnach(k2, znach);
            znach = MethodMaxZnach(k3, znach);
            znach = MethodMaxZnach(k4, znach);
            string kaef = "";
            int schet = 0;
            MethodSravneniya(k0, znach, ref kaef, ref schet, 0);
            MethodSravneniya(k1, znach, ref kaef, ref schet, 1);
            MethodSravneniya(k2, znach, ref kaef, ref schet, 2);
            MethodSravneniya(k3, znach, ref kaef, ref schet, 3);
            MethodSravneniya(k4, znach, ref kaef, ref schet, 4);

            Console.WriteLine("частовстречаемые числа: " + kaef);
        }

        private static void MethodSravneniya(int k0, int znach, ref string kaef, ref int schet,int m)
        {
            if (znach == k0)
            {
                schet++;
                kaef +=m+" ";
            }
        }

        private static int MethodMaxZnach(int k0, int znach)
        {
            if (k0 > znach)
            {
                znach = k0;
            }

            return znach;
        }

        private static int MethodSchetaChisel(int k, int num, int k0)
        {
            if (k == num)
            {
                k0++;
            }

            return k0;
        }
    }
}