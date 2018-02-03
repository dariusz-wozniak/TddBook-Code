using Moq;
using NUnit.Framework;
using TddBook.People;

namespace TddBook.Tests.Unit.Mocking._5_CallBase
{
    public class PersonTests
    {
        [Test]
        public void callbase_not_set()
        {
            var person = Mock.Of<Person>();

            int age = person.GetAge();

            Assert.That(age, Is.EqualTo(0));
        }

        [Test]
        public void callbase_set_to_false()
        {
            var person = Mock.Of<Person>();
            Mock.Get(person).CallBase = false;

            int age = person.GetAge();

            Assert.That(age, Is.EqualTo(0));
        }

        [Test]
        public void callbase_set_to_true()
        {
            var person = Mock.Of<Person>();
            Mock.Get(person).CallBase = true;

            int age = person.GetAge();

            Assert.That(age, Is.EqualTo(21));
        }

        [Test]
        public void mock_and_callbase([Values] bool callBase)
        {
            var person = Mock.Of<Person>();
            Mock.Get(person).CallBase = callBase;
            Mock.Get(person).Setup(x => x.GetAge()).Returns(42);

            int age = person.GetAge();

            Assert.That(age, Is.EqualTo(42));
        }
    }
}