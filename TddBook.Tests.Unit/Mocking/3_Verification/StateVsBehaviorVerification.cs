using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._3_Verification
{
    public class StateVsBehaviorVerification
    {
        [Test]
        public void state_verification()
        {
            var validator = Mock.Of<ICustomerValidator>(customerValidator => customerValidator.Validate(It.Is<ICustomer>(cust => cust.FirstName == "John")));

            var customer = Mock.Of<ICustomer>(cust => cust.FirstName == "John");

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(customer);

            Assert.That(customerRepository.AllCustomers, Has.Count.EqualTo(1));
            Assert.That(customerRepository.AllCustomers, Has.Exactly(1).Matches<ICustomer>(cust => cust.FirstName == "John"));
        }

        [Test]
        public void behavior_verification()
        {
            var validator = Mock.Of<ICustomerValidator>(customerValidator => customerValidator.Validate(It.Is<ICustomer>(cust => cust.FirstName == "John")));

            var customer = Mock.Of<ICustomer>(cust => cust.FirstName == "John");

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(customer);

            Mock.Get(validator).Verify(x => x.Validate(It.Is<ICustomer>(cust => cust.FirstName == "John")), Times.Once);
        }
    }
}