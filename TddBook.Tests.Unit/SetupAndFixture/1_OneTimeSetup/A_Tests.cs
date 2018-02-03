using NUnit.Framework;

namespace TddBook.Tests.Unit.SetupAndFixture._1_OneTimeSetup
{
    public class A_Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup1()
        {
            TestContext.WriteLine("A_OneTimeSetup_1st");
        }

        [OneTimeSetUp]
        public void OneTimeSetup2()
        {
            TestContext.WriteLine("A_OneTimeSetup_2nd");
        }

        [SetUp]
        public void Setup1()
        {
            TestContext.WriteLine("A_Setup_1st");
        }

        [SetUp]
        public void Setup2()
        {
            TestContext.WriteLine("A_Setup_2nd");
        }

        [TearDown]
        public void TearDown1()
        {
            TestContext.WriteLine("A_TearDown");
        }

        [Test]
        public void test1()
        {
            TestContext.WriteLine("A_Test");
        }
    }
}