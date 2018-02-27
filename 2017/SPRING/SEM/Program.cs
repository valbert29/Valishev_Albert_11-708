using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvyazGraph
{
    class Program
    {
        static void Main(string[] args)
        {

            var c = new SvyaznoiGraph();
            while (true)
            {
                Console.WriteLine("1-");
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine("2-");
                int j = int.Parse(Console.ReadLine());
                var str = new int[10];
                str[i-1] = i;
                c.AddGraph(i, j, new int[10]);
            }
        }
}

class SvyaznoiGraph
{   

    public bool IsCorrect(int i, int j)
    {
        return (i == j);
    }

    public void AddGraph(int i, int j, int[] str)
    {
        if (IsCorrect(str[i], str[j]))
        {
                Console.WriteLine("Already exist");
        }
        else
        {
            for (int k = 0; k < str.Length; k++)
            {
                if (str[k] == j)
                {
                    str[k] = str[i];
                }
            }
        }
    }
}
}
