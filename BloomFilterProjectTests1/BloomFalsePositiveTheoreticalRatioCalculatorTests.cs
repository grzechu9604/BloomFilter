using Microsoft.VisualStudio.TestTools.UnitTesting;
using BloomFilterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterProject.Tests
{
    [TestClass()]
    public class BloomFalsePositiveTheoreticalRatioCalculatorTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            Assert.AreEqual(0.1175, BloomFalsePositiveTheoreticalRatioCalculator.Calculate(1, 1, 8), 0.00001);
            Assert.AreEqual(0.1175, BloomFalsePositiveTheoreticalRatioCalculator.Calculate(1, 2, 16), 0.00001);
            Assert.AreEqual(0.1175, BloomFalsePositiveTheoreticalRatioCalculator.Calculate(1, 3, 24), 0.00001);
        }
    }
}