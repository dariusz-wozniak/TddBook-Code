using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _1_Values
    {
        [Test]
        public void when_multiplying_by_zero_then_result_is_zero(
            [Values(-1, 0, 1)] int a)
        {
            Assert.That(a * 0, Is.Zero);
        }

        [Test]
        public void when_multiplying_negative_by_positive_number_then_result_is_negative(
            [Values(1, 2, 3)] int a,
            [Values(-1, -2)] int b)
        {
            Assert.That(a * b, Is.Negative);
        }
    }
}