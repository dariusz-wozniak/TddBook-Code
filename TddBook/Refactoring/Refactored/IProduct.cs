using System;

namespace TddBook.Refactoring.Refactored
{
    public interface IProduct
    {
        ProductType Type { get; set; }
        decimal Price { get; set; }
        Guid Id { get; set; }
        void MarkAsUpdated(DateTime dateTime);
    }
}