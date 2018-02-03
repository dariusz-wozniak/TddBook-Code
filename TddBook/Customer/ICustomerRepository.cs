using System.Collections.Generic;

namespace TddBook.Customer
{
    public interface ICustomerRepository
    {
        IReadOnlyList<ICustomer> AllCustomers { get; }
        void Add(ICustomer customer);
    }
}