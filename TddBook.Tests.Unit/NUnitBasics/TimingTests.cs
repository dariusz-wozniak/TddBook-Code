using System.Threading;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class TimingTests
    {
        [Test]
        [Explicit]
        [Timeout(1000)]
        public void timeout()
        {
            for (int i = 1; i < 10; ++i)
            {
                TestContext.WriteLine($"Run #{i}");
                Thread.Sleep(250);
            }

            Assert.Pass();
        }

        [Test]
        [Explicit]
        [MaxTime(1000)]
        public void max_time()
        {
            Thread.Sleep(1000);
            TestContext.WriteLine("After sleep thread");
        }
    }
}