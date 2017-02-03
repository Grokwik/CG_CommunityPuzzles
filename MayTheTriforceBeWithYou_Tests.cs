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
            var output = Solution.DisplayTriforce(1);
            Check.That(output).Equals(".*\n* *");
        }

        [TestMethod]
        public void Test2()
        {
            var output = Solution.DisplayTriforce(2);
            Check.That(output).Equals(".  *\n  ***\n *   *\n*** ***");
        }
    }
}