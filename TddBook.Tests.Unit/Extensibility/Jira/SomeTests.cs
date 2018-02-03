using NUnit.Framework;

namespace TddBook.Tests.Unit.Extensibility.Jira
{
    public class SomeTests
    {
        [Test]
        [JiraInfo(Id = 31337, Title ="Some hotfix", Description = "Sth didn't work as expected")]
        public void some_jira_hotfix()
        {
            Assert.Pass();
        }
    }
}