using NUnit.Framework;

namespace TddBook.Tests.Unit.SetupAndFixture._1_OneTimeSetup
{
    public class B_DerivedTests : A_Tests
    {
        [SetUp] 
        public void Setup2()
        {
            TestContext.WriteLine("B_Setup2");
        }

        [TearDown]
        public void TearDown2()
        {
            TestContext.WriteLine("B_TearDown2");
        }

        [Test]
        public void test2()
        {
            TestContext.WriteLine("B_Test2");
        }
    }
}
