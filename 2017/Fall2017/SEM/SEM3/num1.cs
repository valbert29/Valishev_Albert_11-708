using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        enum figure {King, Queen, Knight, Bishop,Rook}

        static void Main(string[] args)
        {
            Console.WriteLine("введите x фигуры: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y фигуры: ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("введите x проверяемой точки: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите y проверяемой точки: ");
            int y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите название фигуры(King, Queen, Knight, Bishop,Rook),: ");
            figure fig = (figure)int.Parse(Console.ReadLine());

            checkCorrectWay(x, y, x1, y1, figure);

        }

        private static bool checkCorrectWay(int x, int y, int x1, int y1, figure fig)
        {
            if (fig == figure.Knight) return ((Math.Abs(x1 - x) == 2 && Math.Abs(y1 - y) == 1) || (Math.Abs(x1 - x) == 1 && Math.Abs(y1 - y) == 2));
            if (fig == figure.Bishop) return (Math.Abs(x1 - x) == Math.Abs(y1 - y));
            if (fig == figure.Rook) return ((Math.Abs(x1 - x) != 0 && Math.Abs(y1 - y) == 0) ||
                (Math.Abs(x1 - x) == 0 && Math.Abs(y1 - y) != 0));
            if (figure == figure.Queen) return ((Math.Abs(x1 - x) == Math.Abs(y1 - y)) ||
                ((y1 == y) && (x1 - x) != 0) || (x1 == x) && (y1 - y) != 0);
            if (figure == figure.King) return ((Math.Abs(x1 - x) == 1) && (y1 == y) ||
                (Math.Abs(y1 - y) == 1) && (x1 == x) || (Math.Abs(y1 - y) == Math.Abs(x1 - x)));
        }
    }
}
