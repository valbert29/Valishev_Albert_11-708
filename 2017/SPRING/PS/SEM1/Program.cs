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
            var myDo = new Do();
            //myDo.MyList = myList;
            myDo.MyList = myList;

            myList.Add(new Figure(1, 2, 3, 4, 5, 6), 0);
            myList.Add(new Figure(2, 2, 3, 3, 5, 6), 1);
            myList.Add(new Figure(3, 2, 3, 4, 5, 6), 2);
            myList.Remove(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("basic methods:");
            myDo.Decode();
                        
            myList = myDo.RectangleCoordinates(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("rectCoordsList:");
            myDo.Decode();
            
            myList = myDo.Encode();
            Console.WriteLine("Encode:");
            myDo.Decode();

            myDo.Encode();
            myList = myDo.LinesToRectangle();
            Console.WriteLine("lineToRectList:");
            myDo.Decode();

            Console.WriteLine("Введите констaнту:");
            int n = int.Parse(Console.ReadLine());
            myDo.BuildListByConst(n);
            Console.WriteLine("byConstList:");
            myDo.Decode();


        }
    }
}
