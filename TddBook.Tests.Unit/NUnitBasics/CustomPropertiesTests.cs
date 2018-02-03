using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class CustomPropertiesTests
    {
        [Test]
        [Property("Year", 1998)]
        [Property("Country", "Japan")]
        [Property("Country", "China")]
        public void test_with_custom_properties()
        {
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;

            int year = test.Properties["Year"].Cast<int>().Single();
            // year = 1998

            IEnumerable<string> countries = test.Properties["Country"].Cast<string>();
            // countries = { "Japan", "China" }
        }
    }
}