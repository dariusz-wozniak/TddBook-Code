using NUnit.Framework;

namespace TddBook.Tests.Unit.CombiningStrategies
{
    public class _0_Combinatorial
    {
        [Test]
        [Combinatorial]
        public void combinatorial_test(
            [Values(1, 2, 3)] int number,
            [Values("a", "b")] string text,
            [Values] bool boolean)
        {
            // ...
        }
    }
}
