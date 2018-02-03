using NUnit.Framework;

namespace TddBook.Tests.Unit.SetupAndFixture._0_SimpleExample
{
    public class SimpleTest
    {
        [SetUp]
        public void Setup() { TestContext.WriteLine("Setup"); }

        [TearDown]
        public void TearDown() { TestContext.WriteLine("TearDown"); }

        [Test]
        public void test() { TestContext.WriteLine("Test"); }
    }
}
