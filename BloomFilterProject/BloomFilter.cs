using BloomFilterProject.Exceptions;
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

        private long CalculateFilterArrayIndex(long value, long functionIndex)
        {
            var coefficients = _functionsArray[functionIndex];
            return (coefficients.Item1 * value + coefficients.Item2) % Size;
        }

        public void AddToSet(long value)
        {
            Parallel.For(0, K, i => {
                var index = CalculateFilterArrayIndex(value, i);
                _filterArray[index] = true;
            });
        }

        public bool IsInSet(long value)
        {
            try
            { 
                Parallel.For(0, K, i =>
                {
                    long index = CalculateFilterArrayIndex(value, i);
                    if (!_filterArray[index])
                    {
                        throw new ValueNotInSetException();
                    }
                });
            }
            catch (ValueNotInSetException)
            {
                return false;
            }

            return true;
        }
    }
}
