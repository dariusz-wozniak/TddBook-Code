using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TddBook.Calculators;

namespace TddBook.Tests.Unit.Asynchronous
{
    public class AsyncTests
    {
        [Test]
        public async Task when_dividing_four_by_two_then_the_result_is_two()
        {
            var calculator = new Calculator();

            decimal quotient = await calculator.DivideAsync(4, 2);

            Assert.That(quotient, Is.EqualTo(2));
        }

        [Test]
        public void when_dividing_four_by_two_then_the_result_is_two_lambda_async()
        {
            var calculator = new Calculator();

            Assert.That(async () => await calculator.DivideAsync(4, 2), Is.EqualTo(2));
        }

        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(-4, 2, ExpectedResult = -2)]
        [TestCase(4, -2, ExpectedResult = -2)]
        [TestCase(0, 3, ExpectedResult = 0)]
        [TestCase(5, 2, ExpectedResult = 2.5)]
        public async Task<decimal> when_dividing_two_numbers_then_result_is_properly_calculated(decimal dividend, decimal divisor)
        {
            var calculator = new Calculator();

            return await calculator.DivideAsync(dividend, divisor);
        }

        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(-4, 2, ExpectedResult = -2)]
        [TestCase(4, -2, ExpectedResult = -2)]
        [TestCase(0, 3, ExpectedResult = 0)]
        [TestCase(5, 2, ExpectedResult = 2.5)]
        public decimal when_dividing_two_numbers_then_result_is_properly_calculated_lambda_async(decimal dividend, decimal divisor)
        {
            var calculator = new Calculator();

            ActualValueDelegate<Task<decimal>> actualValueDelegate = async () => await calculator.DivideAsync(dividend, divisor);

            Task<decimal> invoke = actualValueDelegate.Invoke();
            return invoke.Result;
        }

        [Test]
        public void when_dividing_by_zero_then_exception_is_thrown()
        {
            var calculator = new Calculator();

            Assert.That(async () => await calculator.DivideAsync(2, 0), Throws.TypeOf<DivideByZeroException>());
        }
    }
}