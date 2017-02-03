using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace TheTwoEggs
{
    [TestClass]
    public class Tests
    {
        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test100()
        {
            Check.That(Solution.MinTries(100)).Equals(14);
        }

        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test1000()
        {
            Check.That(Solution.MinTries(1000)).Equals(45);
        }

        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test3()
        {
            Check.That(Solution.MinTries(3)).Equals(2);
        }

        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test24()
        {
            Check.That(Solution.MinTries(24)).Equals(7);
        }

        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test40()
        {
            Check.That(Solution.MinTries(40)).Equals(9);
        }

        [TestMethod, TestCategory("TheTwoEggs")]
        public void Test50()
        {
            Check.That(Solution.MinTries(50)).Equals(10);
        }
    }
}