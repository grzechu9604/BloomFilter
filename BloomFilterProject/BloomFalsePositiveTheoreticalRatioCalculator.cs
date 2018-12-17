using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterProject
{
    public class BloomFalsePositiveTheoreticalRatioCalculator
    {
        public static double Calculate(int k, double n, int m)
        {
            return Math.Pow((1 - Math.Exp(-(k * n) / m)), k);
        }
    }
}
