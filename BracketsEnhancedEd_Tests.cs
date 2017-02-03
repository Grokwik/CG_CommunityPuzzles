using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace BracketsEnhancedEd
{
    [TestClass]
    public class Tests
    {
        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test1_1()
        {
            Check.That(Solution.DoIt("<{[(abc(]}>")).IsTrue();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test1_2()
        {
            Check.That(Solution.DoIt("<{[(abc>]}>")).IsFalse();
        }
        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_1()
        {
            Check.That(Solution.DoIt("{([]){}()}")).IsTrue();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_2()
        {
            Check.That(Solution.DoIt("{([{S}]]6K[()]}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_3()
        {
            Check.That(Solution.DoIt("{C{}[{[a]}RqhL]{y2}}")).IsTrue();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_4()
        {
            Check.That(Solution.DoIt("W12{}{}L{}")).IsTrue();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_5()
        {
            Check.That(Solution.DoIt("h{Pn{GT{h}(c))}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_6()
        {
            Check.That(Solution.DoIt("{[{iHTSc}]}(p)(R)m{q({})")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test2_7()
        {
            Check.That(Solution.DoIt("][")).IsTrue();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_1()
        {
            Check.That(Solution.DoIt("{([]){}())")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_2()
        {
            Check.That(Solution.DoIt("<{([{S}]]6K[()]}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_3()
        {
            Check.That(Solution.DoIt("{C{}[{[a>]}RqhL]{y2}}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_4()
        {
            Check.That(Solution.DoIt("W12{}({}L{}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_5()
        {
            Check.That(Solution.DoIt("h{Pn{G{T{h}(c))}")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_6()
        {
            Check.That(Solution.DoIt("{[{iHTSc}]}pRm(>){q({})")).IsFalse();
        }

        [TestMethod, TestCategory("BracketsEnhancedEd")]
        public void Test3_7()
        {
            Check.That(Solution.DoIt("][[")).IsFalse();
        }
    }
}