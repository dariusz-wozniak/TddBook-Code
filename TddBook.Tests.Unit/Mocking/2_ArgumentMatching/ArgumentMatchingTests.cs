using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._2_ArgumentMatching
{
    public class ArgumentMatchingTests
    {
        [Test]
        public void when_validator_always_returns_false_then_customer_is_never_added()
        {
            var validator = Mock.Of<ICustomerValidator>();

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "James"));

            Assert.That(customerRepository.AllCustomers, Is.Empty);
        }

        [Test]
        public void when_validator_always_returns_true_then_customer_is_always_added()
        {
            var validator = Mock.Of<ICustomerValidator>(v => v.Validate(It.IsAny<ICustomer>()) == true);

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "James"));

            Assert.That(customerRepository.AllCustomers, Has.Count.EqualTo(2));
            Assert.That(customerRepository.AllCustomers, Has.Exactly(1).Matches<ICustomer>(customer => customer.FirstName == "John"));
            Assert.That(customerRepository.AllCustomers, Has.Exactly(1).Matches<ICustomer>(customer => customer.FirstName == "James"));
        }

        [Test]
        public void customer_is_added_depending_on_validation_result()
        {
            var validator = Mock.Of<ICustomerValidator>(v => v.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")) == true);

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "James"));

            Assert.That(customerRepository.AllCustomers, Has.Count.EqualTo(1));
            Assert.That(customerRepository.AllCustomers, Has.Exactly(1).Matches<ICustomer>(customer => customer.FirstName == "John"));
        }
    }
}
