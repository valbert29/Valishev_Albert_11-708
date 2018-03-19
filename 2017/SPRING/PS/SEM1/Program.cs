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
            var helper = new Tool();
            helper.MyList = myList;

            //вставки некоторой фигуры в некоторую позицию списка 
            //(при вставке учесть существует ли подобный элемент в списке, 
            //если да – то заменить существующий, например, может поменяться цвет фигуры);
            myList.AddByIndex(new Figure(1, 2, 3, 4, 5, 6), 0);
            myList.AddByIndex(new Figure(2, 2, 3, 3, 5, 6), 1);
            myList.AddByIndex(new Figure(3, 2, 3, 4, 5, 6), 2);
            myList.Remove(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("basic methods:");
            helper.Decode();

            //Построить новый список, состоящий из фигур, которые имеют общие точки с некоторым прямоугольником
            myList = helper.CreateByRectangleCoordinates(new Figure(1, 2, 3, 4, 5, 6));
            Console.WriteLine("rectCoordsList:");
            helper.Decode();

            //построение списка по множеству фигур, заданному набором строк в некотором текстовом файле;
            myList = helper.Encode(@"C:\Users\Пользователь\Desktop\TEXT.txt");
            Console.WriteLine("Encode:");
            helper.Decode();

            //Каждый отрезок с координатами(X1, Y1); (X2, Y2) при условии, что X1<>X2 и Y1<> Y2, 
            //заменить прямоугольником  некоторого цвета, в противном случае удалить из списка  
            helper.Encode(@"C:\Users\Пользователь\Desktop\TEXT.txt");
            myList = helper.LinesToRectangle();
            Console.WriteLine("lineToRectList:");
            helper.Decode();

            //Построить новый список из фигур,
            //площади которых более некоторой константы(задается пользователем в интерактивном режиме).
            Console.WriteLine("Введите констaнту:");
            int n = int.Parse(Console.ReadLine());
            helper.BuildListByConst(n);
            Console.WriteLine("byConstList:");
            helper.Decode();


        }
    }
}
