using System;
using NUnit.Framework;

namespace TddBook.Tests.Integration.ParametrizedTests
{
    public class Log2NTests
    {
        [TestCaseSource(typeof(Log2NData), nameof(Log2NData.Data))]
        public void Log2N(double a, double expectedResult)
        {
            double result = Math.Log(a, newBase: 2);

            Assert.That(result, Is.EqualTo(expectedResult).Within(0.000000000001));
        }
    }
}