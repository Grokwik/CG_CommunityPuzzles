using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Project
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1()
        {
            var n = 1;
            Check.That(Solution.Min(n)).Equals(6);
            Check.That(Solution.Max(n)).Equals(6);
        }

        [TestMethod]
        public void Test2()
        {
            // 3 * 3 * 1
            var n = 9;
            Check.That(Solution.Min(n)).Equals(30);
            Check.That(Solution.Max(n)).Equals(38);
        }

        [TestMethod]
        public void Test3()
        {
            // 6 * 6 * 4
            var n = 144;
            Check.That(Solution.Min(n)).Equals(168);
            Check.That(Solution.Max(n)).Equals(578);
        }

        [TestMethod]
        public void Test4()
        {
            // 42 * 42 * 40
            var n = 70560;
            Check.That(Solution.Min(n)).Equals(10248);
            Check.That(Solution.Max(n)).Equals(282242);
        }

        [TestMethod]
        public void Test5()
        {
            // 1697 * 97 * 6
            var n = 987654;
            Check.That(Solution.Min(n)).Equals(350746);
            Check.That(Solution.Max(n)).Equals(3950618);
        }

        [TestMethod]
        public void Test6()
        {
            // 101 * 101 * 101
            var n = 1030301;
            Check.That(Solution.Min(n)).Equals(61206);
            Check.That(Solution.Max(n)).Equals(4121206);
        }

        [TestMethod]
        public void Test7()
        {
            // 83 * 6 * 4
            var n = 1992;
            Check.That(Solution.Min(n)).Equals(1708);
            Check.That(Solution.Max(n)).Equals(7970);
        }

        [TestMethod]
        public void Test8()
        {
            // 7 * 2 * 2
            var n = 28;
            Check.That(Solution.Min(n)).Equals(64);
            Check.That(Solution.Max(n)).Equals(114);
        }

        [TestMethod]
        public void Test9()
        {
            // 11 * 2 * 2
            var n = 44;
            Check.That(Solution.Min(n)).Equals(96);
            Check.That(Solution.Max(n)).Equals(178);
        }

        [TestMethod]
        public void Test10()
        {
            // 11 * 2 * 2
            var n = 52;
            Check.That(Solution.Min(n)).Equals(112);
            Check.That(Solution.Max(n)).Equals(210);
        }

        [TestMethod]
        public void Test11()
        {
            var n = 68;
            Check.That(Solution.Min(n)).Equals(144);
            Check.That(Solution.Max(n)).Equals(274);
        }

        [TestMethod]
        public void Test12()
        {
            var n = 76;
            Check.That(Solution.Min(n)).Equals(160);
            Check.That(Solution.Max(n)).Equals(306);
        }

        [TestMethod]
        public void Test13()
        {
            // 23  * 2 * 2
            var n = 92;
            Check.That(Solution.Min(n)).Equals(192);
            Check.That(Solution.Max(n)).Equals(370);
        }

        [TestMethod]
        public void Test14()
        {
            // 113 * 27 * 26
            var n = 79326;
            Check.That(Solution.Min(n)).Equals(13382);
            Check.That(Solution.Max(n)).Equals(317306);
        }
    }
}