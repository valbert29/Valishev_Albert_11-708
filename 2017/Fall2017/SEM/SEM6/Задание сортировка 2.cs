using System;

namespace Sort2
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var array = GetArray(n);
            HoareSort(array);
            foreach (var e in array)
                Console.WriteLine(e);
        }

        static int[] GetArray(int n)
        {
            var lens = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                lens[i] = random.Next(0, 100000);
            }
            return lens;
        }

        static void HoareSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) HoareSort(array, start, storeIndex - 1);
            if (storeIndex < end) HoareSort(array, storeIndex + 1, end);
        }

        static void HoareSort(int[] array)
        {
            HoareSort(array, 0, array.Length - 1);
        }
    }
}
