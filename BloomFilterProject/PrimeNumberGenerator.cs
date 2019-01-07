using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BloomFilterProject
{
    public static class PrimeNumberGenerator
    {
        private static readonly string _primesListXmlFileName = "PrimesList.xml";
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

            SerializePrimesList();

            return greatestPrime;
        }

        public static long GetFirstGreaterFast(long value)
        {
            long firstGreater = _primes.FirstOrDefault(prime => prime > value);
            if (firstGreater > 0)
            {
                return firstGreater;
            }
            else
            {
                firstGreater = GenerateFirstGreaterFast(value);
                _primes.Add(firstGreater);
                return firstGreater;
            }
        }

        private static long GenerateFirstGreaterFast(long value)
        {
            long current = value;
            bool isPrime = false;
            
            while(!isPrime)
            {
                current++;
                isPrime = true;
                long maxDivisor = Convert.ToInt64(Math.Floor(Math.Sqrt(current)));
                for (int i = 2; i <= maxDivisor; i++)
                {
                    if (current % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            return current;
        }

        private static void SerializePrimesList()
        {
            var serializer = new XmlSerializer(typeof(List<long>));
            using (StreamWriter sw = new StreamWriter(_primesListXmlFileName))
            {
                serializer.Serialize(sw, _primes);
            }
        }
    }
}
