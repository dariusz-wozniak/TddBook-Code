using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace TddBook.Tests.Unit.Mocking._7_Accessibility
{
    public class AccessibilityTests
    {
        [Test]
        public void protected_property()
        {
            var theClass = Mock.Of<TheClass>();
            Mock.Get(theClass)
                .Protected()
                .Setup<string>("Property1")
                .Returns("some value");

            Assert.That(theClass.GetProperty1(), Is.EqualTo("some value"));
        }

        [Test]
        public void protected_method()
        {
            var theClass = Mock.Of<TheClass>();
            Mock.Get(theClass)
                .Protected()
                .Setup<string>("Method1", It.IsAny<int>())
                .Returns("some value");

            string valueFromMethod1 = theClass.GetValueFromMethod1(It.IsAny<int>());

            Assert.That(valueFromMethod1, Is.EqualTo("some value"));
        }

        [Test]
        public void internal_member()
        {
            var theClass = Mock.Of<TheClass>(x => x.Property2 == "some value");

            Assert.That(theClass.Property2, Is.EqualTo("some value"));
        }
    }
}