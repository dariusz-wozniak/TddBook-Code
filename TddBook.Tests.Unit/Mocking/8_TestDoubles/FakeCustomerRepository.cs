using System.Collections.Generic;
using TddBook.TestDoubleCustomer;

namespace TddBook.Tests.Unit.Mocking._8_TestDoubles
{
    internal class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<ICustomer> _customers = new List<ICustomer>();

        public IReadOnlyList<ICustomer> AllCustomers
        {
            get { return _customers.AsReadOnly(); }
        }

        public void Add(ICustomer customer)
        {
            _customers.Add(customer);
        }
    }
}