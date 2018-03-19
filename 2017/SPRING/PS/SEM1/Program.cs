using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Semestr1
{        
    class Program
    {
        static void Main(string[] args)
        {

            var myList = new FigureList();
            var helper = new Tools();
            helper.MyList = myList;

            myList.Add(new Figure(1, 2, 3, 4, 5, 6), 0);
            myList.Add(new Figure(2, 2, 3, 3, 5, 6), 1);
            myList.Add(new Figure(3, 2, 3, 4, 5, 6), 2);
            myList.Remove(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("basic methods:");
            helper.Decode();
                        
            myList = helper.RectangleCoordinates(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("rectCoordsList:");
            helper.Decode();
            
            myList = helper.Encode();
            Console.WriteLine("Encode:");
            helper.Decode();

            helper.Encode();
            myList = helper.LinesToRectangle();
            Console.WriteLine("lineToRectList:");
            helper.Decode();

            Console.WriteLine("Введите констaнту:");
            int n = int.Parse(Console.ReadLine());
            helper.BuildListByConst(n);
            Console.WriteLine("byConstList:");
            helper.Decode();


        }
    }
}
