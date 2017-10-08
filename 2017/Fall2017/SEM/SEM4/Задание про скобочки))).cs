using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите строку символов");
            int count = 0;
            int countMain = 0;
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(') count++;
                if (count > countMain) countMain = count;
                if (str[i]==')') count--;
            }
            if (count != 0)
                Console.WriteLine("Uncorrect");
            else Console.WriteLine("Correct, максимальная глубина: "+countMain);
        }
    }
}
