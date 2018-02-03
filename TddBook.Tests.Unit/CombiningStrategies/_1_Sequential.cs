using NUnit.Framework;

namespace TddBook.Tests.Unit.CombiningStrategies
{
    public class _1_Sequential
    {
        [Test]
        [Sequential]
        public void sequential_test(
            [Values(1, 2, 3)] int number,
            [Values("a", "b")] string text,
            [Values] bool boolean)
        {            
            TestContext.WriteLine($"number: {number}");
            TestContext.WriteLine($"text: {text}");
            TestContext.WriteLine($"boolean: {boolean}");
        }
    }
}