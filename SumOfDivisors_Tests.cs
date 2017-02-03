using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Project
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1_2()
        {
            var Sum = Solution.SumOfDiv(2);
            Check.That(Sum).Equals(4L);
        }

        [TestMethod]
        public void Test2_10()
        {
            var Sum = Solution.SumOfDiv(10);
            Check.That(Sum).Equals(87L);
        }

        [TestMethod]
        public void Test3_1000()
        {
            var Sum = Solution.SumOfDiv(1000);
            Check.That(Sum).Equals(823081L);
        }

        [TestMethod]
        public void Test4_600()
        {
            var Sum = Solution.SumOfDiv(600);
            Check.That(Sum).Equals(296729L);
        }

        [TestMethod]
        public void NoBruteForce()
        {
            var Sum = Solution.SumOfDiv(90000);
            Check.That(Sum).Equals(6662106690L);
        }
    }
}