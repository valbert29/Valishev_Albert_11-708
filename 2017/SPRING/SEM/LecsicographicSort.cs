using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecsicograficSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToChar(2));
            Sorted.LecsicSort(4);//тут длина макс слова
            Sorted.PrintOut();
        }


    }

    class Sorted
    {
        public static List<string> words = new List<string>();
        public static void LecsicSort(int maxLength)
        {
            words = new List<string> { "ab", "aa", "cd", "ac", "az", "abc", "bba" };
            var length = words.Count;
            words = CheckLength(words, maxLength);
            for (int i = maxLength - 1; i >= 0; i--)
            {
                var Pocket = new List<string>[27];
                for (int j = 0; j < 27; j++)
                {
                    Pocket[j] = new List<string>();
                }
                for (int k = 0; k < words.Count; k++)
                {
                    Pocket[((Convert.ToInt32(words[k][i])) - 96)].Add(words[k]);
                }
                ConvertPocketToList(Pocket);
            }
        }
        public static void ConvertPocketToList(List<string>[] pocket)
        {
            words = new List<string>();
            for (int i = 0; i < pocket.Length; i++)
            {
                words.AddRange(pocket[i]);
            }
        }

        public static void PrintOut()
        {
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }

        public static List<string> CheckLength(List<string> str, int length)
        {
            for (int i = 0; i < str.Count; i++)
            {
                if (str[i].Length != length)
                {
                    while (str[i].Length != length)
                        str[i] += '`';
                }
            }
            return str;
        }
    }


}
