using System;
using NUnit.Framework;
using TddBook.Calculators;

namespace TddBook.Tests.Unit.FirstSteps
{
    public class CalculatorTests
    {
        [Test]
        public void when_dividing_four_by_two_then_the_result_is_two()
        {
            // Arrange:
            var calculator = new Calculator();
            decimal expectedQuotient = 2;

            // Act:
            decimal quotient = calculator.Divide(4, 2);

            // Assert:
            Assert.AreEqual(expectedQuotient, quotient);
        }

        [TestCase(4, 2, 2)]
        [TestCase(-4, 2, -2)]
        [TestCase(4, -2, -2)]
        [TestCase(0, 3, 0)]
        [TestCase(5, 2, 2.5)]
        [TestCase(1, 3, "0.3333333333333333333333333333")]
        [TestCase(2, 3, "0.6666666666666666666666666667")]
        public void when_dividing_two_numbers_then_result_is_properly_calculated(decimal dividend, decimal divisor, decimal expectedQuotient)
        {
            // Arrange:
            var calculator = new Calculator();

            // Act:
            decimal quotient = calculator.Divide(dividend, divisor);

            // Assert:
            Assert.AreEqual(expectedQuotient, quotient);
        }

        [Test]
        public void when_dividing_one_by_three_then_the_result_is_0_comma_3333333333333333333333333333()
        {
            // Arrange:
            var calculator = new Calculator();

            // Act:
            decimal quotient = calculator.Divide(1, 3);

            // Assert:
            Assert.AreEqual(expected: 0.3333333333333333333333333333M, actual: quotient);
        }

        [Test]
        public void when_dividing_two_by_three_then_the_result_is_0_comma_6666666666666666666666666667()
        {
            // Arrange:
            var calculator = new Calculator();

            // Act:
            decimal quotient = calculator.Divide(2, 3);

            // Assert:
            Assert.AreEqual(expected: 0.6666666666666666666666666667M, actual: quotient);
        }

        [Test]
        public void when_dividing_two_by_three_then_the_result_is_0_comma_6666666_within_tolerance()
        {
            // Arrange:
            var calculator = new Calculator();
            double expected = 0.6666666d;

            // Act:
            decimal quotient = calculator.Divide(2, 3);

            // Assert:
            Assert.AreEqual(expected, (double)quotient, delta: 0.0000001);
        }

        [Test]
        public void when_dividing_by_zero_then_exception_is_thrown()
        {
            // Arrange:
            var calculator = new Calculator();

            // Act & Assert:
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
        }

        [Test]
        public void when_division_is_complete_then_an_event_is_called()
        {
            // Arrange:
            var calculator = new Calculator();
            bool hasEventBeenCalled = false;

            // Act:
            calculator.Calculated += (sender, result) => hasEventBeenCalled = true;
            calculator.Divide(4, 2);

            // Assert:
            Assert.IsTrue(hasEventBeenCalled);
        }

        [Test]
        public void when_dividing_is_complete_then_result_is_passed_to_event_args()
        {
            // Arrange:
            var calculator = new Calculator();
            decimal? quotient = null;

            // Act:
            calculator.Calculated += (sender, result) => quotient = result;
            calculator.Divide(4, 2);

            // Assert:
            Assert.NotNull(quotient);
            Assert.AreEqual(2, quotient.Value);
        }
    }
}
