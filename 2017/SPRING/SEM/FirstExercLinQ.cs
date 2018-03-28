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
            return lines
                 .Where(line =>
                 {
                     while (line.Length < l)
                     {
                         return (line.Length <= l && 0 <= line[line.Length - 1] - 90 && line[line.Length - 1] - 90 <= 35);
                     }
                     return false;
                 })
                 .OrderByDescending(x => x.Length).ThenBy(x => StringComparer.CurrentCulture)
                 .ToArray();
        }
    }
}
