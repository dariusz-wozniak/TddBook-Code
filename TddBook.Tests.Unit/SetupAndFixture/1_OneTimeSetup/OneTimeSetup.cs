using NUnit.Framework;

namespace TddBook.Tests.Unit.SetupAndFixture._1_OneTimeSetup
{
    [SetUpFixture]
    public class OneTimeSetup
    {
        [OneTimeSetUp]
        public void OneTime()
        {
            TestContext.WriteLine("Project_OneTimeSetup");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Project_OneTimeTearDown");
        }
    }
}