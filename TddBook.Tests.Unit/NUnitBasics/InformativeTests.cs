using System;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class InformativeTests
    {
        [Test]
        public void when_adding_2_and_2_then_result_should_be_4()
        {
            TestContext.WriteLine($"[{DateTime.Now}] Starting test...");
            TestContext.WriteLine($"[{DateTime.Now}] Verify if 2 + 2 = 4");

            const int actual = 2 + 2;
            const int expected = 4;

            Assert.That(actual, Is.EqualTo(expected));

            TestContext.WriteLine($"[{DateTime.Now}] Test has been finished");
        }

    }
}
