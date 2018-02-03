using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _0_TestCase
    {
        [TestCase(1, 2)]
        [Ignore("Number of parameters are mismatched")]
        public void number_of_parameters_are_mismatched(int a, int b, int c)
        {
            Assert.Pass();
        }

        [TestCase(0, 2, 2)]
        [TestCase(2, 3, 5)]
        public void addition_test(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 3, ExpectedResult = 5)]
        public int addition_test_with_expected_result(int a, int b)
        {
            return a + b;
        }
    }
}
