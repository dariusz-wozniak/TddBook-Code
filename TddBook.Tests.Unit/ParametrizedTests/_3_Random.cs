using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _3_Random
    {
        [Test]
        public void when_multiplying_negative_by_positive_number_then_result_is_negative(
            [Random(min: 1, max: 1000, count: 10)] int a,
            [Random(min: -1000, max: -1, count: 10)] int b)
        {
            Assert.That(a * b, Is.Negative);
        }
    }
}