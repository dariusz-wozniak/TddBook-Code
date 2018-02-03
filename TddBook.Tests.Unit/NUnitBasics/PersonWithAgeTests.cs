using System;
using NUnit.Framework;
using TddBook.PersonWithAge;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class PersonWithAgeTests
    {
        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_is_thrown()
        {
            try
            {
                new Person { Age = 123 };
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail("ArgumentOutOfRangeException should be thrown but it has not been");
        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_is_thrown__classic_model()
        {
            // Approach #1:
            TestDelegate action = () => new Person { Age = 123 };
            Assert.Throws<ArgumentOutOfRangeException>(action);

            // Approach #2:
            Assert.Throws<ArgumentOutOfRangeException>(delegate { new Person { Age = 123 }; });

            // Approach #3:
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person { Age = 123 });

            // Approach #4:
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new Person { Age = 123 });
        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_is_thrown__constraint_based_model()
        {
            // Approach #1:
            Assert.That(
                () => new Person { Age = 123 },
                Throws.TypeOf<ArgumentOutOfRangeException>());

            // Approach #2:
            Assert.That(
                () => new Person { Age = 123 },
                Throws.TypeOf(typeof(ArgumentOutOfRangeException)));

            // Approach #3:
            Assert.That(
                () => new Person { Age = 123 },
                Throws.Exception);
        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_of_instance_of_argumentexception_is_thrown__classic_model()
        {
            // Approach #1:
            Assert.Catch<ArgumentException>(() => new Person { Age = 123 });

            // Approach #2:
            Assert.Throws(Is.InstanceOf<ArgumentException>(), () => new Person { Age = 123 });

            // Approach #3:
            Assert.Throws(
                Is.InstanceOf(typeof(ArgumentException)),
                () => new Person { Age = 123 });

        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_of_instance_of_argumentexception_is_thrown__constraint_based_model()
        {
            Assert.That(
                () => new Person { Age = 123 },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void when_the_person_has_the_age_of_122_then_exception_is_not_thrown__classic_model()
        {
            Assert.DoesNotThrow(() => new Person { Age = 122 });
        }

        [Test]
        public void when_the_person_has_the_age_of_122_then_exception_is_not_thrown__constraint_based_model()
        {
            Assert.That(() => new Person { Age = 122 }, Throws.Nothing);
        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_is_thrown_with_param_name_and_message__classic_model()
        {
            ArgumentOutOfRangeException exception =
                Assert.Throws<ArgumentOutOfRangeException>(() => new Person { Age = 123 });

            Assert.AreEqual("value", exception.ParamName);
            Assert.AreEqual("Age must be less or equal to 122\r\nParameter name: value", exception.Message);
        }

        [Test]
        public void when_the_person_has_the_age_of_123_then_exception_is_thrown_with_param_name_and_message__constraint_based_model()
        {
            Assert.That(() => new Person { Age = 123 },
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName").EqualTo("value")
                    .And.With.Message.EqualTo("Age must be less or equal to 122\r\nParameter name: value"));

        }
    }
}
