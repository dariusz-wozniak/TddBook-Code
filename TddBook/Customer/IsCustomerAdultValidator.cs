using System;

namespace TddBook.Customer
{
    public class IsCustomerAdultValidator : ICustomerValidator
    {
        private const int AdultAge = 18;

        public bool Validate(ICustomer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            bool isAdult = customer.GetAge() >= AdultAge;

            return isAdult;
        }
    }
}
