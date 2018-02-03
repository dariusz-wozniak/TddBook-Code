using NUnit.Framework;
using TddBook.CodeCoverage;

namespace TddBook.Tests.Unit.CodeCoverage
{
    public class NumberTests
    {
        [Test]
        public void number_two_should_be_even()
        {
            bool isEven = Number.IsEven(2);

            Assert.That(isEven, Is.True);
        }
    }
}
