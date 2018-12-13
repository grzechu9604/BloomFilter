using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterProject
{
    class BloomFilter
    {
        public readonly long Size;
        public readonly long K;

        private readonly bool[] _filterArray;
        private readonly Tuple<long, long>[] _functionsArray;

        public BloomFilter(long size, long k)
        {
            Size = size;
            K = k;

            _filterArray = new bool[K];
            _functionsArray = new Tuple<long, long>[K];
            InitializeFunctionsArray();
        }

        private void InitializeFunctionsArray()
        {
            for (long i = 0; i < K; i++)
            {

            }
        }
    }
}
