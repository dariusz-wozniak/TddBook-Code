using System.Threading;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    [Parallelizable(ParallelScope.Children)]
    public class ThreadingRelatedTests
    {
        [Test]
        [Apartment(ApartmentState.MTA)]
        public void so_many_attributes()
        {
            Assert.Pass();
        }

        [Test]
        [RequiresThread]
        [Order(0)]
        public void have_a_separate_thread()
        {
            Thread.Sleep(1000);

            Assert.Pass();
        }
    }
}
