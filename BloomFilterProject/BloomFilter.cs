using BloomFilterProject.HashFunctions;
using System.Linq;
using System.Threading.Tasks;

namespace BloomFilterProject
{
    class BloomFilter
    {
        public readonly int Size;
        public readonly int K;
        public readonly int Range;

        private readonly bool[] _filterArray;
        private readonly HashFunction[] _functionsArray;

        public BloomFilter(int size, int k, int range)
        {
            Size = size;
            K = k;
            Range = range;

            _filterArray = new bool[Range];
            _functionsArray = new HashFunction[K];
            InitializeFunctionsArray();
        }

        private void InitializeFunctionsArray()
        {
            for (long i = 0; i < K; i++)
            {
                _functionsArray[i] = HashFunctionGenerator.Generate(Range);
            }
        }

        private long CalculateFilterArrayIndex(int value, long functionIndex)
        {
            return _functionsArray[functionIndex].Calculate(value);
        }

        public void Add(int value)
        {
            Parallel.For(0, K, i => {
                var index = CalculateFilterArrayIndex(value, i);
                _filterArray[index] = true;
            });
        }

        public bool Contains(int value)
        {
            return _functionsArray.ToList().TrueForAll(function => _filterArray[function.Calculate(value)]);
        }
    }
}
