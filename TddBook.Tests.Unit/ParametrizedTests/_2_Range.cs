using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _2_Range
    {
        [Test]
        public void when_multiplying_by_zero_then_result_is_zero(
            [Range(from: -2, to: 2, step: 1)] int a)
        {
            Assert.That(a * 0, Is.Zero);
        }
    }
}