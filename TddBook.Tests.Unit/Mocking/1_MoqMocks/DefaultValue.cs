using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class DefaultValue
    {
        [Test]
        public void default_value()
        {
            var customerMock = new Mock<ICustomer>();
            customerMock.SetReturnsDefault("Jason");

            ICustomer customer = customerMock.Object;

            Assert.That(customer.FirstName, Is.EqualTo("Jason"));
        }
    }
}