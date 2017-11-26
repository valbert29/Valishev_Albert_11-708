using System;
using System.Collections.Generic;
using System.Text;

namespace Solve
{
    public class TestClass3
    {
        public static double CalculateLeftRectangle(int n, double a, double b)//Метод левых прямоугольников
        {
            var h = Math.Abs(b - a) / n;
            double summ = 0.0;
            for (int i = 0; i < n - 1; i++)
            {
                summ += Math.Sqrt(Math.Tan(i * h)) * h;
            }
            return summ;
        }

        public static double CalculateRightRectangle(int n, double a, double b)//Метод правых прямоугольников
        {
            var step = Math.Abs(b - a) / n;
            double summ = 0.0;
            for (int i = n - 1; i > 0; i--)
            {
                summ += Math.Sqrt(Math.Tan(i * step)) * step;
            }
            return summ;
        }

        public static double CalculateTrapeze(int n, double a, double b)//Метод Трапеций
        {
            var step = Math.Abs(b - a) / n;
            double summ = 0.0;
            for (int i = 0; i < n - 1; i++)
            {

                summ += (Math.Sqrt(Math.Tan(i * step)) + Math.Sqrt(Math.Tan((i + 1) * step))) * step / 2;//h - длина отрезка(высота трапеции)
            }
            return summ;
        }

        public static double CalculateSimpson(int n, double a, double b)//Метод Симпсона
        {
            double step = Math.Abs(b - a) / n;
            double summ = 0.0;
            double currentValue = 0.0;
            currentValue = a + step;
            while (currentValue < b)
            {
                summ += 4 * Math.Sqrt(Math.Tan(currentValue));
                currentValue = currentValue + step;
                summ += 2 * Math.Sqrt(Math.Tan(currentValue));
                currentValue = currentValue + step;
            }
            return (step / 3 * (summ + Math.Sqrt(Math.Tan(a)) - Math.Sqrt(Math.Tan(b))));
        }

        public static double CalculateMonteKarlo(int n, double b)//Метод Monte-Karlo
        {
            int numOfDown = 0;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                double maxF = Math.Sqrt(Math.Tan(b));//MAXзначение Ф в максимальной точке
                double numY = random.NextDouble() * maxF;//рандом по Y
                double numX = random.NextDouble() * b;//рандом по X

                if (numY <= Math.Sqrt(Math.Tan(numX)))
                {
                    numOfDown++;

                }


            }
            return Math.Sqrt(Math.Tan(b)) * b * (double)numOfDown / n;//S прямоугольника на отношение
        }
    }
}
