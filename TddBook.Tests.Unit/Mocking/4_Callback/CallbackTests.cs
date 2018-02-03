using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._4_Callback
{
    public class CallbackTests
    {
        [Test]
        public void callback_test()
        {
            int timesCalled = 0;

            var customerValidatorMock = new Mock<ICustomerValidator>();

            customerValidatorMock
                .Setup(x => x.Validate(It.IsAny<ICustomer>()))
                .Callback(() => timesCalled++);

            var customerRepository = new CustomerRepository(customerValidatorMock.Object);

            customerRepository.Add(Mock.Of<ICustomer>());
            customerRepository.Add(Mock.Of<ICustomer>());

            Assert.That(timesCalled, Is.EqualTo(2));
        }

        [Test]
        public void callback_test_generic()
        {
            var customers = new List<ICustomer>();

            var customerValidatorMock = new Mock<ICustomerValidator>();

            customerValidatorMock
                .Setup(x => x.Validate(It.IsAny<ICustomer>()))
                .Callback<ICustomer>(customer => customers.Add(customer));

            var customerRepository = new CustomerRepository(customerValidatorMock.Object);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            Assert.That(customers, Has.Count.EqualTo(1));
            Assert.That(customers, Has.Exactly(1).Matches<ICustomer>(customer => customer.FirstName == "John"));
        }

        [Test]
        public void callback_test_before_and_after()
        {
            var customerValidatorMock = new Mock<ICustomerValidator>();

            customerValidatorMock
                .Setup(x => x.Validate(It.IsAny<ICustomer>()))
                .Callback(() => TestContext.WriteLine("Before returns"))
                .Returns(true)
                .Callback(() => TestContext.WriteLine("After returns"));

            var customerRepository = new CustomerRepository(customerValidatorMock.Object);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            Assert.Pass();
        }
    }
}
