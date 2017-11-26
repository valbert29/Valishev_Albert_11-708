using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary
{
    public class Class
    {
        public static double FindCos(double e, double x)
        {
            double value = Math.Cos(x);
            if (Math.Abs(value - x) < e) return value;
            return FindCos(e, value);
        }
    }
}
