using System;

namespace LibraryFor1b
{
    public class TestClass1b
    {
        public static double[] FindValue(double e, double x)
        {
            double step = 1;
            var p = -1;
            double c = 1.0 / 1;
            double value;
            value = c;
			// ---check--- что это за извращение - Math.Sqrt(Math.Pow(c, 2)) ?
            while ((Math.Sqrt(Math.Pow(c, 2))) > e)
            {
                c *= (p * (2 * step) * (2 * step - 1) * x * (-2 * step + 3) / (-2 * step + 1) / (step * step) / 4);
                value += c;
                step++;
            }
            return new double[] { value, step };
        }
    }
}
