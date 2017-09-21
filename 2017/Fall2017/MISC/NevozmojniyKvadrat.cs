using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
	

	class Risovatel
	{
		static Bitmap image = new Bitmap(800, 600);
		static float x, y;
		static Graphics graphics = Graphics.FromImage(image);

        public static void SetPos(float x0, float y0)
        {
            MyMethod(x0, y0);
        }

        private static void MyMethod(float x0, float y0)// метод присваивает значения, оч полезный
        {
            x = x0;
            y = y0;
        }

        public static void Go(double l, double angle)
		{
			//Делает шаг длиной L в направлении angle и рисует пройденную траекторию
			var x1 = (float)(x + l * Math.Cos(angle));
			var y1 = (float)(y + l * Math.Sin(angle));
			graphics.DrawLine(Pens.Red, x, y, x1, y1);
            MyMethod(x1, y1);
		}

		public static void ShowResult()
		{
			image.Save("result.bmp");
			Process.Start("result.bmp");
		}
	}

	public class StrangeThing
	{
		public static void Main()
        {


            //Рисуем четыре одинаковые части невозможного квадрата.
            // Часть первая:

            MyNewMethod(10, 0, 0);

            // Часть вторая:
            MyNewMethod(120, 10, 1);

            // Часть третья:
            MyNewMethod(110, 120, 2);
            // Часть четвертая:
            MyNewMethod(0, 110, 3);
            Risovatel.ShowResult();
        }

        private static void MyNewMethod(int x, int y, int k) // волшебный метод, рисует сторону по значениям
        {
            Risovatel.SetPos(x, y);
            Risovatel.Go(100, k*Math.PI / 2);
            Risovatel.Go(10 * Math.Sqrt(2), k*Math.PI / 2 + Math.PI / 4);
            Risovatel.Go(100, k*Math.PI / 2 + Math.PI);
            Risovatel.Go(100 - (double)10, k*Math.PI / 2 + Math.PI / 2);
        }
    }
}
