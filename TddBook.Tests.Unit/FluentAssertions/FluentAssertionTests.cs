using FluentAssertions;
using NUnit.Framework;

namespace TddBook.Tests.Unit.FluentAssertions
{
    public class FluentAssertionTests
    {
        [Test]
        public void some_simple_tests()
        {
            const string firstName = "Agnieszka";
            Assert.Multiple(() =>
            {
                firstName.Should().Be("Agnieszka");
                firstName.Should().StartWith("Ag").And.EndWith("a").And.Contain("szk");
            });
        }
    }
}
