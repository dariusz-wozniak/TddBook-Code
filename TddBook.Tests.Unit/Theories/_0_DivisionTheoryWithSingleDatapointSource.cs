using NUnit.Framework;

namespace TddBook.Tests.Unit.Theories
{
    public class _0_DivisionTheoryWithSingleDatapointSource
    {
        [DatapointSource]
        private readonly double[] _numbers = { -10.0, -6.3, 0, 1, 4.2, 120.7 };

        [Theory]
        public void when_dividing_positive_number_by_zero_then_result_is_positive_infinity(double number)
        {
            Assume.That(number, Is.Positive);

            double quotient = number / 0;

            Assert.That(quotient, Is.EqualTo(double.PositiveInfinity));
        }

        [Theory]
        public void when_dividing_zero_by_zero_then_result_is_nan(double number)
        {
            Assume.That(number, Is.Zero);

            double quotient = number / 0;

            Assert.That(quotient, Is.EqualTo(double.NaN));
        }

        [Theory]
        public void when_dividing_negative_number_by_zero_then_result_is_negative_infinity(double number)
        {
            Assume.That(number, Is.Negative);

            double quotient = number / 0;

            Assert.That(quotient, Is.EqualTo(double.NegativeInfinity));
        }
    }
}
