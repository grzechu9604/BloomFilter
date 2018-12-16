using System.Collections.Generic;
using System.Linq;

namespace BloomFilterProject
{
    class PrimeNumberGenerator
    {
        private static List<long> _primes = new List<long>();

        public static long GetFirstGreater(long value)
        {
            long? firstGreater = _primes.FirstOrDefault(prime => prime > value);
            if (firstGreater.HasValue)
            {
                return firstGreater.Value;
            }
            else
            {
                return GenerateFirstGreater(value);
            }
        }

        private static long GenerateFirstGreater(long value)
        {
            long? greatestPrime = _primes.LastOrDefault();
            
            if (!greatestPrime.HasValue)
            {
                greatestPrime = 2;
                _primes.Add(greatestPrime.Value);
            }

            long currentValue = greatestPrime.Value + 1;

            while (greatestPrime <= value)
            {
                if (_primes.TrueForAll(prime => currentValue % prime != 0))
                {
                    greatestPrime = currentValue;
                    _primes.Add(greatestPrime.Value);
                }

                currentValue++;
            }

            return greatestPrime.Value;
        }
    }
}
