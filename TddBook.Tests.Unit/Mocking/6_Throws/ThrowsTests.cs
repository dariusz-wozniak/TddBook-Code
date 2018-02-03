using System;
using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._6_Throws
{
    public class ThrowsTests
    {
        [Test]
        public void mock_that_throws_exception()
        {
            var customer = Mock.Of<ICustomer>();

            Mock.Get(customer).Setup(x => x.FirstName).Throws<ArgumentNullException>();

            Assert.That(() => customer.FirstName, Throws.ArgumentNullException);
        }
    }
}
