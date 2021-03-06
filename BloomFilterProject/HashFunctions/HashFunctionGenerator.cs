﻿using BloomFilterProject.Exceptions;
using System;

namespace BloomFilterProject.HashFunctions
{
    class HashFunctionGenerator
    {
        private static Random _randomGenerator = new Random(1);

        public static HashFunction Generate(int range)
        {
            long longPrime = PrimeNumberGenerator.GetFirstGreater(range);

            if (longPrime > int.MaxValue)
            {
                throw new RangeTooBigException();
            }

            int prime = Convert.ToInt32(longPrime);

            int a = _randomGenerator.Next(1, prime - 1);
            int b = _randomGenerator.Next(0, prime - 1);

            return new HashFunction(prime, range, a, b);
        }
    }
}
