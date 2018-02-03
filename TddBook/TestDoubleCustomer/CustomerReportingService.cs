using System.Linq;

namespace TddBook.TestDoubleCustomer
{
    public class CustomerReportingService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerReportingService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string GenerateReport()
        {
            return string.Join("\n", _customerRepository
                .AllCustomers
                .Select(x => x.FirstName + " " + x.LastName));
        }
    }
}
