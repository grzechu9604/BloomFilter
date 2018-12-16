using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            int k = 1;

            Random random = new Random(0);

            BloomFilter bf = new BloomFilter(size, k);

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


            Console.WriteLine("TP = " + string.Format("%6d", TP) + "\tTPR = " + string.Format("%1.4f", (double)TP / (double)n));
            Console.WriteLine("TN = " + string.Format("%6d", TN) + "\tTNR = " + string.Format("%1.4f", (double)TN / (double)(range - n)));
            Console.WriteLine("FN = " + string.Format("%6d", FN) + "\tFNR = " + string.Format("%1.4f", (double)FN / (double)(n)));
            Console.WriteLine("FP = " + string.Format("%6d", FP) + "\tFPR = " + string.Format("%1.4f", (double)FP / (double)(range - n)));
        }
    }
}
