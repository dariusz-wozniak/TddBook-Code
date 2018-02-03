using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _4_TestCaseSource_EvenNumbers
    {
        [TestCaseSource(nameof(EvenNumbers))]
        public void is_even(int number)
        {
            Assert.That(number % 2, Is.Zero);
        }

        private static readonly int[] EvenNumbers = { 0, 2, 4, 6, 20, 40 };
    }
}