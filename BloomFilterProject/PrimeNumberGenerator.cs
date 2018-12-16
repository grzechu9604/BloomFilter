using System.Collections.Generic;
using System.Linq;

namespace BloomFilterProject
{
    public static class PrimeNumberGenerator
    {
        private static List<long> _primes = new List<long>();

        public static long GetFirstGreater(long value)
        {
            long firstGreater = _primes.FirstOrDefault(prime => prime > value);
            if (firstGreater > 0)
            {
                return firstGreater;
            }
            else
            {
                return GenerateFirstGreater(value);
            }
        }

        private static long GenerateFirstGreater(long value)
        {
            long greatestPrime = _primes.LastOrDefault();
            
            if (greatestPrime == 0)
            {
                greatestPrime = 2;
                _primes.Add(greatestPrime);
            }

            long currentValue = greatestPrime + 1;

            while (greatestPrime <= value)
            {
                if (_primes.TrueForAll(prime => currentValue % prime != 0))
                {
                    greatestPrime = currentValue;
                    _primes.Add(greatestPrime);
                }

                currentValue++;
            }

            return greatestPrime;
        }
    }
}
