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
            var myDo = new Do();
            var myList = myDo.MyList;

            myList.Add(new Figure(1, 2, 3, 4, 5, 6), 0);
            myList.Remove(new Figure(1, 2, 3, 4, 5, 6));
            myList = myDo.RectangleCoordinates(new Figure(1, 2, 3, 4, 5, 6));
            var list = myDo.Encode();
            myDo.MyList = list;
            myDo.Decode();
            //сначала ссылку с вспомогательного класса переносим на тот, над которым хотим работать и работаем
            myDo.MyList = myList;
            myDo.LinesToRectangle();
            var myList1 = new FigureList();
            var list2 = new Do();
            list2.MyList = myList1;
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                myList1.Add(new Figure(2, rnd.Next(0, 6), rnd.Next(0, 6),
    rnd.Next(0, 4), rnd.Next(0, 4), rnd.Next(0, 4)), i);
            }
            for (int i = 0; i < 2; i++)
            {
                myList1.Add(new Figure(2, i, i, i, i, rnd.Next(0, 8)), i);
            }
            var newLine = list2.LinesToRectangle();
            Figure item = newLine.head;
            var n = -1;
            while (item != null)
            {
                if (item.Type != 1) n = 1;
                item = item.Next;
            }

        }
    }
}
