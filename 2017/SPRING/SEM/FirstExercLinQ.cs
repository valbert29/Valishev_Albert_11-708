using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _270318practice
{
    /*1. Дано целое число L (> 0) и последовательность
непустых строк A. Строки последовательности содержат
только цифры и заглавные буквы латинского алфавита. Из
элементов A, предшествующих первому элементу, длина ко-
торого превышает L, извлечь строки, оканчивающиеся бук-
вой. Полученную последовательность отсортировать по убы-
ванию длин строк, а строки одинаковой длины — в лексико-
графическом порядке по возрастанию.*/
    class FirstExercLinQ
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите L");
            var l = Int32.Parse(Console.ReadLine());
            string[] lines = new string[50];
            var result = FindFirstElem(l, lines);
        }

        public static string[] FindFirstElem(int l, IEnumerable<string> lines)
        {
            var c = true;
            return lines
                 .Where(line =>
                 {
                     if (!c)
                     {
                         return false;
                     }
                     else
                     {
                         c = (line.Length <= l && 0 <= line[line.Length - 1] - 90 && line[line.Length - 1] - 90 <= 35);
                         if (line.Length > l) c = false;
                     }
                     return c;
                 })
                 .OrderByDescending(x => x.Length).ThenBy(x => StringComparer.CurrentCulture)
                 .ToArray();
        }

        public static string[] FindSequence(int l, IEnumerable<string> lines)
        {
            return lines
                .TakeWhile(line => line.Length < l)
                .Where(line =>
                {
                    return 0 <= line[line.Length - 1] - 90 && line[line.Length - 1] - 90 <= 35;
                })
                .OrderByDescending(x => x.Length).ThenBy(x => x)
                .ToArray();
        }
    }
}
