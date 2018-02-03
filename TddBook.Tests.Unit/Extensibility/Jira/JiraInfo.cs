using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TddBook.Tests.Unit.Extensibility.Jira
{
    public class JiraInfo : Attribute, ITestAction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }

        public void BeforeTest(ITest test)
        {
            Console.WriteLine("JIRA Info" + Environment.NewLine + 
                "ID: " + Id + Environment.NewLine +
                "Title: " + Title + Environment.NewLine +
                "Description: " + Description + Environment.NewLine);
        }

        public void AfterTest(ITest test) { }
    }
}