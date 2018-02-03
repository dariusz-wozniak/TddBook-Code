using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class IsCustomerAdultValidatorTests_Functional
    {
        [Test]
        public void when_the_age_is_below_18_then_false_is_returned()
        {
            ICustomer customerMock = Mock.Of<ICustomer>(x => x.GetAge() == 10);

            var validator = new IsCustomerAdultValidator();

            ICustomer customerMockObject = customerMock;
            bool isAdult = validator.Validate(customerMockObject);

            Assert.That(isAdult, Is.False);
        }

        [Test]
        public void when_the_age_is_above_or_equal_to_18_then_true_is_returned([Values(18, 30)] int age)
        {
            ICustomer customerMock = Mock.Of<ICustomer>(x => x.GetAge() == age);

            var validator = new IsCustomerAdultValidator();

            ICustomer customerMockObject = customerMock;
            bool isAdult = validator.Validate(customerMockObject);

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
