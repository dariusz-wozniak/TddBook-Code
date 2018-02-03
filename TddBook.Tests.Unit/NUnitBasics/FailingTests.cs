using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class FailingTests
    {
        [Test]
        [Explicit]
        public void failing_test()
        {
            Assert.That(2 + 2, Is.EqualTo(5));
        }

        [Test]
        [Explicit]
        public void failing_test_with_own_message()
        {
            const int actual = 2 + 2;
            const int expected = 5;

            Assert.That(actual, 
                Is.EqualTo(expected), 
                $"Adding 2 + 2 should be equal to {expected}. " +
                    $"The actual result was: {actual}");
        }
    }
}
