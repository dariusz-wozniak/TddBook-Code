using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class IgnoredAndExplicitTests
    {
        [Test]
        [Explicit]
        public void @explicit()
        {
            Assert.Pass();
        }

        [Test]
        [Ignore("Don't care about me")]
        public void ignore()
        {
            Assert.Pass();
        }

        [Test]
        [Ignore("Check if system works after 2000", Until = "2000-01-01 00:01:00Z")]
        public void y2k_test()
        {
            Assert.Pass();
        }

        [TestCase(0, Ignore = "Zero is not supported yet")]
        [TestCase(1)]
        public void some_calculations(int number)
        {
            Assert.Pass();
        }
    }
}