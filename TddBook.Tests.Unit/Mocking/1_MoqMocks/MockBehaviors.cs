using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class MockBehaviors
    {
        [Test]
        public void strict()
        {
            Mock<ICustomer> customerMock = new Mock<ICustomer>(MockBehavior.Strict);

            var customer = customerMock.Object;

            Assert.That(() => customer.FirstName, Throws.Exception.TypeOf<MockException>());
        }

        [Test]
        public void loose()
        {
            Mock<ICustomer> customerMock = new Mock<ICustomer>(MockBehavior.Loose);

            var customer = customerMock.Object;

            string firstName = customer.FirstName;

            Assert.That(firstName, Is.Null);
        }

        [Test]
        public void @default()
        {
            Mock<ICustomer> customerMock = new Mock<ICustomer>(); // default is MockBehavior.Loose

            var customer = customerMock.Object;

            string firstName = customer.FirstName;

            Assert.That(firstName, Is.Null);
        }
    }
}
