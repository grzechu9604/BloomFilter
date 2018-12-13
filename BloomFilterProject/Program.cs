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
            var filter = new BloomFilter(1000, 4);
            filter.AddToSet(10);
        }
    }
}
