using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._0_ManualMocks
{
    public class IsCustomerAdultValidatorTests
    {
        [Test]
        public void when_the_age_is_below_18_then_false_is_returned()
        {
            var customerMock = new CustomerMock(age: 10);

            var validator = new IsCustomerAdultValidator();

            bool isAdult = validator.Validate(customerMock);

            Assert.That(isAdult, Is.False);
        }

        [Test]
        public void when_the_age_is_above_or_equal_to_18_then_true_is_returned([Values(18, 30)] int age)
        {
            var customerMock = new CustomerMock(age: age);

            var validator = new IsCustomerAdultValidator();

            bool isAdult = validator.Validate(customerMock);

            Assert.That(isAdult, Is.True);
        }

        [Test]
        public void when_the_customer_is_null_then_exception_should_be_thrown()
        {
            var validator = new IsCustomerAdultValidator();

            Assert.That(() => validator.Validate(customer: null), Throws.ArgumentNullException);
        }
    }
}
