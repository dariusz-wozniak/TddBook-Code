using Moq;
using NUnit.Framework;
using TddBook.TestDoubleCustomer;

namespace TddBook.Tests.Unit.Mocking._8_TestDoubles
{
    public class TestDoubleTests
    {
        [Test]
        public void dummy()
        {
            string firstName = null;

            // dummy:
            string lastName = It.IsAny<string>();

            Assert.That(() => new TestDoubleCustomer.Customer(firstName, lastName), Throws.ArgumentNullException);
        }

        [Test]
        public void stub()
        {
            var customerValidator = new IsCustomerAdultValidator();

            // stub:
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21);

            bool validated = customerValidator.Validate(customer);

            Assert.That(validated, Is.True);
        }

        [Test]
        public void fake()
        {
            // fake:
            var customerRepository = new FakeCustomerRepository();

            customerRepository.Add(Mock.Of<ICustomer>(c =>
                c.FirstName == "John" &&
                c.LastName == "Kowalski"));

            customerRepository.Add(Mock.Of<ICustomer>(c => 
                c.FirstName == "Steve" && 
                c.LastName == "Jablonsky"));

            var customerReportingService = new CustomerReportingService(customerRepository);

            string report = customerReportingService.GenerateReport();

            Assert.That(report, Is.EqualTo("John Kowalski\nSteve Jablonsky"));
        }

        [Test]
        public void mock()
        {
            var customerValidator = new IsCustomerAdultValidator();

            // mock:
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21);

            customerValidator.Validate(customer);

            // verification of mock:
            Mock.Get(customer).Verify(x => x.GetAge());
        }

        [Test]
        public void spy()
        {
            var customerValidator = new IsCustomerAdultValidator();

            // spy:
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21);

            customerValidator.Validate(customer);

            // verification of spy:
            Mock.Get(customer).Verify(x => x.GetAge(), Times.Once);
        }
    }
}
