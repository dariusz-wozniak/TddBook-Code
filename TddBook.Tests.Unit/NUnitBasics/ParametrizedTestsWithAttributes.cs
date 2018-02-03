using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class ParametrizedTestsWithAttributes
    {
        [TestCase(0, Ignore = "Zero is not supported yet")]
        [TestCase(1, Author = "Jan Kowalski", Description = "Test of 1", Explicit = true)]
        [TestCase(2, IncludePlatform = "64-Bit-OS")]
        [TestCase(3)]
        public void some_tests(int number)
        {
            Assert.Pass();
        }
    }
}
