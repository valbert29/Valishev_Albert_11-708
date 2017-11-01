using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter делимое: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter делитель: ");
            int secondNum = int.Parse(Console.ReadLine());
            if (secondNum == 0) Console.WriteLine("Невозможно поделить ");//если знаменатель = 0
            else
            {
                var mainString = new StringBuilder();
                mainString.Append(firstNum * secondNum > 0 ? "" : "-");
                mainString.Append(firstNum / secondNum);
                firstNum %= secondNum;//первому числу присваиваем остаток от деления
                int[] someArray = new int[100];
                if (firstNum == 0) mainString.Append("." + 0);//если остаток = 0, то выводим число
                else
                {
                    mainString.Append(".");
                    while (firstNum > 0)
                    {
                        someArray[firstNum] = mainString.Length;//некому элементу массива от целовчисленного остатка
                        firstNum = firstNum * 10;
                        mainString.Append(firstNum / secondNum);//присваивается длина основной строки
                        firstNum = firstNum % secondNum;
                        if (someArray[firstNum] > 0)//пока значение не повторится данные массива будут заполняться
                        {
                            mainString.Insert(someArray[firstNum], '(');//при появлении повторного цикл останавливает и 
                            mainString.Append(')');//прописываются ( - перед значением периода ) - в конце
                            break;
                        }
                        someArray[firstNum] = mainString.Length;//тут присваиватеся новое значени основной строки
                    }
                }
                Console.WriteLine(mainString);               
            }

        }
    }
}
