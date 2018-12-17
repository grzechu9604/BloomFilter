using System;
using System.Collections.Generic;

namespace BloomFilterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10_000;
            int range = 100_000_000;
            double factor = 10;
            int size = (int)Math.Round(factor * n);

            for (int k = 1; k < 10; k++)
            {
                Random random = new Random(0);

                BloomFilter bf = new BloomFilter(size, k, range);

                HashSet<long> set = new HashSet<long>();

                for (int i = 0; i < n; i++)
                {
                    int value = random.Next(range);
                    set.Add(value);
                    bf.Add(value);
                }

                int TP = 0, FP = 0, TN = 0, FN = 0;

                for (int i = 0; i < range; i++)
                {
                    int key = i; //random.Next(range);
                    bool containsBF = bf.Contains(key);
                    bool containsHS = set.Contains(key);

                    if (containsBF && containsHS)
                    {
                        TP++;
                    }
                    else if (!containsBF && !containsHS)
                    {
                        TN++;
                    }
                    else if (!containsBF && containsHS)
                    {
                        FN++;
                    }
                    else if (containsBF && !containsHS)
                    {
                        FP++;
                    }
                }
                double theoreticalFPRatio = BloomFalsePositiveTheoreticalRatioCalculator.Calculate(k, n, size);
                Console.WriteLine($"K = {k}");
                Console.WriteLine("Theoretical FP ratio =  " + string.Format("{0:P4}", theoreticalFPRatio));
                Console.WriteLine("TP = " + string.Format("{0:d6}", TP) + "\tTPR = " + string.Format("{0:P4}", (decimal)TP / (decimal)n));
                Console.WriteLine("TN = " + string.Format("{0:d6}", TN) + "\tTNR = " + string.Format("{0:P4}", (decimal)TN / (decimal)(range - n)));
                Console.WriteLine("FN = " + string.Format("{0:d6}", FN) + "\tFNR = " + string.Format("{0:P4}", (decimal)FN / (decimal)(n)));
                Console.WriteLine("FP = " + string.Format("{0:d6}", FP) + "\tFPR = " + string.Format("{0:P4}", (decimal)FP / (decimal)(range - n)));
            }
        }
    }
}
