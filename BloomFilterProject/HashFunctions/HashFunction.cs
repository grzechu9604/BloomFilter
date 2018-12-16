namespace BloomFilterProject.HashFunctions
{
    class HashFunction
    {
        public readonly long P;
        public readonly long M;
        public readonly long A;
        public readonly long B;

        public HashFunction(long p, long m, long a, long b)
        {
            P = p;
            M = m;
            A = a;
            B = b;
        }

        public long Calculate(long argument)
        {
            return ((A * argument + B) % P) % M;
        }
    }
}
