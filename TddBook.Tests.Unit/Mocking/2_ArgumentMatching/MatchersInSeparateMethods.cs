using System;
using Moq;
using NUnit.Framework;
using TddBook.Customer;

namespace TddBook.Tests.Unit.Mocking._2_ArgumentMatching
{
    public class MatchersInSeparateMethods
    {
        [Test]
        public void customer_is_added_depending_on_validation_result()
        {
            var validator = Mock.Of<ICustomerValidator>(v =>
                v.Validate(StartsWithJ) == true); // custom argument matcher

            var customerRepository = new CustomerRepository(validator);

            customerRepository.Add(Mock.Of<ICustomer>(customer =>
                customer.FirstName == "John"));

            customerRepository.Add(Mock.Of<ICustomer>(customer =>
                customer.FirstName == "james"));

            customerRepository.Add(Mock.Of<ICustomer>(customer =>
                customer.FirstName == "Ken"));

            Assert.That(customerRepository.AllCustomers, Has.Count.EqualTo(1));

            Assert.That(customerRepository.AllCustomers,
                Has.Exactly(1).Matches<ICustomer>(customer => customer.FirstName == "John"));
        }

        private ICustomer StartsWithJ
        {
            get
            {
                return It.Is<ICustomer>(x =>
                    !string.IsNullOrEmpty(x.FirstName) &&
                    x.FirstName.StartsWith("J", StringComparison.InvariantCulture));
            }
        }

        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once InconsistentNaming
        private ICustomer StartsWithJ_ByMatchCreate
        {
            get
            {
                return Match.Create<ICustomer>(x =>
                    !string.IsNullOrEmpty(x?.FirstName) &&
                    x.FirstName.StartsWith("J", StringComparison.InvariantCulture));
            }
        }
    }
}
