using System;

namespace LibraryFor1a
{
    public class ClassFor1a
    {
        public static double[] FindValueAndStep(double e)
        {
            double step = 2;
            double c = 1.0 / 2;
            double value = c;
            while (c > e)
            {
                c *= ((step - 1) * (step - 1) / (2 * step - 1) / (2 * step));
                value += c;
                step++;
            }
            //Console.Write("Шаг - " + (step - 1));
            //Console.WriteLine();
            return new double[] {value, step};
        }
    }
}
