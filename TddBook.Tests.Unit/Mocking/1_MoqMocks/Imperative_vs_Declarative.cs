using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._1_MoqMocks
{
    public class Imperative_Vs_Declarative
    {
        [Test]
        public void imperative_syntax()
        {
            Mock<IOrder> order1Mock = new Mock<IOrder>();
            order1Mock.Setup(x => x.Id).Returns(23);
            order1Mock.Setup(x => x.Price).Returns(20.01m);

            Mock<IOrder> order2Mock = new Mock<IOrder>();
            order2Mock.Setup(x => x.Id).Returns(65);
            order2Mock.Setup(x => x.Price).Returns(59.99m);

            Mock<ICustomer> customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.FirstName).Returns("John");
            customerMock.Setup(x => x.PhoneNumber.Mobile).Returns("123-456-789");
            customerMock.Setup(x => x.Orders).Returns(new List<IOrder>
            {
                order1Mock.Object,
                order2Mock.Object
            });
            customerMock.Setup(x => x.GetAge()).Returns(20);

            ICustomer customer = customerMock.Object;
            AssertCustomerMock(customer);
        }

        [Test]
        public void declarative_syntax()
        {
            ICustomer customer = Mock.Of<ICustomer>(x =>
                x.FirstName == "John" &&
                x.PhoneNumber == Mock.Of<IPhoneNumber>(number => number.Mobile == "123-456-789") &&
                x.Orders == new List<IOrder>
                {
                    Mock.Of<IOrder>(order => order.Id == 23 && order.Price == 20.01m),
                    Mock.Of<IOrder>(order => order.Id == 65 && order.Price == 59.99m),
                } &&
                x.GetAge() == 20);

            AssertCustomerMock(customer);
        }

        private static void AssertCustomerMock(ICustomer customerMock)
        {
            Assert.Multiple(() =>
            {
                Assert.That(customerMock.FirstName, Is.EqualTo("John"));
                Assert.That(customerMock.PhoneNumber.Mobile, Is.EqualTo("123-456-789"));
                Assert.That(customerMock.Orders, Has.Count.EqualTo(2));
                Assert.That(customerMock.Orders[0].Id, Is.EqualTo(23));
                Assert.That(customerMock.Orders[0].Price, Is.EqualTo(20.01m));
                Assert.That(customerMock.Orders[1].Id, Is.EqualTo(65));
                Assert.That(customerMock.Orders[1].Price, Is.EqualTo(59.99m));
                Assert.That(customerMock.GetAge(), Is.EqualTo(20));
            });
        }
    }
}
