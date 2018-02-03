using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._3_Verification
{
    public class CustomerVerification
    {
        [Test]
        public void when_customer_is_added_then_validate_is_called_once()
        {
            var validator = Mock.Of<ICustomerValidator>();

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(Mock.Of<ICustomer>());

            Mock.Get(validator).Verify(x => x.Validate(It.IsAny<ICustomer>()), Times.Once);
        }

        [Test]
        public void when_customer_is_added_then_validate_is_called_once_verify_customer()
        {
            var validator = Mock.Of<ICustomerValidator>();

            var john = Mock.Of<ICustomer>(customer => customer.FirstName == "John");

            var customerRepository = new CustomerRepository(validator);
            customerRepository.Add(john);

            Mock.Get(validator).Verify(x => x.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")), Times.Once);
        }

        [Test]
        public void verify_get()
        {
            var customer = Mock.Of<ICustomer>();

            string name1 = customer.FirstName;
            string name2 = customer.FirstName;

            Mock.Get(customer).VerifyGet(x => x.FirstName, Times.Exactly(2));
        }

        [Test]
        public void verify_set()
        {
            var customer = Mock.Of<ICustomer>();
            customer.FirstName = "John";

            Mock.Get(customer).VerifySet(x => x.FirstName = "John", Times.Once);
        }
    }
}
