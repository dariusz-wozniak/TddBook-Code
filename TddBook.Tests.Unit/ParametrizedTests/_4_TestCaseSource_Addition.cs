using System.Collections.Generic;
using NUnit.Framework;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class _4_TestCaseSource_Addition
    {
        [TestCaseSource(nameof(AdditionCases))]
        public void addition_test(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(
            typeof(AdditionTestData),
            nameof(AdditionTestData.AdditionCases))]
        public void addition_test_with_external_data(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(typeof(AdditionTestDataEnumerable))]
        public void addition_test_with_external_enumerable_data(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(
            typeof(AdditionTestCaseData), 
            nameof(AdditionTestCaseData.AdditionCases))]
        public int addition_test_with_testcasedata(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// The UnknownCases doesn't exist but the test run itself
        /// </summary>
        [Test]
        // ReSharper disable once NotResolvedInText
        [TestCaseSource("UnknownCases")]
        [Ignore("The UnknownCases do not exist")]
        public void addition_test_with_nonexisting_cases(int a, int b, int expectedResult)
        {
            Assert.That(a + b, Is.EqualTo(expectedResult));
        }

        private static IEnumerable<int[]> AdditionCases
        {
            get
            {
                yield return new[] { 2, 2, 4 };
                yield return new[] { 1, -1, 0 };
            }
        }
    }
}