namespace TddBook.Customer
{
    public interface IOrder
    {
        int Id { get; set; }
        decimal Price { get; set; }
    }
}