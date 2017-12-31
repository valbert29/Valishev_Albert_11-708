using System;

namespace Sort3
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var array = GetArray(n);
            MergeSort(array);
            foreach (var e in array)
                Console.WriteLine(e);
        }

        static void Merge(int[] array, int start, int middle, int end, int[] temporaryArray)
        {
            var leftPtr = start;
            var rightPtr = middle + 1;
            var length = end - start + 1;
            for (int i = 0; i < length; i++)
            {
                if (rightPtr > end || (leftPtr <= middle && array[leftPtr] < array[rightPtr]))
                {
                    temporaryArray[i] = array[leftPtr];
                    leftPtr++;
                }
                else
                {
                    temporaryArray[i] = array[rightPtr];
                    rightPtr++;
                }
            }
            for (int i = 0; i < length; i++)
                array[i + start] = temporaryArray[i];
        }

        static void MergeSort(int[] array, int start, int end, int[] temporaryArray)
        {
            if (start == end) return;
            var middle = (start + end) / 2;
            MergeSort(array, start, middle, temporaryArray);
            MergeSort(array, middle + 1, end, temporaryArray);
            Merge(array, start, middle, end, temporaryArray);

        }

        static void MergeSort(int[] array)
        {
            var temporaryArray = new int[array.Length];
            MergeSort(array, 0, array.Length - 1, temporaryArray);
        }

        static int[] GetArray(int n)
        {
            var lens = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                lens[i] = random.Next();
            }
            return lens;
        }
    }
}
