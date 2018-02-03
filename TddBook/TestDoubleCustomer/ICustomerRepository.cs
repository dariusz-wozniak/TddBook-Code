using System.Collections.Generic;

namespace TddBook.TestDoubleCustomer
{
    public interface ICustomerRepository
    {
        IReadOnlyList<ICustomer> AllCustomers { get; }
        void Add(ICustomer customer);
    }
}