namespace TddBook.TestDoubleCustomer
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        int GetAge();
    }
}