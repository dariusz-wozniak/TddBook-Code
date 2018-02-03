using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class MockGet
    {
        [Test]
        public void mock_get()
        {
            ICustomer customer = Mock.Of<ICustomer>(x => x.FirstName == "John");

            Mock<ICustomer> customerMock = Mock.Get(customer);
            customerMock.Setup(x => x.FirstName).Returns("Jason");

            Assert.That(customer.FirstName, Is.EqualTo("Jason"));
        }
    }
}