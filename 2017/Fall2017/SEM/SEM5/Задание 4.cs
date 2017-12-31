using System;
using System.Collections.Generic;

namespace sem5ex4
{
    class Program
    {
        static void Main()
        {
            var arrayA = GetNumber();
            var arrayB = GetNumber();
            var mergeArray = Merger(arrayA, arrayB);
            Console.WriteLine("MergeArray :");
            foreach (var e in mergeArray)
                Console.WriteLine(e);
            var intersectionArray = Intersection(arrayA, arrayB);
            Console.WriteLine("IntersectionArray :");
            foreach (var e in intersectionArray)
                Console.WriteLine(e);
            var differenceArray = Difference(mergeArray, intersectionArray);
            Console.WriteLine("DifferenceArray :");
            foreach (var e in differenceArray)
                Console.WriteLine(e);
        }

        static int[] GetNumber()
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static int[] Merger(int[] arrayA, int[] arrayB)
        {
            var n = arrayA.Length + arrayB.Length;
            var array = new int[n];
            for (int i = 0; i < arrayA.Length; i++)
            {
                array[i] = arrayA[i];
            }
            for (int i = 0; i < n - arrayA.Length; i++)
            {
                array[arrayA.Length + i] = arrayB[i];
            }
            Sort(array);
            return array;
        }

        static int[] Intersection(int[] arrayA, int[] arrayB)
        {
            var list = new List<int>();
            for (int i = 0; i < arrayA.Length; i++)
            {
                for(int j = 0; j < arrayB.Length; j++)
                {
                    if (arrayA[i] == arrayB[j]) list.Add(arrayA[i]);
                }
            }
            var array = list.ToArray();
            Sort(array);
            return array;
        }

        static int[] Difference(int[] mergeArray, int[] intersectionArray)
        {
            var list = new List<int>();
            var add = true;
            for (int i = 0; i < mergeArray.Length; i++)
            {
                for (int j = 0; j < intersectionArray.Length; j++)
                {
                    if (mergeArray[i] == intersectionArray[j]) add = false;
                }
                if (add) list.Add(mergeArray[i]);
                add = true;
            }
            var array = list.ToArray();
            Sort(array);
            return array;
        }

        private static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
            }
        }
    }
}
