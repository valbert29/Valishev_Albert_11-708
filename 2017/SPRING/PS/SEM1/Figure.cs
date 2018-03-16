using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestr1
{
    public class Figure
    {
        public int Type { get; set; }//тип фигуры 1- прямоугольник, 2 – отрезок, 3 круг
        public int XLU { get; set; }//Х - левой верхней вершины
        public int YLU { get; set; }//Y - левой верхней вершины
        public int XRD { get; set; }//Х - правой нижней вершины
        public int YRD { get; set; }//Y - правой нижней вершины
        public int Color { get; set; }//Color - номер цвета фигуры
        public Figure Next;

        public Figure(int type, int xLU, int yLU, int xRD, int yRD, int color)
        {
            if (type == 3 && yRD != 0) ;
            Type = type;
            XLU = xLU;
            YLU = yLU;
            XRD = xRD;
            YRD = yRD;
            Color = color;
            Next = null;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Figure)) return false;
            var item = obj as Figure;
            return XLU == item.XLU && YLU == item.YLU && XRD == item.XRD && YRD == item.YRD
                &&Type == item.Type && Color == item.Color;
        }
    }
}
