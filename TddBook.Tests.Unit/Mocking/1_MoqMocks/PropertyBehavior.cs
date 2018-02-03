using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class PropertyBehavior
    {
        [Test]
        public void property_behavior__imperative()
        {
            var customerMock = new Mock<ICustomer>();
            customerMock.SetupProperty(x => x.FirstName, "John");

            ICustomer customer = customerMock.Object;
            customer.FirstName = "Jason";

            string firstName = customer.FirstName;

            Assert.That(firstName, Is.EqualTo("Jason"));
        }

        [Test]
        public void property_behavior_with_setup_all_properties__imperative()
        {
            var customerMock = new Mock<ICustomer>();
            customerMock.SetupAllProperties();

            ICustomer customer = customerMock.Object;
            customer.FirstName = "Jason";

            string firstName = customer.FirstName;

            Assert.That(firstName, Is.EqualTo("Jason"));
        }

        [Test]
        public void property_behavior__declarative()
        {
            ICustomer customer = Mock.Of<ICustomer>(x => x.FirstName == "John");
            customer.FirstName = "Jason";

            string firstName = customer.FirstName;

            Assert.That(firstName, Is.EqualTo("Jason"));
        }
    }
}