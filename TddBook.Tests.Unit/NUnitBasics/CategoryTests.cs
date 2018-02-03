using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class CategoryTests
    {
        [Test]
        [Category("Defect")]
        [Category("v1.1.5429")]
        public void defect()
        {
            Assert.Pass();
        }

        [Test]
        [Defect]
        [Category("v1.2.0183")]
        public void yet_another_defect()
        {
            Assert.Pass();
        }
    }
}