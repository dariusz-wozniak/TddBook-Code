using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _5_ValueSource
    {
        [Test]
        public void when_multiplying_negative_by_positive_number_then_result_is_negative(
            [ValueSource(nameof(PositiveNumbers))] int a,
            [ValueSource(nameof(NegativeNumbers))] int b)
        {
            Assert.That(a * b, Is.Negative);
        }

        private static readonly int[] PositiveNumbers = { 1, 2, 3 };
        private static readonly int[] NegativeNumbers = { -1, -2, -3 };
    }
}