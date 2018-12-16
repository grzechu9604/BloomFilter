using System;

namespace BloomFilterProject.Exceptions
{
    class RangeTooBigException : Exception
    {
        public override string Message => "Range is too big to create prime int value";
    }
}
