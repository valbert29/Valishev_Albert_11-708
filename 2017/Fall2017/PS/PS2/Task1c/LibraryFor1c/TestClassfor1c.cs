using System;

namespace LibraryFor1c
{
    public class TestClassFor1c
    {
        public static double[] CalculateGraduatedNum(double e, int x)
        {
            double sequence = 1;
            double k = 1;
            int step = 0;
            while (k > e)
            {
                step++;
                k *= (x * Math.Log(3) / step);
                sequence += k;
            }
            return new double[] { sequence, step };
        }
    }
}
