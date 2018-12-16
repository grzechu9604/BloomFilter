using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BloomFilterProject.Tests
{
    [TestClass()]
    public class PrimeNumberGeneratorTests
    {
        [TestMethod()]
        public void GetFirstGreaterTest()
        {
            Assert.AreEqual(3, PrimeNumberGenerator.GetFirstGreater(2));
            Assert.AreEqual(5, PrimeNumberGenerator.GetFirstGreater(4));
            Assert.AreEqual(7, PrimeNumberGenerator.GetFirstGreater(5));
            Assert.AreEqual(11, PrimeNumberGenerator.GetFirstGreater(8));
            Assert.AreEqual(7, PrimeNumberGenerator.GetFirstGreater(5));
            Assert.AreEqual(23, PrimeNumberGenerator.GetFirstGreater(22));
            Assert.AreEqual(53, PrimeNumberGenerator.GetFirstGreater(52));
            Assert.AreEqual(29, PrimeNumberGenerator.GetFirstGreater(25));
        }
    }
}